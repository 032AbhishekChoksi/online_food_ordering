using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using online_food_ordering.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class add_money : System.Web.UI.Page
    {
        private int uid = 0;
        private int oid = 0;
        private decimal amt = 0;
        private RefundMoneyBL refundMoneyBL;
        private ClassUser objUser;
        protected void Page_Init(object sender, EventArgs e)
        {
            refundMoneyBL = new RefundMoneyBL();
            objUser = new ClassUser();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Send Money | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if (Request.QueryString["uid"] != null)
            {
                uid = Convert.ToInt32(Request.QueryString["uid"]);
                FillRecords(uid);
            }

            if(Request.QueryString["oid"] != null && Request.QueryString["amt"] != null)
            {
                oid = Convert.ToInt32(Request.QueryString["oid"]);
                amt = Convert.ToDecimal(Request.QueryString["amt"]);
                SendMoney(oid,amt);
            }
        }
        private void FillRecords(int p_uid)
        {
            if(p_uid > 0)
            {
                Customer customer = new Customer();
                customer.SetId(p_uid);
                r1.DataSource = refundMoneyBL.DisplaySendMoney(customer);
                r1.DataBind();

                Session["ruid"] = p_uid;
              
            }
           
        }
        private void SendMoney(int p_oid, decimal p_amt)
        {
            if(p_oid > 0 && p_amt > 0)
            {
                if (Session["ruid"] != null)
                {
                    uid = Convert.ToInt32(Session["ruid"]);
                    objUser.manageWallet(uid, p_amt, "Refund Amount", "in", "", DateTime.Now.Date);
                    Order_Master order_Master = new Order_Master();
                    order_Master.SetRefundStatus(0);
                    order_Master.SetId(p_oid);
                    order_Master.SetUserId(uid);

                    refundMoneyBL.UpdateRefundStatus(order_Master);

                    Session.Remove("ruid");
                    Response.Redirect("add_money.aspx?uid="+uid);
                }
            }
        }
        protected double FormatAmount(Object amt)
        {
            return Convert.ToDouble(amt.ToString());
        }

    }
}