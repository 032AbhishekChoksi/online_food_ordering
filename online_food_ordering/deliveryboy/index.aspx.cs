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

namespace online_food_ordering.deliveryboy
{
    public partial class index : System.Web.UI.Page
    {
        private Order_MasterBL order_MasterBL;
        private SettingBL settingBL;
        private Dictionary<string, string> getOrderById;
        private CustomerBL customerBL;
        private DataTable dt;
        private ClassUser objUser;
        private DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
            settingBL = new SettingBL();
            customerBL = new CustomerBL();
            objUser = new ClassUser();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Index | Billy Delivery Boy Panel";
            if (Session["DELIVERY_BOY_USER_LOGIN"] == null)
            {
                Response.Redirect("login");
            }
            if (!this.Page.IsPostBack)
            { 
                FillRecords();
            }
            if (Request.QueryString["set_payment"] != null)
            {
                Order_Master order_Master = new Order_Master();
                order_Master.SetId(Convert.ToInt32(Request.QueryString["set_payment"].ToString()));
                order_Master.SetPaymentStatus("success");
                order_Master.SetDeliveryBoyId(Convert.ToInt32(Session["DELIVERY_BOY_ID"].ToString()));

                order_MasterBL.UpdatePaymentStatusByOIdAndDid(order_Master);
                Response.Redirect("index");
            }
            if(Request.QueryString["set_order_id"] != null)
            {
                Order_Master order_Master = new Order_Master();
                order_Master.SetId(Convert.ToInt32(Request.QueryString["set_order_id"].ToString()));
                order_Master.SetOrderStatus(4);
                order_Master.SetDeliveredOn(DateTime.Now);
                order_Master.SetDeliveryBoyId(Convert.ToInt32(Session["DELIVERY_BOY_ID"].ToString()));

                order_MasterBL.UpdateOrderStatusByOIdAndDid(order_Master);

                // Refferral Code
                decimal referral_amt = 0;
                Setting setting = new Setting();
                setting.SetId(1);
                setting = settingBL.DisplaySettingById(setting);

                referral_amt = setting.GetReferralAmt();
                if (referral_amt > 0)
                {
                    getOrderById = order_MasterBL.GetOrderByIdFunction(order_Master);
                    int user_id = Convert.ToInt32(getOrderById["user_id"]);
                    order_Master.SetUserId(user_id);
                   
                    int total_order = order_MasterBL.DisplayTotalOrderByUidAndOStatus(order_Master);
                    if (total_order == 1)
                    {
                        Customer customer = new Customer();
                        customer.SetId(user_id);
                        dt = customerBL.DisplayCustomerByCid(customer);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
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
                 Response.Redirect("index");
            }
        }
        public string ucfirst(Object payment_status)
        {
            string s = payment_status.ToString();
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        private void FillRecords()
        {
            lblDELIVERY_BOY_USER.Text = Session["DELIVERY_BOY_USER"].ToString();

            Delivery_Boy delivery_Boy = new Delivery_Boy();
            delivery_Boy.SetId(Convert.ToInt32(Session["DELIVERY_BOY_ID"].ToString()));
            DataTable dt = order_MasterBL.DisplayOrderDeliveryByDeliveryBoyId(delivery_Boy);
            r1.DataSource = dt;
            r1.DataBind();
        }
    }
}