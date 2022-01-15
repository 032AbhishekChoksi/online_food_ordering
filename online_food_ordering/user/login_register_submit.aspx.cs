using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class login_register_submit : System.Web.UI.Page
    {
        ClassUser user = new ClassUser();
        ClassFunction fun = new ClassFunction();
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
                int check = user.DisplayUserByEmail(email).Rows.Count;

                if (check > 0)
                {
                    json = js.Serialize(new { status = "error", msg = "Email id already registered", field = "email_error" });
                }
                else
                {
                    if (IsReCaptchValid())
                    {
                        string rand_str = ClassRandom.GetRandomPassword(20);
                        string referral_code = ClassRandom.GetRandomPassword(20);
                        string from_referral_code = "";
                        user.InsertUser(name, email, mobile, password, 0, 0, rand_str, referral_code, from_referral_code, added_on);
                        
                        string html = System.Configuration.ConfigurationManager.AppSettings["FRONT_SITE_PATH"] + "verify?id=" + rand_str;
                        fun.sendEmail(email, html, "Verify your Email ID");
                        json = js.Serialize(new { status = "success", msg = "Thank you for register. Please check your email id, to verify your account", field = "form_msg" });
                    }
                    else
                    {
                        json = js.Serialize(new { status = "error", msg = "captcha failed, please try again later", field = "form_msg" });
                    }
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
        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LdoQi8dAAAAAAYEO0HTbRSN77FH8XCqCcRs4dII";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}