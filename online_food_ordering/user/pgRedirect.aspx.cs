using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class pgRedirect : System.Web.UI.Page
    {
        //private static readonly string PAYTM_ENVIRONMENT = "TEST";
        private static readonly string PAYTM_MERCHANT_KEY = "rKFy9v9vGjp7ajt5";  //Change this constant's value with Merchant key received from Paytm.
        private static readonly string PAYTM_MERCHANT_MID = "TYmwCE61492093834199"; //Change this constant's value with MID (Merchant ID) received from Paytm.
        private static readonly string PAYTM_MERCHANT_WEBSITE = "WEBSTAGING"; //Change this constant's value with Website name received from Paytm.
        //private static string PAYTM_STATUS_QUERY_NEW_URL = "https://securegw-stage.paytm.in/merchant-status/getTxnStatus";
        protected string PAYTM_TXN_URL = "https://securegw-stage.paytm.in/theia/processTransaction";
        protected Dictionary<string, string> paramList = new Dictionary<string, string>();
        protected string checksum = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string ORDER_ID = Request.Form["ORDER_ID"];
            string CUST_ID = Request.Form["CUST_ID"];
            string INDUSTRY_TYPE_ID = Request.Form["INDUSTRY_TYPE_ID"];
            string CHANNEL_ID = Request.Form["CHANNEL_ID"];
            decimal TXN_AMOUNT = Convert.ToDecimal(Request.Form["TXN_AMOUNT"]);

            // Create an array having all required parameters for creating checksum.
            paramList.Add("MID", PAYTM_MERCHANT_MID);
            paramList.Add("ORDER_ID", ORDER_ID);
            paramList.Add("CUST_ID", CUST_ID);
            paramList.Add("INDUSTRY_TYPE_ID", INDUSTRY_TYPE_ID);
            paramList.Add("CHANNEL_ID" , CHANNEL_ID);
            paramList.Add("TXN_AMOUNT", TXN_AMOUNT.ToString());
            paramList.Add("EMAIL", Session["FOOD_USER_EMAIL"].ToString());
            paramList.Add("VERIFIED_BY", "EMAIL");
            paramList.Add("WEBSITE", PAYTM_MERCHANT_WEBSITE);
            paramList.Add("CALLBACK_URL", "https://localhost:44350/user/pgResponse");

            //Here checksum string will return by generateSignature() function.
            checksum = Paytm.Checksum.generateSignature(paramList, PAYTM_MERCHANT_KEY);
        }
    }
}