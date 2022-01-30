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
        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        byte status = 1;
        string type = string.Empty;
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
            }

            if (IsPostBack) return;

            if (id > 0 && type == "deactive")
            {
                status = 0;
                admin.UpdateCouponCodeStatus(id, status);
                Response.Redirect("coupon_code");
            }
            else if (id > 0 && type == "active")
            {
                status = 1;
                admin.UpdateCouponCodeStatus(id, status);
                Response.Redirect("coupon_code");
            }
            if (!Page.IsPostBack)
            {
                r1.DataSource = admin.DisplayCouponCode();
                r1.DataBind();
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
                admin.UpdateCouponCodeStatus(id, 0);
            }
            return msg;
        }
    }
}
