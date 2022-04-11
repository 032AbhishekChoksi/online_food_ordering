using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class updaterating : System.Web.UI.Page
    {
        private RatingBL ratingBL;
        private DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        protected void Page_Init(object sender, EventArgs e)
        {
            ratingBL = new RatingBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            var js = new JavaScriptSerializer();
            int rate = 0;
            if (Request.Form["rate"] != null)
            {
                rate = Convert.ToInt32(Request.Form["rate"]);
                int id = Convert.ToInt32(Request.Form["id"]);
                int order_id = Convert.ToInt32(Request.Form["oid"]);
                int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);

                Rating rating = new Rating(uid, order_id, id, rate, added_on);
                int result = ratingBL.InsertRating(rating);

                string json = string.Empty;
                if(result > 0)
                {
                    json = js.Serialize(new { status = "success", msg = "Insert Ratting Successfully." });
                }
                else
                {
                    json = js.Serialize(new { status = "error", msg = "Ratting Insertion Fail!" });
                }
                // Send Ressponse in json_encode format
                Context.Response.Write(js.Serialize(json));
            }
        }
    }
}