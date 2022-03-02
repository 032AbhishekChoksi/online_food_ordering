using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = string.Empty;
            
            if(Session["ORDER_ID"] != null)
            {
                 OID = Session["ORDER_ID"].ToString();
                 Session.Remove("ORDER_ID");
            }
            else
            {
                Response.Redirect("shop");
            }
            lblOrderID.Text = OID;
        }
    }
}