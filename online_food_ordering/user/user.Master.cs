using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class user : System.Web.UI.MasterPage
    {
        private ClassFunction classFunction;
        private ClassUser objUser;
        // Fronted Access Variable
        protected Dictionary<int, Dictionary<string, string>> cartArr;
        protected Int32 totalPrice;
        protected Int32 totalCartDish;
        protected void Page_Init(object sender, EventArgs e)
        {
            classFunction = new ClassFunction();
            objUser = new ClassUser();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cartArr = classFunction.getUserFullCart();
            totalPrice = classFunction.getcartTotalPrice();
            totalCartDish = cartArr.Count;
            decimal amt = 0;
            if (Session["FOOD_USER_NAME"] != null)
            {
                int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
                amt= objUser.getWalletAmt(Convert.ToInt32(uid));
                lblUsreName.Text = Session["FOOD_USER_NAME"].ToString();
            }
            lblWalletAmount.Text = "₹" + Math.Round(amt).ToString();
        }
    }
}