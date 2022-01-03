using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class login_register_submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var js = new JavaScriptSerializer();
            string type = Request.Form["type"].ToString();
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            if (type == "register")
            {
                string name = Request.Form["name"].ToString();
                string email = Request.Form["email"].ToString();
                string password = Request.Form["password"].ToString();
                long mobile = Convert.ToInt64(Request.Form["mobile"]);
                string json = null;
                int check = 0;

                if (check > 0)
                {
                    json = js.Serialize(new { status = "error", msg = "Email id already registered", field = "email_error" });
                }
                else
                {
                    json = js.Serialize(new { status = "success", msg = "Thank you for register. Please check your email id, to verify your account", field = "form_msg" });
                }
                Context.Response.Write(js.Serialize(json));
            }

            if (type == "login")
            {
                string email = Request.Form["user_email"].ToString();
                string password = Request.Form["user_password"].ToString();
                string json = null;
                int check = 0;

                if (check > 0)
                {
                    json = js.Serialize(new { status = "error", msg = "Email id already registered" });
                }
                else
                {
                    json = js.Serialize(new { status = "success", msg = "" });
                }
                Context.Response.Write(js.Serialize(json).Replace("\"{", "'{").Replace("}\"", "}'"));
            }
        }
    }
}