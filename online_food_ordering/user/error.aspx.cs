using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Fail Order | Billy";
            if (Session["ORDER_ID"] != null)
            {
                Session.Remove("ORDER_ID");
            }
            else
            {
                Response.Redirect("shop");
            }
        }
    }
}