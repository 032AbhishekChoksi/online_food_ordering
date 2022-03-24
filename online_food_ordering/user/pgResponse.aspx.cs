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
    public partial class pgResponse : System.Web.UI.Page
    {
        private static readonly string PAYTM_MERCHANT_KEY = "rKFy9v9vGjp7ajt5";  //Change this constant's value with Merchant key received from Paytm.
        private Dictionary<string, string> paramList = new Dictionary<string, string>();
        private ClassUser objUser;
        private CustomerBL customerBL;
        private Order_MasterBL order_MasterBL;
        
        protected void Page_Init(object sender, EventArgs e)
        {
            objUser = new ClassUser();
            customerBL = new CustomerBL();
            order_MasterBL = new Order_MasterBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string paytmChecksum = string.Empty;
            //foreach(string key in Request.Form.Keys)
            //{
            //    paramList.Add(key.Trim(), Request.Form[key].Trim());
            //}
            //if (paramList.ContainsKey("CHECKSUMHASH"))
            //{
            //    paytmChecksum = paramList["CHECKSUMHASH"];
            //    paramList.Remove("CHECKSUMHASH");
            //}
            foreach (string key in Request.Form.Keys)
            {
                if (key.Equals("CHECKSUMHASH"))
                {
                    paytmChecksum = Request.Form[key];
                }
                else
                {
                    paramList.Add(key.Trim(), Request.Form[key].Trim());
                }
            }
            string oid = paramList["ORDERID"];
            Session["ORDER_ID"] = oid;
            
            string[] oArr = oid.Split('_');
            string ORDER_ID = oArr[1];
            int uid = Convert.ToInt32(oArr[2]);
            Order_Master order_Master = new Order_Master();
            order_Master.SetId(Convert.ToInt32(ORDER_ID));
            if(Session["FOOD_USER_ID"] == null)
            {
                Customer  customer = new Customer();
                customer.SetId(uid);
                foreach (DataRow dr in customerBL.DisplayCustomerByCid(customer) .Rows)
                {
                    Session["FOOD_USER_ID"] = uid;
                    Session["FOOD_USER_NAME"] = dr["name"].ToString();
                    Session["FOOD_USER_EMAIL"] = dr["email"].ToString();
                }
            }
            bool isValidChecksum = Paytm.Checksum.verifySignature(paramList, PAYTM_MERCHANT_KEY, paytmChecksum);
            string TXNID = paramList["TXNID"];
            if (isValidChecksum)
            {
                if (paramList["STATUS"].Equals("TXN_SUCCESS"))
                {
                    decimal amt = Convert.ToDecimal(paramList["TXNAMOUNT"]);

                    if (Session["IS_WALLET"] != null)
                    {
                        DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        objUser.manageWallet(uid, amt, "Added", "in", TXNID, added_on);
                        Session.Remove("IS_WALLET");
                        Response.Redirect("wallet");
                    }
                    else
                    {
                        string useremail = Session["FOOD_USER_EMAIL"].ToString();
                        

                        // Update Order Status
                        order_Master.SetPaymentStatus("success");
                        order_Master.SetPaymentId(TXNID);
                        order_MasterBL.UpdateOrderMasterPaymentStatusById(order_Master);
                        //Send Order
                        Response.Redirect("success");
                    }
                }
                else
                {
                    // Update Order Status
                    order_Master.SetPaymentStatus("failed");
                    order_Master.SetPaymentId(TXNID);
                    order_MasterBL.UpdateOrderMasterPaymentStatusById(order_Master);
                    //Send Order
                    Response.Redirect("error");
                }
            }
            else
            {
                // Update Order Status
                order_Master.SetPaymentStatus("failed");
                order_Master.SetPaymentId(TXNID);
                order_MasterBL.UpdateOrderMasterPaymentStatusById(order_Master);
                //Send Order
                Response.Redirect("error");
            }
        }
    }
}