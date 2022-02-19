using online_food_ordering.bussinesslogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class index : System.Web.UI.Page
    {
        private BannerBL bannerBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            bannerBL = new BannerBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Welcome to Billy";
            FillData();
        }
        private void FillData()
        {
            r1.DataSource = bannerBL.DisplayBannerByStatus();
            r1.DataBind();
        }
    }
}