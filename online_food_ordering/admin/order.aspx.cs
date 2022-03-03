using online_food_ordering.bussinesslogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class order : System.Web.UI.Page
    {
        private Order_MasterBL order_MasterBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Order | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }
            
            FillOrderMasterRecords();
        }
        private void FillOrderMasterRecords()
        {
            r1.DataSource = order_MasterBL.DisplayOrderMaster();
            r1.DataBind();
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
                result[0] = "";
                result[1] = "";
            }
            return result;
        }
    }


}