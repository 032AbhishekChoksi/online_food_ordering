using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class update_profile : System.Web.UI.Page
    {
        private CustomerBL customerBL;
        private Customer customer;
        private ClassFunction fun;
        protected void Page_Init(object sender, EventArgs e)
        {           
            customerBL = new CustomerBL();
            fun = new ClassFunction();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int cid = 0;
            var js = new JavaScriptSerializer();
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            else
            {
                cid = Convert.ToInt32(Session["FOOD_USER_ID"]);
            }
            string type = string.Empty;
            
            if (Request.Form["type"] != null)
            {
                type = Request.Form["type"].ToString();
            }

            if (type.Equals("profile"))
            {
                string name = Request.Form["name"].ToString();
                long mobile = Convert.ToInt64(Request.Form["mobile"]);
                Session.Remove("FOOD_USER_NAME");
                Session["FOOD_USER_NAME"] = name;

                customer = new Customer();
                customer.SetId(cid);
                customer.SetName(name);
                customer.SetMobile(mobile);

                // Udpate User Details
                int check = 0;
                check = customerBL.UpdateCustomer(customer);

                string json = null;
                if (check > 0)
                {
                    //response in json
                    json = js.Serialize(new { status = "success", msg = "The Profile has been updated" });
                }
                else
                {
                    json = js.Serialize(new { status = "error", msg = "The Profile has not been updated!" });
                }
                // Send Ressponse in json_encode format
                Context.Response.Write(js.Serialize(json));
            }
            if (type.Equals("password"))
            {
                string old_password = Request.Form["old_password"].ToString();
                string new_password = Request.Form["new_password"].ToString();
                string json = null;
                string oldhashpassaword = fun.SecurePassword(old_password);
                
                int check = 0;
                customer = new Customer();
                customer.SetPassword(oldhashpassaword);
                check = customerBL.DisplayCustomerByPassword(customer).Rows.Count;
                if(check > 0)
                { 
                    string dbpassword = string.Empty;
                    customer = new Customer();
                    customer.SetId(cid);
                    foreach (DataRow dr in customerBL.DisplayCustomerByCid(customer).Rows)
                    {
                        dbpassword = dr["password"].ToString();
                    }
                    if (oldhashpassaword.Equals(dbpassword))
                    {
                        string newhashpassaword = fun.SecurePassword(new_password);
                        customer = new Customer();
                        customer.SetId(cid);
                        customer.SetPassword(newhashpassaword);
                        if(customerBL.UpdateCustomerPasswordById(customer) > 0)
                        {
                            json = js.Serialize(new { status = "success", msg = "The Profile has been updated" });
                        }
                        else
                        {
                            json = js.Serialize(new { status = "error", msg = "Please Enter Correct Password!" });
                        }
                    }
                }
                else
                {
                    json = js.Serialize(new { status = "error", msg = "Please Enter Correct Password!" });
                }
                
                // Send Ressponse in json_encode format
                Context.Response.Write(js.Serialize(json));
            }
        }
    }
}