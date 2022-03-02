using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using online_food_ordering.user;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering
{
    public partial class checkout : System.Web.UI.Page
    {
        private ClassFunction classFunction;
        protected Dictionary<string, string> userArr;
        protected Dictionary<int, Dictionary<string, string>> cartArr;
        protected string is_show, box_id, final_show, final_box_id, is_error;
        protected string is_dis = string.Empty, low_msg = string.Empty, cart_min_price_msg = string.Empty;
        protected Int32 totalPrice;
        protected decimal final_price = 0;
        private ClassUser objUser;
        private decimal getWalletAmt = 0;
        private decimal cart_min_price = 0;
        private int uid = 0;
        private Order_MasterBL order_MasterBL;
        private Order_DetailBL order_DetailBl;
        protected int razoramt = 0;
        protected void Page_Init(object sender, EventArgs e)
        {
            classFunction = new ClassFunction();
            objUser = new ClassUser();
            order_MasterBL = new Order_MasterBL();
            order_DetailBl = new Order_DetailBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            is_error = string.Empty;
            cartArr = classFunction.getUserFullCart();
            totalPrice = classFunction.getcartTotalPrice();
            razoramt = Convert.ToInt32(totalPrice);
            Session["ORDER_ID"] = 3;
            if (cartArr.Count > 0 || cartArr != null)
            {}
            else
            {
                Response.Redirect("shop");
            }

            if(Session["FOOD_USER_ID"] != null)
            {
                uid = Convert.ToInt32(Session["FOOD_USER_ID"]);

                Customer customer = new Customer();
                customer.SetId(uid);
                userArr = classFunction.getUserDetailsByid(customer);

                is_show = string.Empty;
                box_id = string.Empty;
                final_show = "show";
                final_box_id = "payment-2";

                // Wallet 
                getWalletAmt = objUser.getWalletAmt(uid);
                if(getWalletAmt >= totalPrice)
                {}
                else
                {
                    is_dis = "disabled='disabled'";
                    low_msg = "(Low Wallet Money)";
                }
            }
            else
            {
                is_show = "show";
                box_id = "payment-1";
                final_show = string.Empty;
                final_box_id  = string.Empty;
            }
            foreach (DataRow dr in objUser.getSetting(1).Rows)
            {
                cart_min_price = Convert.ToDecimal(dr["cart_min_price"]);
                cart_min_price_msg = dr["cart_min_price_msg"].ToString();
            }

            // Button Click Event
            if(Request.Form["place_order"] != null)
            {
                if(cart_min_price > 0)
                {
                    if(totalPrice>= cart_min_price)
                    {}
                    else
                    {
                        is_error = "yes";
                    }
                }
                if (string.IsNullOrEmpty(is_error))
                {
                    //string checkout_name = Request.Form["checkout_name"];
                    string checkout_email = Request.Form["checkout_email"];
                    //long checkout_mobile = Request.Form["checkout_mobile"];
                    int checkout_zip = Convert.ToInt32(Request.Form["checkout_zip"]);
                    string checkout_address = Request.Form["checkout_address"];
                    string payment_type = Request.Form["payment_type"];
                    string coupon_code = string.Empty;
                    

                    if (Session["COUPON_CODE"] != null)
                    {
                        coupon_code = Session["COUPON_CODE"].ToString();
                        final_price = Convert.ToDecimal(Session["FINAL_PRICE"]);
                        razoramt = Convert.ToInt32(final_price);
                    }
                    else
                    {
                        coupon_code = string.Empty;
                        final_price = totalPrice;
                        razoramt = Convert.ToInt32(final_price);
                    }

                    DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    int lastinsertedid = 0;

                    Order_Master order_Master = new Order_Master();
                    order_Master.SetUserId(uid);
                    order_Master.SetAddress(checkout_address);
                    order_Master.SetZipCode(checkout_zip);
                    order_Master.SetTotalPrice(totalPrice);
                    order_Master.SetFinalPrice(final_price);
                    order_Master.SetCouponCode(coupon_code);
                    order_Master.SetOrderStatus(1);
                    order_Master.SetPaymentStatus("pending");
                    order_Master.SetPaymentType(payment_type);
                    order_Master.SetRefundStatus(0);
                    order_Master.SetAddedOn(added_on);
                    lastinsertedid = order_MasterBL.InsertOrderMaster(order_Master);

                    if (Session["ORDER_ID"] != null)
                    {
                        Session.Remove("ORDER_ID");
                    }

                    Session["ORDER_ID"] = lastinsertedid;

                    foreach (int key in cartArr.Keys)
                    {
                        Order_Detail order_Detail = new Order_Detail(lastinsertedid, key, Convert.ToInt32(cartArr[key]["qty"]));
                        order_DetailBl.InsertOrder_Detail(order_Detail);
                    }
                    classFunction.emptyCart();

                    if (payment_type.Equals("cod"))
                    {
                        // Send Email

                        Response.Redirect("success");
                    }

                    if (payment_type.Equals("wallet"))
                    {
                        // withdraw amount in wallet
                        string ttype = "Order Id- " + lastinsertedid;
                        objUser.manageWallet(uid, final_price, ttype, "out", string.Empty, added_on);

                        // Update Payment Status
                        order_Master.SetId(lastinsertedid);
                        order_Master.SetPaymentStatus("success");
                        order_MasterBL.UpdateOrderMasterPaymentStatusById(order_Master);
                        // Send Email

                        Response.Redirect("success");
                    }
                    if (payment_type.Equals("paytm"))
                    {
                        string paytm_oid = "ORDS_" + lastinsertedid + "_" + Session["FOOD_USER_ID"].ToString() + "_" + ClassRandom.GetRandomPassword(3);

                        string outputHTML = "<form id='f1' runat='server' method='post' action='pgRedirect' name='frmPayment' style='display:none;'>";
                        outputHTML += "<input type='text' tabindex = '1' maxlength = '20' size = '20' name = 'ORDER_ID' autocomplete = 'off' value='" + paytm_oid + "'>";
                        outputHTML += "<input id = 'CUST_ID' tabindex = '2' maxlength = '12' size = '12' name = 'CUST_ID' autocomplete = 'off' value='" + Session["FOOD_USER_ID"] + "' />";
                        outputHTML += "<input id = 'INDUSTRY_TYPE_ID' tabindex = '4' maxlength = '12' size = '12' name = 'INDUSTRY_TYPE_ID' autocomplete = 'off' value='Retail' />";
                        outputHTML += "<input id = 'CHANNEL_ID' tabindex = '4' maxlength = '12' size = '12' name = 'CHANNEL_ID'' autocomplete = 'off' value='WEB' />";
                        outputHTML += "<input title = 'TXN_AMOUNT' tabindex = '10'	type = 'text' name = 'TXN_AMOUNT' value='" + final_price + "' />";
                        outputHTML += "<input value = 'CheckOut' type = 'submit'  onclick='' />";
                        outputHTML += "</form>";
                        outputHTML += "<script type='text/javascript'>";
                        outputHTML += "document.frmPayment.submit();";
                        outputHTML += "</script>";

                        //Response.Write("<script>alert('Print HTML')</script>");
                        Response.Write(outputHTML);
                    }
                    if (payment_type.Equals("Razorpay"))
                    {
                        Response.Write("<script>pay_now();</script>");
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Callpay_now", "pay_now()", true);
                    }
                }
                    //Response.Write("<script>alert('Button Clicked!')</script>");
            }
        }
    }
}