using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class setting : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Setting | Billy Admin Panel";
            
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (IsPostBack) return;
            foreach (DataRow dr in admin.DisplaySettingById(1).Rows)
            {
                txtcart_min_price.Text = dr["cart_min_price"].ToString();
                txtcart_min_price_msg.Text = dr["cart_min_price_msg"].ToString();
                ddtwebsite_close.ClearSelection();
                var value = dr["website_close"].ToString().Trim(' ');
                ddtwebsite_close.Items.FindByValue(value).Selected = true;
                txtwebsite_close_msg.Text = dr["website_close_msg"].ToString();
                txtwallet_amt.Text = dr["wallet_amt"].ToString();
                txtreferral_amt.Text = dr["referral_amt"].ToString();
            }
            
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {

        }
    }
}