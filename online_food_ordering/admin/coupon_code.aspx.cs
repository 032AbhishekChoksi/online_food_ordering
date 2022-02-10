using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class coupon_code : System.Web.UI.Page
    {
        Coupon_CodeBL coupon_CodeBL;
        private int id = 0;
        private string type = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            coupon_CodeBL = new Coupon_CodeBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Coupon Code | Billy Admin Panel";
            
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();
                
                if (IsPostBack) return;
                UpdateStatus(id, type);
            }

            if (!Page.IsPostBack)
            {
               FillData();
            }
        }

        public string CheckCouponType(object type, object value)
        {
            decimal this_value = Convert.ToDecimal(value);
            if (Convert.ToChar(type) == 'F')
            {
                return "₹" + Math.Round(this_value);
            }
            else
            {
                return Math.Round(this_value) + "%";
            }
        }

        public string CheckCouponExpired(object exp,object i)
        {
            DateTime expired_on = Convert.ToDateTime(exp);
            DateTime cur_time = DateTime.Now.Date;
            int id = Convert.ToInt32(i);
            string msg = String.Empty;
            if (DateTime.Compare(cur_time, expired_on) > 0 || DateTime.Compare(cur_time, expired_on) == 0)
            {
                msg = "Expired";
                Coupon_Code coupon_Code = new Coupon_Code();
                coupon_Code.SetId(id);
                coupon_Code.SetStatus(0);
                coupon_CodeBL.UpdateCouponCodeStatus(coupon_Code);
            }
            return msg;
        }
        private void FillData()
        {
            r1.DataSource = coupon_CodeBL.DisplayCouponCode();
            r1.DataBind();
        }
        private void UpdateStatus(int p_id, string p_type)
        {
            byte status;
            if (p_id > 0 && p_type == "deactive")
            {
                status = 0;
                Coupon_Code coupon_Code = new Coupon_Code();
                coupon_Code.SetId(p_id);
                coupon_Code.SetStatus(status);
                coupon_CodeBL.UpdateCouponCodeStatus(coupon_Code);
                Response.Redirect("coupon_code");
            }
            else if (p_id > 0 && p_type == "active")
            {
                status = 1;
                Coupon_Code coupon_Code = new Coupon_Code();
                coupon_Code.SetId(p_id);
                coupon_Code.SetStatus(status);
                coupon_CodeBL.UpdateCouponCodeStatus(coupon_Code);
                Response.Redirect("coupon_code");
            }
        }
    }
}
