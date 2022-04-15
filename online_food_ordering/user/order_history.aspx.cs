using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class order_history : System.Web.UI.Page
    {
        private Order_MasterBL order_MasterBL;
        private int uid = 0;
        private int oid = 0;
        private string paymentstatus = string.Empty;
        private Delivery_BoyBL delivery_BoyBL;
        private DataTable dt;
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
            delivery_BoyBL = new Delivery_BoyBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Order History | Billy";
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
            FillDataInRepeater(uid);

            if (Request.QueryString["order_id"] != null && Request.QueryString["payment"] != null)
            {
                oid = Convert.ToInt32(Request.QueryString["order_id"]);               
                paymentstatus = Request.QueryString["payment"].ToString();
                UpdateOrderStatus(oid, paymentstatus);
            }
        }
        private void FillDataInRepeater(int puid)
        {
            Customer customer = new Customer();
            customer.SetId(puid);
            if(order_MasterBL.DisplayOrderMasterByUserId(customer).Rows.Count > 0) { 
                r1.DataSource = order_MasterBL.DisplayOrderMasterByUserId(customer);
                r1.DataBind();
            }
            else
            {
                Response.Redirect("shop");
            }
        }
        protected String[] ApplyCoupon(object coupon_code, object final_price)
        {
            String[] result = new String[2];
            string coupon = coupon_code.ToString().Trim(' ');
            decimal final = Convert.ToDecimal(final_price.ToString());
         
            if (!string.IsNullOrEmpty(coupon))
            {
                result[0] = "Coupon Code:- " + coupon + "<br />";
                result[1] = "Final Price:- " + Math.Round((decimal)final) + " Rs.";
            }
            else
            {
                result[0] = "-";
                result[1] = "";
            }
            return result;
        }
        protected string CheckOrderStatus(object p_oid,object order_status,object payment_status)
        {
            string result = string.Empty;
            string order = order_status.ToString();
            string payment = payment_status.ToString();
            int ooid = Convert.ToInt32(p_oid);
            if (order.Equals("1"))
            {
                result += "<br/>";
                result += "<div style='margin-top:10px;'><a href='order_history.aspx?order_id="+ooid+"&payment="+payment+"' class='cancel_btn'>Cancel</a></div>";
            }
            return result;
        }
        private void UpdateOrderStatus(int p_oid, string p_paymentstatus)
        {
            Order_Master order_Master = new Order_Master();
            order_Master.SetId(p_oid);
            order_Master.SetOrderStatus(5);

            DateTime cancel_at = DateTime.Now;
            order_Master.SetCancelBy("User");
            order_Master.SetCancelAt(cancel_at);
            if (p_paymentstatus.Equals("pending"))
            {
                order_Master.SetRefundStatus(0);
            }
            else
            {
                order_Master.SetRefundStatus(1);
            }
            order_MasterBL.UpdateOrderStatusAndCancelStatusById(order_Master);
           
            Response.Redirect("order_history");
        }
        protected string DisplayDeliveryBoyDetails(object delivery_boy_id)
        {
            string html = "-";
            string deliveryBoyId = delivery_boy_id.ToString();
            if (!string.IsNullOrEmpty(deliveryBoyId))
            {
                Delivery_Boy delivery_Boy = new Delivery_Boy();
                delivery_Boy.SetId(Convert.ToInt32(deliveryBoyId));
                dt = delivery_BoyBL.DisplayDeliveyBoyById(delivery_Boy);
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        html = "<a href='https://wa.me/"+dr["mobile"].ToString()+ "?text=Hi' target='_blank' style='color:#e02c2b;font-size: 14px;font-weight: 500;'>" + dr["name"].ToString() + " ( " + dr["mobile"] + " ) " + "<a>";
                    }
                }
            }
            return html;
        }
    }
}