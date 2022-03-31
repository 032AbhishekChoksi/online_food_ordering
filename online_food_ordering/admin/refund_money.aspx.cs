using online_food_ordering.bussinesslogic;
using online_food_ordering.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class refund_money : System.Web.UI.Page
    {
        private ClassUser objUser;
        private RefundMoneyBL refundMoneyBL;
        protected void Page_Init(object sender, EventArgs e) {
            objUser = new ClassUser();
            refundMoneyBL = new RefundMoneyBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Refund Money | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            FillRecords();
        }
        private void FillRecords()
        {
            r1.DataSource = refundMoneyBL.DisplayRefundDetails();
            r1.DataBind();
        }
        protected Decimal getWalletAmt(object uid)
        {
            return objUser.getWalletAmt(Convert.ToInt32(uid));
        }
    }
}