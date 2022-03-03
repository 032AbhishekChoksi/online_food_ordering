using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class profile : System.Web.UI.Page
    {
        protected Dictionary<string, string> getUserDetailsByid;
        private ClassFunction objFunction;
        private Customer customer;
        protected void Page_Init(object sender, EventArgs e)
        {
            objFunction = new ClassFunction();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Profile | Billy";
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
            customer = new Customer();
            customer.SetId(uid);
            getUserDetailsByid = objFunction.getUserDetailsByid(customer);
        }
    }
}