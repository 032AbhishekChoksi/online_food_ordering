using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.developer
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DEVELOPER_USER"] != null)
            {                
                Session.Remove("DEVELOPER_USER");
            }
            Response.Redirect("login");
        }
    }
}