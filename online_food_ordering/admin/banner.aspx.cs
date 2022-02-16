using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class banner : System.Web.UI.Page
    {
        private BannerBL bannerBL;
        ClassAdmin admin = new ClassAdmin();
        private int id = 0;
        private byte status = 1;
        private string type = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            bannerBL = new BannerBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Banner | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();
               
                if (IsPostBack) return;
                BannerAction(id, type);
            }

            FillData();
        }
        private void FillData()
        {
            r1.DataSource = bannerBL.DisplayBanner();
            r1.DataBind();
        }
        private void BannerAction(int p_id, string p_type)
        {
            byte status;
            if (p_id > 0 && p_type.Equals("deactive"))
            {
                status = 0;
                Banner banner = new Banner();
                banner.SetId(p_id);
                banner.SetStatus(status);
                bannerBL.UpdateBannerStatus(banner);
                Response.Redirect("banner");
            }
            else if (p_id > 0 && p_type.Equals("active"))
            {
                status = 1;
                Banner banner = new Banner();
                banner.SetId(p_id);
                banner.SetStatus(status);
                bannerBL.UpdateBannerStatus(banner);
                Response.Redirect("banner");
            }
            else if (id > 0 && type.Equals("delete"))
            {
                Banner banner = new Banner();
                banner.SetId(p_id);
                bannerBL.RemoveBanner(banner);
                Response.Redirect("banner");
            }
        }
    }
}