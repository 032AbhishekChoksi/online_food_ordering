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
            smtp.Credentials = new System.Net.NetworkCredential("EMAIL ID", "PASSWORD");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = subject;
            msg.Body = html;
            msg.IsBodyHtml = true;
            string toaddress = email;
            msg.To.Add(toaddress);
            string fromaddress = "Billy Admin <EMAIL ID>";
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
    }
}