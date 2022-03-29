using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.deliveryboy
{
    public partial class index : System.Web.UI.Page
    {
        private Order_MasterBL order_MasterBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Index | Billy Delivery Boy Panel";
            if (Session["DELIVERY_BOY_USER_LOGIN"] == null)
            {
                Response.Redirect("login");
            }
            if (!this.Page.IsPostBack)
            { 
                FillRecords();
            }
            if (Request.QueryString["set_payment"] != null)
            {
                Order_Master order_Master = new Order_Master();
                order_Master.SetId(Convert.ToInt32(Request.QueryString["set_payment"].ToString()));
                order_Master.SetPaymentStatus("success");
                order_Master.SetDeliveryBoyId(Convert.ToInt32(Session["DELIVERY_BOY_ID"].ToString()));

                order_MasterBL.UpdatePaymentStatusByOIdAndDid(order_Master);
                Response.Redirect("index");
            }
            if(Request.QueryString["set_order_id"] != null)
            {
                Order_Master order_Master = new Order_Master();
                order_Master.SetId(Convert.ToInt32(Request.QueryString["set_order_id"].ToString()));
                order_Master.SetOrderStatus(4);
                order_Master.SetDeliveredOn(DateTime.Now);
                order_Master.SetDeliveryBoyId(Convert.ToInt32(Session["DELIVERY_BOY_ID"].ToString()));

                order_MasterBL.UpdateOrderStatusByOIdAndDid(order_Master);
                Response.Redirect("index");
            }
        }
        public string ucfirst(Object payment_status)
        {
            string s = payment_status.ToString();
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        private void FillRecords()
        {
            lblDELIVERY_BOY_USER.Text = Session["DELIVERY_BOY_USER"].ToString();

            Delivery_Boy delivery_Boy = new Delivery_Boy();
            delivery_Boy.SetId(Convert.ToInt32(Session["DELIVERY_BOY_ID"].ToString()));
            DataTable dt = order_MasterBL.DisplayOrderDeliveryByDeliveryBoyId(delivery_Boy);
            r1.DataSource = dt;
            r1.DataBind();
        }
    }
}