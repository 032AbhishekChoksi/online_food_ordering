using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class verify : System.Web.UI.Page
    {
        ClassUser user = new ClassUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Verify Email ID | Billy";

            if (!string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                string id = Request.QueryString["id"].ToString();
                int check = user.DisplayUserByRandomString(id).Rows.Count;
                if(check > 0)
                {
                    user.UpdateUserEmailVerify(id, 1);
                    lblmessage.Visible = true;
                    lblmessage.Text = "Email ID Verify";
                    lblmessage.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "Email ID Not Verify";
                    lblmessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Response.Redirect("shop.aspx");
            }
        }
    }
}