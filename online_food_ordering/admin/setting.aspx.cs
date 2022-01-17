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
                var valuecolor = dr["theme_color"].ToString().Trim(' ');
                ddtthemecolor.Items.FindByValue(valuecolor).Selected = true;
                themecolor(valuecolor);
            }
            
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            decimal cart_min_price = Convert.ToDecimal(txtcart_min_price.Text);
            string cart_min_price_msg = txtcart_min_price_msg.Text;
            string website_close = ddtwebsite_close.SelectedItem.Value.ToString();
            string website_close_msg = txtwebsite_close_msg.Text;
            decimal wallet_amt = Convert.ToDecimal(txtwallet_amt.Text);
            decimal referral_amt = Convert.ToDecimal(txtreferral_amt.Text);
            string theme_color = ddtthemecolor.SelectedItem.Value.ToString();

            admin.UpdateSetting(1, cart_min_price, cart_min_price_msg, website_close, website_close_msg, wallet_amt, referral_amt,theme_color);
            Response.Redirect("setting.aspx");
        }      

        protected void ddtthemecolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tcolor = ddtthemecolor.SelectedItem.Value.ToString();
            themecolor(tcolor);

        }
        private void themecolor(string v)
        {
            string color = ddtthemecolor.Items.FindByValue(v).Attributes.CssStyle.Value;
            ddtthemecolor.Attributes.Add("style", color + "width:20%;color:white");
        }
    }
}