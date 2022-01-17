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
        ClassAdmin admin_class = new ClassAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                lblsession.Text = Session["ADMIN_USER"].ToString();
                foreach (DataRow dr in admin_class.DisplayThemeColor(1).Rows)
                {
                    lnkstyle.Attributes["href"] = "assets/css/" + dr["theme_color"].ToString();
                }
            }            
        }
    }
}