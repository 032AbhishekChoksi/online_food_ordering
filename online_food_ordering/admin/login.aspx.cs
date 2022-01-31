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
    public partial class login : System.Web.UI.Page
    {
        private AdminBL adminBL;
        private SettingBL settingBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            adminBL = new AdminBL();
            settingBL = new SettingBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Login | Billy Admin Panel";
            if (Session["ADMIN_USER"] != null)
            {
                Response.Redirect("index");
            }
            FetchThemeColor(1);
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            string username=txtusername.Text;
            string password=txtpassword.Text;

            CheckAdminByUsernameAndPassword(username,password);
        }
        private void FetchThemeColor(int p_id)
        {
            try
            {
                Setting setting = new Setting();
                setting.SetId(p_id);
                setting = settingBL.DisplaySettingById(setting);
                lnkstyle.Attributes["href"] = "assets/css/" + setting.GetThemeColor();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void CheckAdminByUsernameAndPassword(string p_username, string p_password)
        {
            try
            {
                int retVal = 0;
                Admin admin = new Admin();
                admin.SetName(p_username);
                admin.SetPassword(p_password);
                retVal = adminBL.DisplayAdminByUsernameAndPassword(admin);
                if (retVal > 0)
                {
                    Session["ADMIN_USER"] = txtusername.Text;
                    Response.Redirect("index",false);
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