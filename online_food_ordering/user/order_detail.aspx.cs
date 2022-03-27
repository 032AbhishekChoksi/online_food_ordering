using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class order_detail : System.Web.UI.Page
    {
        private int oid = 0;
        protected Dictionary<string, string> getOrderById;
        private Order_MasterBL order_MasterBL;
        protected Dictionary<int, Dictionary<string, string>> getOrderDetails;
        private Order_DetailBL order_DetailBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
            order_DetailBL = new Order_DetailBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Order Details | Billy";
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            if (Request.QueryString["id"] != null)
            {
                oid = Convert.ToInt32(Request.QueryString["id"]);
                
                Order_Master order_Master = new Order_Master();
                order_Master.SetId(oid);
                getOrderById = order_MasterBL.GetOrderByIdFunction(order_Master);

                if(Convert.ToInt32(getOrderById["user_id"]) != Convert.ToInt32(Session["FOOD_USER_ID"]))
                {
                    Response.Redirect("shop");
                }
            }
            else
            {
                Response.Redirect("shop");
            }
           
            Order_Master orderMaster = new Order_Master();
            orderMaster.SetId(oid);
            getOrderDetails = order_DetailBL.getOrderDetails(orderMaster);
        }
    }
}