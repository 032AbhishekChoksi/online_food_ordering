using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering
{
    public partial class Test : System.Web.UI.Page
    {
        ClassFunction fun = new ClassFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = "19bmiit032@gmail.com";
            //string cdate = DateTime.Now.Year.ToString();
            //string html = emailpasswordbody(cdate);
            //fun.sendEmail(email, html, "Welcome To Billy");

            if (Session["cart"] != null)
            {
                var cartarr = (Dictionary<int, Dictionary<string, string>>)Session["cart"];
                if (cartarr.Count > 0)
                {
                    var result = cartarr[12]["qty"];
                }
            }
        }
        //private string emailpasswordbody(string currentyear)
        //{
        //    string body = string.Empty;
        //    using (StreamReader reader = new StreamReader(@"D:\project\online_food_ordering\online_food_ordering\email_body\emailpassword.html"))
        //    {
        //        body = reader.ReadToEnd();
        //    }
        //    body = body.Replace("{currentyear}", currentyear);

        //    return body;
        //}
    }
}