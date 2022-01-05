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
        ClassAdmin admin = new ClassAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Banner | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }

            r1.DataSource = admin.DisplayBanner();
            r1.DataBind();
        }
    }
}