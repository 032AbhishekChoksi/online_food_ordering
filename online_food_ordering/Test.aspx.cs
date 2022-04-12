using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
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
            //RatingBL ratingBL = new RatingBL();
            //Dish dish = new Dish();
            //dish.SetId(6);
            //ratingBL.getRatingByDishId(dish);

            //Order_Master order_Master = new Order_Master();
            //Order_MasterBL order_MasterBL = new Order_MasterBL();
            //order_Master.SetUserId(16);
            //order_Master.SetOrderStatus(4);
            //order_MasterBL.DisplayTotalOrderByUidAndOStatus(order_Master);

            // Response.Redirect("https://localhost:44350/email_body/orderemail.aspx?id=" + 19 + "&oid=" + 1016);
            //if (Request.Form["btnSubmit"] != null)
            //{
            //    string name = Request.Form["fname"].ToString();
            //}
            //string email = "19bmiit032@gmail.com";
            //string cdate = DateTime.Now.Year.ToString();
            //string html = emailpasswordbody(cdate);
            //fun.sendEmail(email, html, "Welcome To Billy");

            //if (Session["cart"] != null)
            //{
            //    var cartarr = (Dictionary<int, Dictionary<string, string>>)Session["cart"];
            //    if (cartarr.Count > 0)
            //    {
            //        var result = cartarr[12]["qty"];
            //    }
            //}
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
        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    string name = Request.Form["fname"].ToString();
        //}
    }
}