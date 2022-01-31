using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
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
        private SettingBL settingBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            settingBL = new SettingBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Setting | Billy Admin Panel";
            
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if (IsPostBack) return;
            
            FillRecords(1);
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

            UpdateRecords(1, cart_min_price, cart_min_price_msg, website_close, website_close_msg, wallet_amt, referral_amt,theme_color);
        }
        protected void ddtthemecolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tcolor = ddtthemecolor.SelectedItem.Value.ToString();
            themecolor(tcolor);
        }
        private void FillRecords(int p_id)
        {
            try
            {
                Setting setting = new Setting();
                setting.SetId(p_id);
                setting = settingBL.DisplaySettingById(setting);
                // Get Setting Values
                txtcart_min_price.Text = setting.GetCartMinPrice().ToString();
                txtcart_min_price_msg.Text = setting.GetCartMinPriceMsg().ToString();
                ddtwebsite_close.ClearSelection();
                var value = setting.GetWebsiteClose().ToString().Trim(' ');
                ddtwebsite_close.Items.FindByValue(value).Selected = true;
                txtwebsite_close_msg.Text = setting.GetWebsiteCloseMsg().ToString();
                txtwallet_amt.Text = setting.GetWalletAmt().ToString();
                txtreferral_amt.Text = setting.GetReferralAmt().ToString();
                var valuecolor = setting.GetThemeColor().ToString().Trim(' ');
                ddtthemecolor.Items.FindByValue(valuecolor).Selected = true;
                themecolor(valuecolor);
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void themecolor(string v)
        {
            string color = ddtthemecolor.Items.FindByValue(v).Attributes.CssStyle.Value;
            ddtthemecolor.Attributes.Add("style", color + "width:20%;color:white");
        }
        private void UpdateRecords(int p_id, decimal p_cart_min_price, string p_cart_min_price_msg, string p_website_close,string p_website_close_msg, decimal p_wallet_amt, decimal p_referral_amt, string p_theme_color)
        {
            
            try
            {
                Setting setting = new Setting(p_id, p_cart_min_price, p_cart_min_price_msg, p_website_close, p_website_close_msg, p_wallet_amt, p_referral_amt, p_theme_color);
                int retVal = settingBL.UpdateSetting(setting);
                if (retVal > 0)
                {
                    Response.Redirect("setting", false);
                }
                else
                {
                    Response.Write("Not Updated Category");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
    }
}