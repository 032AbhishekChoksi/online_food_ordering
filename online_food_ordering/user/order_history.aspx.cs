using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class order_history : System.Web.UI.Page
    {
        private Order_MasterBL order_MasterBL;
        private int uid = 0;
        private int oid = 0;
        private string paymentstatus = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Order History | Billy";
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
            FillDataInRepeater(uid);

            if (Request.QueryString["order_id"] != null && Request.QueryString["payment"] != null)
            {
                oid = Convert.ToInt32(Request.QueryString["order_id"]);               
                paymentstatus = Request.QueryString["payment"].ToString();
                UpdateOrderStatus(oid, paymentstatus);
            }
        }
        private void FillDataInRepeater(int puid)
        {
            Customer customer = new Customer();
            customer.SetId(puid);
            if(order_MasterBL.DisplayOrderMasterByUserId(customer).Rows.Count > 0) { 
                r1.DataSource = order_MasterBL.DisplayOrderMasterByUserId(customer);
                r1.DataBind();
            }
            else
            {
                Response.Redirect("shop");
            }
        }
        protected String[] ApplyCoupon(object coupon_code, object final_price)
        {
            String[] result = new String[2];
            string coupon = coupon_code.ToString().Trim(' ');
            decimal final = Convert.ToDecimal(final_price.ToString());
         
            if (!string.IsNullOrEmpty(coupon))
            {
                result[0] = "Coupon Code:- " + coupon + "<br />";
                result[1] = "Final Price:- " + Math.Round((decimal)final) + " Rs.";
            }
            else
            {
                result[0] = "-";
                result[1] = "";
            }
            return result;
        }
        protected string CheckOrderStatus(object p_oid,object order_status,object payment_status)
        {
            string result = string.Empty;
            string order = order_status.ToString();
            string payment = payment_status.ToString();
            int ooid = Convert.ToInt32(p_oid);
            if (order.Equals("1"))
            {
                result += "<br/>";
                result += "<div style='margin-top:10px;'><a href='order_history.aspx?order_id="+ooid+"&payment="+payment+"' class='cancel_btn'>Cancel</a></div>";
            }
            return result;
        }
        private void UpdateOrderStatus(int p_oid, string p_paymentstatus)
        {
            Order_Master order_Master = new Order_Master();
            order_Master.SetId(p_oid);
            order_Master.SetOrderStatus(5);

            DateTime cancel_at = DateTime.Now;
            order_Master.SetCancelBy("User");
            order_Master.SetCancelAt(cancel_at);
            if (p_paymentstatus.Equals("pending"))
            {
                order_Master.SetRefundStatus(0);
            }
            else
            {
                order_Master.SetRefundStatus(1);
            }
            order_MasterBL.UpdateOrderStatusAndCancelStatusById(order_Master);
           
            Response.Redirect("order_history");
        }
    }
}