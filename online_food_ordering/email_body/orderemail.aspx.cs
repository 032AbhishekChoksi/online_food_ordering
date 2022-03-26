using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.email_body
{
    public partial class orderemail : System.Web.UI.Page
    {
        protected Dictionary<string, string> getUserDetailsByid;
        protected Dictionary<string, string> getOrderById;
        protected Dictionary<int, Dictionary<string, string>> getOrderDetails;
        protected string customername = string.Empty;
        private string customeremail = string.Empty;
        protected decimal total_amount = 0;
        protected int order_id = 0;
        private ClassFunction objFunction;
        private Customer customer;
        private int uid = 0;
        private int oid = 0;
        private Order_MasterBL order_MasterBL;
        private Order_DetailBL order_DetailBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            objFunction = new ClassFunction();
            order_MasterBL = new Order_MasterBL();
            order_DetailBL = new Order_DetailBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Request.QueryString["id"] != null && Request.QueryString["oid"] != null)
            {
                uid = Convert.ToInt32(Request.QueryString["id"]);
                oid = Convert.ToInt32(Request.QueryString["oid"]);
            }

            if (uid > 0 || uid == null)
            {
                customer = new Customer();
                customer.SetId(uid);
            }
            else
            {
                customer = new Customer();
            }
           
            getUserDetailsByid = objFunction.getUserDetailsByid(customer);
            customername = getUserDetailsByid["name"];
            customeremail = getUserDetailsByid["email"];

            Order_Master order_Master = new Order_Master();
            order_Master.SetId(oid);
            getOrderById = order_MasterBL.GetOrderByIdFunction(order_Master);

            order_id = Convert.ToInt32(getOrderById["id"]);
            total_amount = Convert.ToDecimal(getOrderById["total_price"]);

            getOrderDetails = order_DetailBL.getOrderDetails(order_Master);
        }
    }
}