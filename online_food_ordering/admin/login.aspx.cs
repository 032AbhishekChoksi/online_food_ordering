using System;
using System.Collections.Generic;
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