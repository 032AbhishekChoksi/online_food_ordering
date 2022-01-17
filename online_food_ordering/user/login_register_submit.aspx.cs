using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
        int lastinsertedid = 0;
        DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
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
                        string from_referral_code = String.Empty;

                        // Insert record in Customer Table
                        lastinsertedid = user.InsertUser(name, email, mobile, password, 0, 0, rand_str, referral_code, from_referral_code, added_on);

                        // Get Amount in Wallet For First Time User Registration
                        decimal wallet_amt = 0;
                        foreach (DataRow dr in user.getSetting(1).Rows)
                        {
                            wallet_amt = Convert.ToDecimal(dr["wallet_amt"]);
                        }
                        if(wallet_amt > 0)
                        {
                            user.manageWallet(lastinsertedid, wallet_amt, "in", "Register",String.Empty,added_on);
                        }

                        // Send Mail
                        string cdate = DateTime.Now.Year.ToString();
                        string rurl = System.Configuration.ConfigurationManager.AppSettings["FRONT_SITE_PATH"] + "verify.aspx?id=" + rand_str;
                        string html = emailverificationbody(rurl, cdate);
                        fun.sendEmail(email, html, "Verify your Email ID");

                        //response in json
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
        // ReCaptch Verification Method. It's return boolean value (true or false)
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
        // Email Body data replace Method. It's retun string value which content whole html with dynamic data
        private string emailverificationbody(string redirecturl, string currentyear)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(@"D:\project\online_food_ordering\online_food_ordering\email_body\emailverify.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{redirecturl}", redirecturl);
            body = body.Replace("{currentyear}", currentyear);

            return body;
        }
    }
}