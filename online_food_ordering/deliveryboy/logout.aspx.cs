using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.deliveryboy
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DELIVERY_BOY_USER_LOGIN"] != null)
            {
                Session.Remove("DELIVERY_BOY_USER_LOGIN");
                Session.Remove("DELIVERY_BOY_USER");
                Session.Remove("DELIVERY_BOY_ID");
            }
            Response.Redirect("login");
        }
    }
}