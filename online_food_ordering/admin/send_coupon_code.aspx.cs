using online_food_ordering.admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering
{
    public partial class send_coupon_code : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        ClassFunction function = new ClassFunction();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Send Coupon Code | Billy Admin Panel";


            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }
            
            if (id == 0 || id < 0)
            {
                Response.Redirect("coupon_code");
            }

            if (!Page.IsPostBack)
            {
                r1.DataSource = admin.DisplayUser();
                r1.DataBind();
            }
        }
        private string HttpContent(string url)
        {
            WebRequest objRequest = System.Net.HttpWebRequest.Create(url);
            StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream());
            string result = sr.ReadToEnd();
            sr.Close();
            return result;
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            

            string emailHtml = HttpContent("https://localhost:44350/email_body/coupon.aspx?id="+id+"");
            string value = "";
            foreach (RepeaterItem item in r1.Items)
            {
                var checkbox = item.FindControl("rbt_details") as CheckBox;
                if (checkbox.Checked)
                {
                    //value += checkbox.Text + ",";
                    value += function.sendEmail(checkbox.Text, emailHtml , "Coupon Code") + " , ";

                }
            }
            lblMessage.Text = "<b>" + value + "</b>";

        }
    }
}