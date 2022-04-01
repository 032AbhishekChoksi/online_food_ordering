using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class contact_us_submit : System.Web.UI.Page
    {
        private DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        private Contact_UsBL contact_UsBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            contact_UsBL = new Contact_UsBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = string.Empty;
            var js = new JavaScriptSerializer();
            if (Request.Form["type"] != null)
            {
                type = Request.Form["type"].ToString();
            }
            if (type.Equals("contactus"))
            {
                string name = Request.Form["cname"].ToString();
                string email = Request.Form["cemail"].ToString();
                long mobile = Convert.ToInt64(Request.Form["cmobile"]);
                string subject = Request.Form["csubject"].ToString();
                string message = Request.Form["cmessage"].ToString();

                Contact_Us contact_Us = new Contact_Us(name,email,mobile,subject,message,added_on,1);
                string json = null;
                
                int check = contact_UsBL.InserContactUs(contact_Us);
                if (check > 0)
                {
                    json = js.Serialize(new { status = "success", msg = "Thank you for connecting with us, will get back to you shortly.", field = "form_msg" });
                }
                else
                {
                    json = js.Serialize(new { status = "error", msg = "Some Thing is Worng! Please Try Again", field = "form_msg" });
                }
                // Send Ressponse in json_encode format
                Context.Response.Write(js.Serialize(json));
            }
        }
    }
}