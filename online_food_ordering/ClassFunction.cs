using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace online_food_ordering
{
    public class ClassFunction
    {
        string message = string.Empty;
        public String sendEmail(string email, string html, string subject)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("abhishekmeet032015@gmail.com", "bmiit032015");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = subject;
            msg.Body = html;
            msg.IsBodyHtml = true;
            string toaddress = email;
            msg.To.Add(toaddress);
            string fromaddress = "Billy Admin <abhishekmeet032015@gmail.com>";
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
        public string SecurePassword(string password){
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach(byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public Dictionary<int, Dictionary<string, int>> getUserFullCart(int attr_id)
        {
            var cartArr = new Dictionary<int, Dictionary<string, int>>();
            if (HttpContext.Current.Session["cart"] != null)
            {

                if (((Dictionary<int, Dictionary<string, int>>)HttpContext.Current.Session["cart"]).Count > 0)
                {
                    cartArr = (Dictionary<int, Dictionary<string, int>>)HttpContext.Current.Session["cart"];
                }
            }
            return cartArr;
        }
    }
}