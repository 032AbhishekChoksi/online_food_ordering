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
        ClassAdmin admin = new ClassAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Login | Billy Admin Panel";
            foreach (DataRow dr in admin.DisplayThemeColor(1).Rows)
            {
               lnkstyle.Attributes["href"] = "assets/css/" + dr["theme_color"].ToString();
            }
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            int i = 0;
            string username=txtusername.Text;
            string password=txtpassword.Text;

            i = admin.DisplayAdminByUsernameAndPassword(username,password);

            if (i > 0)
            {
                Session["ADMIN_USER"] = txtusername.Text;
                Response.Redirect("index.aspx");
            }
            else
            {
                error.Style.Add("display", "block");
            }

        }
    }
}