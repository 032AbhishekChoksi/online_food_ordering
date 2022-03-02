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
            int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
            FillDataInRepeater(uid);
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
        protected String[] ApplyCoupon(object coupon_code,object final_price)
        {
            String[] result = new String[2];
            string coupon = coupon_code.ToString().Trim(' ');
            string final = final_price.ToString();
            if (string.IsNullOrEmpty(coupon) || string.IsNullOrWhiteSpace(coupon))
            {
                result[0] = "Coupon Code:- " + coupon + "<br />";
                result[1] = "Final Price:- " + final + " Rs.";
            }
            else
            {
                result[0] = "-";
                result[1] = "-";
            }
            return result;
        }
        protected string CheckOrderStatus(object order_status)
        {
            string result = string.Empty;
            string order = order_status.ToString();
            if (order.Equals("1"))
            {
                result += "<br/>";
                result += "<div style='margin-top:10px;'><a href='order_history.aspx?cancel_id=" + order + "' class='cancel_btn'>Cancel</a></div>";
            }
            return result;
        }
    }
}