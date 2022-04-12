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
    public partial class login_register : System.Web.UI.Page
    {
        private SettingBL settingBL;
        protected string websiteclose = string.Empty;
        protected string websiteclosemsg = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            settingBL = new SettingBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Login or Registration | Billy";

            Setting setting = new Setting();
            setting.SetId(1);
            setting = settingBL.DisplaySettingById(setting);
            if (setting != null)
            {
                websiteclose = setting.GetWebsiteClose();
                websiteclosemsg = setting.GetWebsiteCloseMsg();
            }

            if (Request.QueryString["referral_code"] != null)
            {
                string referral_code = Request.QueryString["referral_code"].ToString();
                Session["FROM_REFERRAL_CODE"] = referral_code;
            }
        }
    }
}