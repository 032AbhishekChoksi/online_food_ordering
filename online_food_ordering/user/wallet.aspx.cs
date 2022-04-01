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
    public partial class wallet : System.Web.UI.Page
    {
        private WalletBL walletBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            walletBL = new WalletBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Wallet | Billy";
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            FillRecord();
        }
        private void FillRecord()
        {
            Customer customer = new Customer();
            customer.SetId(Convert.ToInt32(Session["FOOD_USER_ID"]));
            r1.DataSource = walletBL.DisplayWalletDetailsByUid(customer);
            r1.DataBind();
        }
        protected double FormatAmount(Object amt)
        {
            return Convert.ToDouble(amt.ToString());
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            
            if(!string.IsNullOrEmpty(txtamt.Text.ToString()))
            {
                decimal amt = Convert.ToDecimal(txtamt.Text.ToString());
                if(amt > 0)
                { 
                    string paytm_oid = "ORDS_" + "ISWALLET" + "_" + Session["FOOD_USER_ID"].ToString() + "_" + ClassRandom.GetRandomPassword(3);
                
                    // PayTM Payment Gateway
                    string outputHTML = "<form id='f1' runat='server' method='post' action='pgRedirect' name='frmPayment' style='display:none;'>";
                    outputHTML += "<input type='text' tabindex = '1' maxlength = '20' size = '20' name = 'ORDER_ID' autocomplete = 'off' value='" + paytm_oid + "'>";
                    outputHTML += "<input id = 'CUST_ID' tabindex = '2' maxlength = '12' size = '12' name = 'CUST_ID' autocomplete = 'off' value='" + Session["FOOD_USER_ID"] + "' />";
                    outputHTML += "<input id = 'INDUSTRY_TYPE_ID' tabindex = '4' maxlength = '12' size = '12' name = 'INDUSTRY_TYPE_ID' autocomplete = 'off' value='Retail' />";
                    outputHTML += "<input id = 'CHANNEL_ID' tabindex = '4' maxlength = '12' size = '12' name = 'CHANNEL_ID'' autocomplete = 'off' value='WEB' />";
                    outputHTML += "<input title = 'TXN_AMOUNT' tabindex = '10'	type = 'text' name = 'TXN_AMOUNT' value='" + amt + "' />";
                    outputHTML += "<input value = 'CheckOut' type = 'submit'  onclick='' />";
                    outputHTML += "</form>";
                    outputHTML += "<script type='text/javascript'>";
                    outputHTML += "document.frmPayment.submit();";
                    outputHTML += "</script>";

                    //Response.Write("<script>alert('Print HTML')</script>");
                    Response.Write(outputHTML);
                }
                else
                {
                    lblMessage.Text = "Please enter valid amount";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please enter valid amount";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}