using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class manage_coupon_code : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Manage Coupon Code | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (IsPostBack) return;

            if (id > 0)
            {
                foreach (DataRow dr in admin.DisplayCouponCodeById(id).Rows)
                {
                    txtcoupon_code.Text = dr["coupon_code"].ToString();
                    ddtcoupon_type.ClearSelection();
                    string value = dr["coupon_type"].ToString().Trim(' ');
                    ddtcoupon_type.Items.FindByValue(value).Selected = true;
                    txtcoupon_value.Text = Math.Round(Convert.ToDecimal(dr["coupon_value"])).ToString();
                    txtcart_min_value.Text = Math.Round(Convert.ToDecimal(dr["cart_min_value"])).ToString();
                    txtexpired_on.Text = Convert.ToDateTime(dr["expired_on"]).ToString("yyyy-MM-dd");
                }
            }
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            string coupon_code = txtcoupon_code.Text.ToString();
            char coupon_type = Convert.ToChar(ddtcoupon_type.SelectedItem.Value);
            decimal coupon_value = Convert.ToDecimal(txtcoupon_value.Text);
            decimal cart_min_value = Convert.ToDecimal(txtcart_min_value.Text);
            DateTime exp = Convert.ToDateTime(txtexpired_on.Text);
            string expired_on = exp.ToString("yyyy-MM-dd");
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            int i = 0;

            if (id == 0)
            {
                i = Convert.ToInt32(admin.DisplayCouponCodeByCode(coupon_code).Rows.Count.ToString());
            }
            else
            {
                i = Convert.ToInt32(admin.DisplayCouponCodeByCodeAndId(coupon_code, id).Rows.Count.ToString());
            }


            if (i > 0)
            {
                error.Style.Add("display", "block");
            }
            else
            {
                if (id == 0)
                {
                    admin.InsertionCouponCode(coupon_code, coupon_type, coupon_value, cart_min_value, expired_on, added_on);
                    Response.Redirect("coupon_code.aspx");
                }
                else
                {
                    admin.UpdateCouponCode(coupon_code, coupon_type, coupon_value, cart_min_value, expired_on, added_on, id);
                    Response.Redirect("coupon_code.aspx");
                }
            }
            
        }
    }
}