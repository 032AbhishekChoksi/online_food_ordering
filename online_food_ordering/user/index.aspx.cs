using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class index : System.Web.UI.Page
    {
        private BannerBL bannerBL;
        private MaintenanceBL maintenanceBL;
        private DataTable dt;
        protected void Page_Init(object sender, EventArgs e)
        {
            bannerBL = new BannerBL();
            maintenanceBL = new MaintenanceBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Welcome to Billy";
            FillData();
            UnderMaintenance();
        }
        private void FillData()
        {
            r1.DataSource = bannerBL.DisplayBannerByStatus();
            r1.DataBind();
        }
        private void UnderMaintenance()
        {
            // Fill Record For Customer Toggle Button
            Maintenance maintenance = new Maintenance();
            maintenance.SetName("Customer");
            dt = maintenanceBL.DisplayMaintenanceByName(maintenance);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["name"].ToString().Equals("Customer"))
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