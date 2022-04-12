﻿using Newtonsoft.Json.Linq;
using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
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
        private CustomerBL customerBL;
        private ClassUser user = new ClassUser();
        private ClassFunction fun = new ClassFunction();
        private int lastinsertedid = 0;
        private DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        protected void Page_Init(object sender, EventArgs e)
        {
            customerBL = new CustomerBL();
        }
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

                        if(Session["FROM_REFERRAL_CODE"] != null)
                        {
                            from_referral_code = Session["FROM_REFERRAL_CODE"].ToString();
                            Session.Remove("FROM_REFERRAL_CODE");
                        }

                        // Insert record in Customer Table
                        Customer customer = new Customer(name, email, mobile, hashpassaword, 1, 0, rand_str, referral_code, from_referral_code, added_on);
                        lastinsertedid = customerBL.InsertCustomer(customer);
                        //lastinsertedid = user.InsertUser(name, email, mobile, hashpassaword, 1, 0, rand_str, referral_code, from_referral_code, added_on);

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
                // Send Ressponse in json_encode format
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
                                    if (Session["cart"] != null)
                                    {
                                        if(((Dictionary<int, Dictionary<string, string>>)Session["cart"]).Count > 0)
                                        {
                                            var cartArr = (Dictionary<int, Dictionary<string, string>>)Session["cart"];
                                            foreach (int key in cartArr.Keys)
                                            {
                                                int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
                                                int qty = Convert.ToInt32(cartArr[key]["qty"]);
                                                fun.manageUserCart(uid, qty, key);
                                            }
                                        }
                                        Session.Remove("cart");
                                    }
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
                // Send Ressponse in json_encode format
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
                    Customer customer = new Customer(name, email, mobile, hashpassaword, 1, 0, rand_str, referral_code, from_referral_code, added_on);
                    lastinsertedid = customerBL.InsertCustomer(customer);
                    // lastinsertedid = user.InsertUser(name, email, mobile, hashpassaword, 1, 1, rand_str, referral_code, from_referral_code, added_on);

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
                    string cdate = DateTime.Now.Year.ToString();
                    string html = emailpasswordbody(cdate);
                    fun.sendEmail(email, html, "Welcome To Billy");
                    
                    // Login
                    if (lastinsertedid > 0) { 
                   
                        Session["FOOD_USER_ID"] = lastinsertedid;
                        Session["FOOD_USER_NAME"] = name;
                        Session["FOOD_USER_EMAIL"] = email;
                    }
                }
                json = js.Serialize(new { status = "success" });
                // Send Ressponse in json_encode format
                Context.Response.Write(js.Serialize(json));
            }
            if (type.Equals("forgot"))
            {
                string json = null;
                string email = Request.Form["user_email"].ToString();
                int check = user.DisplayUserByEmail(email).Rows.Count;

                if (check > 0)
                {
                    byte status = 0;
                    byte email_verify = 0;
                    int id = 0;
                    foreach (DataRow dr in user.DisplayUserByEmail(email).Rows)
                    {
                        status = Convert.ToByte(dr["status"]);
                        email_verify = Convert.ToByte(dr["email_verify"]);
                        id = Convert.ToInt32(dr["id"].ToString());
                    }
                    if (email_verify == 1)
                    {
                        if (status == 1)
                        {
                            string rand_str = ClassRandom.GetRandomPassword(20);
                            string new_password = fun.SecurePassword(rand_str);
                            Customer customer = new Customer();
                            customer.SetId(id);
                            customer.SetPassword(new_password);
                            customerBL.UpdateCustomerPasswordById(customer);
                            string cdate = DateTime.Now.Year.ToString();

                            string html = forgotPasswordbody(rand_str, cdate);
                            fun.sendEmail(email, html, "New Password");
                            json = js.Serialize(new { status = "success", msg = "Password has been reset and send it to your Email Id" });
                        }
                        else
                        {
                            json = js.Serialize(new { status = "error", msg = "Your Account has been Deactivated" });
                        }
                    }
                    else
                    {
                        json = js.Serialize(new { status = "error", msg = "Please Verify Your Email Id" });
                    }

                }
                else
                {
                    json = js.Serialize(new { status = "error", msg = "Please Enter Valid Email Id" });
                }
               
                // Send Ressponse in json_encode format
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
        private string emailpasswordbody(string currentyear)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(@"D:\project\online_food_ordering\online_food_ordering\email_body\emailpassword.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{currentyear}", currentyear);

            return body;
        }
        private string forgotPasswordbody(string newpassword, string currentyear)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(@"D:\project\online_food_ordering\online_food_ordering\email_body\forgotpassword.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{userpassword}", newpassword);
            body = body.Replace("{currentyear}", currentyear);

            return body;
        }
    }
}