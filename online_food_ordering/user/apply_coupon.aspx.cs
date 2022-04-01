using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class apply_coupon : System.Web.UI.Page
    {
        private Coupon_CodeBL coupon_CodeBL;
        private ClassFunction classFunction;
        protected void Page_Init(object sender, EventArgs e)
        {
            coupon_CodeBL = new Coupon_CodeBL();
            classFunction = new ClassFunction();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string coupon_code = string.Empty;
            var js = new JavaScriptSerializer();
            if (Request.Form["coupon_code"] != null)
            {
                coupon_code = Request.Form["coupon_code"].ToString();
                Coupon_Code coupon_Code = new Coupon_Code();
                coupon_Code.SetCouponCode(coupon_code);
                coupon_Code.SetStatus(1);
                DataTable dt = coupon_CodeBL.DisplayCouponCodeByCodeAndStatus(coupon_Code);
                string json = string.Empty;

                if (dt.Rows.Count > 0)
                {
                    decimal cart_min_value = 0;
                    string coupon_type = string.Empty;
                    decimal coupon_value = 0;
                    DateTime expired_on = DateTime.Now.Date;
                    DateTime cur_time = DateTime.Now.Date;
                    decimal getcartTotalPrice = Convert.ToDecimal(classFunction.getcartTotalPrice());

                    foreach (DataRow dr in dt.Rows)
                    {
                        cart_min_value = Convert.ToDecimal(dr["cart_min_value"]);
                        coupon_type = dr["coupon_type"].ToString().Trim(' ');
                        coupon_value = Convert.ToDecimal(dr["coupon_value"]);
                        expired_on = Convert.ToDateTime(dr["expired_on"].ToString());
                    }

                    if(getcartTotalPrice > cart_min_value)
                    {
                        if(DateTime.Compare(cur_time, expired_on) > 0 || DateTime.Compare(cur_time, expired_on) == 0)
                        {
                            json = js.Serialize(new { status = "error", msg = "Coupon code expired" });
                        }
                        else
                        {
                            decimal coupon_code_apply = 0;
                            if (coupon_type.Equals("F"))
                            {
                                coupon_code_apply = getcartTotalPrice - coupon_value;
                            }
                            else if(coupon_type.Equals("P"))
                            {
                                coupon_code_apply = getcartTotalPrice - (coupon_value/100) * getcartTotalPrice;
                            }

                            Session["COUPON_CODE"] = coupon_code;
                            Session["FINAL_PRICE"] = coupon_code_apply;

                            json = js.Serialize(new { status = "success", msg = "Coupon code applied.", field = "form_msg", coupon_code_apply = ""+ coupon_code_apply });
                        }
                    }
                    else
                    {
                        json = js.Serialize(new { status = "error", msg = "Coupon code will be applied for cart value greater then " + cart_min_value });
                    }
                }
                else
                {
                    json = js.Serialize(new { status = "error", msg = "Coupon code not found"});
                }

                // Send Ressponse in json_encode format
                Context.Response.Write(js.Serialize(json));
            }
        }
    }
}