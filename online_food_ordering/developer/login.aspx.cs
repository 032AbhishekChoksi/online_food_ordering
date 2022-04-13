using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.developer
{
    public partial class login : System.Web.UI.Page
    {
        private SettingBL settingBL;
        private DeveloperBL developerBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            settingBL = new SettingBL();
            developerBL = new DeveloperBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Login | Billy Developer Panel";
            if (Session["DEVELOPER_USER"] != null)
            {
                Response.Redirect("index");
            }
            FetchThemeColor(1);
        }
        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            CheckDeveloperByUsernameAndPassword(username, password);
        }
        private void FetchThemeColor(int p_id)
        {
            try
            {
                Setting setting = new Setting();
                setting.SetId(p_id);
                setting = settingBL.DisplaySettingById(setting);
                lnkstyle.Attributes["href"] = "../admin/assets/css/" + setting.GetThemeColor();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void CheckDeveloperByUsernameAndPassword(string p_username, string p_password)
        {
            try
            {
                int retVal = 0;
                Developer developer = new Developer();
                developer.SetName(p_username);
                developer.SetPassword(p_password);
                retVal = developerBL.DisplayDeveloperByUsernameAndPassword(developer);
                if (retVal > 0)
                {
                    Session["DEVELOPER_USER"] = txtusername.Text;
                    Response.Redirect("index", false);
                }
                else
                {
                    error.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }       
    }
}