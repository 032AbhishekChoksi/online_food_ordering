using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class delivery_boy : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        byte status = 1;
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Delivery Boy | Billy Admin Panel";
            
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }

            r1.DataSource = admin.DisplayDeliveryBoy();
            r1.DataBind();
        }
    }
}