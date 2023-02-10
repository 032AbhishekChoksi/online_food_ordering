using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace online_food_ordering
{
    public class ClassFunction
    {
        private CustomerBL customerBL = new CustomerBL();
        private Dish_CartBL dish_CartBL = new Dish_CartBL();
        private Dish_DetailsBL dish_DetailsBL = new Dish_DetailsBL();
        string message = string.Empty;
        public String sendEmail(string email, string html, string subject)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("SENDER EMAIL ID", "APP PASSWORD");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = subject;
            msg.Body = html;
            msg.IsBodyHtml = true;
            string toaddress = email;
            msg.To.Add(toaddress);
            string fromaddress = "Billy Admin <SENDER EMAIL ID>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);
                message = "email sent to " + email;

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
            return message;
        }
        public string SecurePassword(string password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
        // getUserFullCart()
        public Dictionary<int, Dictionary<string, string>> getUserFullCart()
        {
            var cartArr = new Dictionary<int, Dictionary<string, string>>();

            int uid = Convert.ToInt32(HttpContext.Current.Session["FOOD_USER_ID"]);
            if (HttpContext.Current.Session["FOOD_USER_ID"] != null)
            {
                Customer customer = new Customer();
                customer.SetId(uid);
                foreach (DataRow dr in dish_CartBL.DisplayDishCartByUid(customer).Rows)
                {
                    int dish_detail_id = Convert.ToInt32(dr["dish_detail_id"]);
                    var arr1 = new Dictionary<string, string>();
                    arr1.Add("qty", dr["qty"].ToString());

                    Dish_Details dish_Details = new Dish_Details();
                    dish_Details.SetId(dish_detail_id);
                    foreach (DataRow getDishDetailById in dish_DetailsBL.DisplayDishAndDishDetailsByDDId(dish_Details).Rows)
                    {
                        arr1.Add("price", getDishDetailById["dishPrice"].ToString());
                        arr1.Add("dish", getDishDetailById["dishName"].ToString());
                        arr1.Add("image", getDishDetailById["dishImage"].ToString());
                    }
                    cartArr.Add(dish_detail_id, arr1);
                }
            }
            else
            {
                if (HttpContext.Current.Session["cart"] != null)
                {
                    if (((Dictionary<int, Dictionary<string, string>>)HttpContext.Current.Session["cart"]).Count > 0)
                    {
                        var sessionAtrr = (Dictionary<int, Dictionary<string, string>>)HttpContext.Current.Session["cart"];
                        foreach (int key in sessionAtrr.Keys)
                        {
                            var arr1 = new Dictionary<string, string>();
                            arr1.Add("qty", sessionAtrr[key]["qty"].ToString());

                            Dish_Details dish_Details = new Dish_Details();
                            dish_Details.SetId(key);
                            foreach (DataRow getDishDetailById in dish_DetailsBL.DisplayDishAndDishDetailsByDDId(dish_Details).Rows)
                            {
                                arr1.Add("price", getDishDetailById["dishPrice"].ToString());
                                arr1.Add("dish", getDishDetailById["dishName"].ToString());
                                arr1.Add("image", getDishDetailById["dishImage"].ToString());
                            }
                            cartArr.Add(key, arr1);
                        }
                    }
                }
            }
            //if(attr_id > 0)
            //{
            //    return cartArr[attr_id]["qty"];
            //}
            return cartArr;
        }
        public void manageUserCart(int uid, int qty, int attr)
        {
            int cartid = 0;
            Customer customer = new Customer();
            customer.SetId(uid);
            Dish_Details dish_Details = new Dish_Details();
            dish_Details.SetId(attr);

            if (dish_CartBL.DisplayDishDetailsByDdidAndUid(customer, dish_Details).Rows.Count > 0)
            {
                Dish_Cart dish_Cart = new Dish_Cart();
                foreach (DataRow dr in dish_CartBL.DisplayDishDetailsByDdidAndUid(customer, dish_Details).Rows)
                {
                    cartid = Convert.ToInt32(dr["id"]);
                }
                dish_Cart.SetId(cartid);
                dish_Cart.SetQty(qty);
                dish_CartBL.UpdateDishCart(dish_Cart);
            }
            else
            {
                DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                Dish_Cart dish_Cart = new Dish_Cart(uid, attr, qty, added_on);
                dish_CartBL.InsertDishCart(dish_Cart);
            }
        }
        public Int32 getcartTotalPrice()
        {
            var cartArr = getUserFullCart();
            int totalPrice = 0;
            foreach (int key in cartArr.Keys)
            {
                totalPrice = totalPrice + (Convert.ToInt32(cartArr[key]["qty"]) * Convert.ToInt32(cartArr[key]["price"]));
            }
            return totalPrice;
        }
        public void emptyCart()
        {
            if (HttpContext.Current.Session["FOOD_USER_ID"] != null)
            {
                int uid = Convert.ToInt32(HttpContext.Current.Session["FOOD_USER_ID"]);
                Customer customer = new Customer();
                customer.SetId(uid);
                dish_CartBL.DeleteDishCartByUid(customer);
            }
            else
            {
                HttpContext.Current.Session.Remove("cart");
            }
        }
        // removeDishFromCartByid(dish_Details_id)
        public void removeDishFromCartByid(int id)
        {
            if (HttpContext.Current.Session["FOOD_USER_ID"] != null)
            {
                int uid = Convert.ToInt32(HttpContext.Current.Session["FOOD_USER_ID"]);
                Customer customer = new Customer();
                customer.SetId(uid);
                Dish_Details dish_Details = new Dish_Details();
                dish_Details.SetId(id);
                dish_CartBL.DeleteDishCartByDdidAndUid(dish_Details, customer);
            }
            else
            {
                // unset($_SESSION['cart'][$id]);
                if (HttpContext.Current.Session["cart"] != null)
                {
                    var cartArr = (Dictionary<int, Dictionary<string, string>>)HttpContext.Current.Session["cart"];
                    HttpContext.Current.Session.Remove("cart");
                    if (cartArr.Count > 0)
                    {
                        foreach (int key in cartArr.Keys)
                        {
                            if (key.Equals(id))
                            {
                                cartArr.Remove(key);
                                break;
                            }
                        }
                    }
                    if (cartArr.Count > 0)
                    {
                        HttpContext.Current.Session["cart"] = cartArr;
                    }
                    else
                    {
                        HttpContext.Current.Session.Remove("cart");
                    }
                }
            }
        }
        // getUserDetailsByid()
        public Dictionary<string, string> getUserDetailsByid(Customer customer)
        {
            int uid = 0;
            Dictionary<string, string> data = new Dictionary<string, string>();
            if (HttpContext.Current.Session["FOOD_USER_ID"] != null)
            {
                uid = Convert.ToInt32(HttpContext.Current.Session["FOOD_USER_ID"]);
                customer.SetId(uid);
            }
            else
            {
                uid = customer.GetId();
            }
            if (uid > 0)
            {
                if (customerBL.DisplayCustomerByCid(customer).Rows.Count > 0)
                {
                    foreach (DataRow dr in customerBL.DisplayCustomerByCid(customer).Rows)
                    {
                        data.Add("name", dr["name"].ToString());
                        data.Add("email", dr["email"].ToString());
                        data.Add("mobile", dr["mobile"].ToString());
                        data.Add("referral_code", dr["referral_code"].ToString());
                    }
                }
            }
            return data;
        }
    }
}