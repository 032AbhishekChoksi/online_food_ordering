using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FOOD_USER_NAME"] != null)
            {
                Session.Remove("FOOD_USER_ID");
                Session.Remove("FOOD_USER_NAME");
                Session.Remove("FOOD_USER_EMAIL");
            }
            Response.Redirect("login_register");
        }
    }
}