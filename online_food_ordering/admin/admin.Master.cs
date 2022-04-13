using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        private SettingBL settingBL;
        private MaintenanceBL maintenanceBL;
        private DataTable dt;
        protected void Page_Init(object sender, EventArgs e)
        {
            settingBL = new SettingBL();
            maintenanceBL = new MaintenanceBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UnderMaintenance();
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }
            else
            {
                lblsession.Text = Session["ADMIN_USER"].ToString();
                FetchThemeColor(1);
            }            
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
        private void UnderMaintenance()
        {
            // Fill Record For Customer Toggle Button
            Maintenance maintenance = new Maintenance();
            maintenance.SetName("Admin");
            dt = maintenanceBL.DisplayMaintenanceByName(maintenance);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["name"].ToString().Equals("Admin"))
                    {
                        bool status = Convert.ToBoolean(dr["status"]);
                        if (status)
                        {
                            Response.Redirect("~/page/underconstructor.html", false);
                        }
                    }
                }
            }
        }
    }
}