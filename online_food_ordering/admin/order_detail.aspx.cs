using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using online_food_ordering.user;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class order_detail : System.Web.UI.Page
    {
        protected int oid = 0;
        private Order_MasterBL order_MasterBL;
        private Order_DetailBL order_DetailBL;
        protected Dictionary<string, string> orderRow;
        protected Dictionary<int, Dictionary<string, string>> getOrderDetails;
        private Order_StatusBL order_StatusBL;
        protected string deliveryBoy = string.Empty;
        private Delivery_BoyBL delivery_BoyBL;
        private SettingBL settingBL;
        private Dictionary<string, string> getOrderById;
        private CustomerBL customerBL;
        private DataTable dt;
        private ClassUser objUser;
        private DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
            order_DetailBL = new Order_DetailBL();
            order_StatusBL = new Order_StatusBL();
            delivery_BoyBL = new Delivery_BoyBL();
            settingBL = new SettingBL();
            customerBL = new CustomerBL();
            objUser = new ClassUser();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Order Detail | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if (Request.QueryString["id"] != null)
            {
                oid = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                Response.Redirect("index");
            }
           // if (IsPostBack) return;
            FillRecords();
        }
        private void FillRecords()
        {
            Order_Master order_Master = new Order_Master();
            order_Master.SetId(oid);
            orderRow = order_MasterBL.GetOrderRow(order_Master);
            if (orderRow.Count > 0) {  }
            else
            {
                Response.Redirect("index", false);
            }
            getOrderDetails = order_DetailBL.getOrderDetails(order_Master);

            string order_status_str = orderRow["order_status_str"];

            if (!this.Page.IsPostBack)
            {
                // Order Status Drop Downlist Data Bind
                ddlorderstatus.DataSource = order_StatusBL.DisplayOrderStatusOrderByOrderStatus();
                ddlorderstatus.DataTextField = "order_status";
                ddlorderstatus.DataValueField = "id";
                ddlorderstatus.DataBind();

                ddlorderstatus.Items.Insert(0, new ListItem("Update Order Status", ""));

                ddlorderstatus.ClearSelection();
                var valueorder = order_status_str.ToString().Trim(' ');
                ddlorderstatus.Items.FindByText(valueorder).Selected = true;

                // Delivery Boy Drop Downlist Data Bind
                ddldeliveryboy.DataSource = delivery_BoyBL.DisplayDeliveyBoyByStatus();
                ddldeliveryboy.DataTextField = "name";
                ddldeliveryboy.DataValueField = "id";
                ddldeliveryboy.DataBind();

                ddldeliveryboy.Items.Insert(0, new ListItem("Assign Delivery Boy", "0"));

                ddldeliveryboy.ClearSelection();
                var valuedeliveryboy = orderRow["delivery_boy_id"].ToString().Trim(' ');
                ddldeliveryboy.Items.FindByValue(valuedeliveryboy).Selected = true;
               
                if (order_status_str.ToLower().Equals("cancel") || order_status_str.ToLower().Equals("delivered"))
                {
                    ddlorderstatus.Enabled = false;
                    ddldeliveryboy.Enabled = false;
                }
                else
                {
                    ddlorderstatus.Enabled = true;
                    ddldeliveryboy.Enabled = true;
                }
            }
            Delivery_Boy delivery_Boy = new Delivery_Boy();
            delivery_Boy.SetId(Convert.ToInt32(orderRow["delivery_boy_id"]));
            deliveryBoy = delivery_BoyBL.getDeliveryBoyNameById(delivery_Boy);
        }

        protected void ddlorderstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownList = sender as DropDownList;
          
            //Get the ID of the DropDownList.
            int status = Convert.ToInt32(dropDownList.SelectedItem.Value);
            
            Order_Master order_Master = new Order_Master();
            order_Master.SetId(oid);
            order_Master.SetOrderStatus(status);
            if (status == 5)
            {
                DateTime cancel_at = DateTime.Now;
                order_Master.SetCancelBy("Admin");
                order_Master.SetCancelAt(cancel_at);
                if(orderRow["payment_status"].Equals("pending"))
                {
                    order_Master.SetRefundStatus(0);
                }
                else
                {
                    order_Master.SetRefundStatus(1);
                }                
                order_MasterBL.UpdateOrderStatusAndCancelStatusById(order_Master);
            }
            else
            {
                order_MasterBL.UpdateOrderStatusById(order_Master);
            }
            ReferralAmount(status);
        }

        protected void ddldeliveryboy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownList = sender as DropDownList;

            //Get the ID of the DropDownList.
            int did = Convert.ToInt32(dropDownList.SelectedItem.Value);
            Order_Master order_Master = new Order_Master();
            order_Master.SetId(oid);
            order_Master.SetDeliveryBoyId(did);
            order_MasterBL.UpdateDeliveryBoyStatusByOid(order_Master);
        }
        private void ReferralAmount(int p_status)
        {
            decimal referral_amt = 0;
            Setting setting = new Setting();
            setting.SetId(1);
            setting = settingBL.DisplaySettingById(setting);

            referral_amt = setting.GetReferralAmt();

            if(referral_amt > 0)
            {
                if (p_status == 4)
                {
                    Order_Master order_Master = new Order_Master();
                    order_Master.SetId(oid);
                    getOrderById = order_MasterBL.GetOrderByIdFunction(order_Master);
                    int user_id = Convert.ToInt32(getOrderById["user_id"]);
                    
                    order_Master.SetUserId(user_id);
                    order_Master.SetOrderStatus(4);
                    int total_order = order_MasterBL.DisplayTotalOrderByUidAndOStatus(order_Master);
                    if (total_order == 1)
                    {
                        Customer customer = new Customer();
                        customer.SetId(user_id);                       
                        dt = customerBL.DisplayCustomerByCid(customer);
                        if(dt.Rows.Count > 0)
                        {
                            foreach(DataRow dr in dt.Rows)
                            {
                                string email = dr["email"].ToString();
                                string from_referral_code = dr["from_referral_code"].ToString();
                                customer = new Customer();
                                customer.SetReferralCode(from_referral_code);
                                int uid = customerBL.DisplayCustomerIdByReferralCode(customer);
                                string msg = "Referral Amt from " + email;
                                objUser.manageWallet(uid, referral_amt, msg, "in", "", added_on);
                            }                            
                        }
                    }
                }
            }
        }
    }
}