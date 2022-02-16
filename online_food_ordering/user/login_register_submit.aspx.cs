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
            string type = string.Empty;
            var js = new JavaScriptSerializer();
            if(Request.Form["type"] != null) {
                type = Request.Form["type"].ToString();
            }
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            if (type.Equals("register"))
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
                        string hashpassaword = fun.SecurePassword(password);
                        // Insert record in Customer Table
                        lastinsertedid = user.InsertUser(name, email, mobile, hashpassaword, 1, 0, rand_str, referral_code, from_referral_code, added_on);

                        // Get Amount in Wallet For First Time User Registration
                        decimal wallet_amt = 0;
                        foreach (DataRow dr in user.getSetting(1).Rows)
                        {
                            wallet_amt = Convert.ToDecimal(dr["wallet_amt"]);
                        }
                        if(wallet_amt > 0)
                        {
                            user.manageWallet(lastinsertedid, wallet_amt, "Register", "in",String.Empty,added_on);
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

            if (type.Equals("login"))
            {
                string email = Request.Form["user_email"].ToString();
                string password = Request.Form["user_password"].ToString();
                string json = null;
                int check = user.DisplayUserByEmail(email).Rows.Count;

                if (check > 0)
                {
                    foreach (DataRow dr in user.DisplayUserByEmail(email).Rows)
                    {
                        byte status = Convert.ToByte(dr["status"]);
                        byte email_verify = Convert.ToByte(dr["email_verify"]);
                        string dbpassword = dr["password"].ToString();
                        if(email_verify == 1)
                        {
                            if(status == 1)
                            {
                                string hpassword = fun.SecurePassword(password);
                                if (dbpassword.Equals(hpassword))
                                {
                                    hpassword = "";
                                    Session["FOOD_USER_ID"] = Convert.ToInt32(dr["id"]);
                                    Session["FOOD_USER_NAME"] = dr["name"].ToString();
                                    Session["FOOD_USER_EMAIL"] = dr["email"].ToString();
                                    json = js.Serialize(new { status = "success", msg = "" });
                                }
                                else
                                {
                                    json = js.Serialize(new { status = "error", msg = "Please enter correct password" });
                                }
                            }
                            else
                            {
                                json = js.Serialize(new { status = "error", msg = "Your account has been deactivated" });
                            }
                        }
                        else
                        {
                            json = js.Serialize(new { status = "error", msg = "Please verify your email id" });
                        }
                    }
                }
                else
                {
                    json = js.Serialize(new { status = "error", msg = "Please enter valid email id" });
                }
                Context.Response.Write(js.Serialize(json));
            }
            // Google Authenticatio
            if (type.Equals("Google"))
            {
                string name = Request.Form["name"].ToString();
                string email = Request.Form["email"].ToString();
                string hashpassaword = fun.SecurePassword(email);
                long mobile = Convert.ToInt64(ClassRandom.GetRandomMobile(10));
                string json = null;
                int check = user.DisplayUserByEmail(email).Rows.Count;
                if (check > 0)
                {
                    foreach (DataRow dr in user.DisplayUserByEmail(email).Rows)
                    {
                        Session["FOOD_USER_ID"] = Convert.ToInt32(dr["id"]);
                        Session["FOOD_USER_NAME"] = dr["name"].ToString();
                        Session["FOOD_USER_EMAIL"] = dr["email"].ToString();
                    }
                }
                else
                {
                    string rand_str = ClassRandom.GetRandomPassword(20);
                    string referral_code = ClassRandom.GetRandomPassword(20);
                    string from_referral_code = String.Empty;
                    // Insert record in Customer Table
                    lastinsertedid = user.InsertUser(name, email, mobile, hashpassaword, 1, 1, rand_str, referral_code, from_referral_code, added_on);

                    // Get Amount in Wallet For First Time User Registration
                    decimal wallet_amt = 0;
                    foreach (DataRow dr in user.getSetting(1).Rows)
                    {
                        wallet_amt = Convert.ToDecimal(dr["wallet_amt"]);
                    }
                    if (wallet_amt > 0)
                    {
                        user.manageWallet(lastinsertedid, wallet_amt, "Register", "in", String.Empty, added_on);
                    }

                    // Send Mail Logic below

                    //Login
                    if (lastinsertedid > 0) { 
                   
                        Session["FOOD_USER_ID"] = lastinsertedid;
                        Session["FOOD_USER_NAME"] = name;
                        Session["FOOD_USER_EMAIL"] = email;
                    }
                }
                json = js.Serialize(new { status = "success" });
                Context.Response.Write(js.Serialize(json));
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