using online_food_ordering.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.email_body
{
    public partial class coupon : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Coupon Code";
            if (IsPostBack) return;
            
            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            if(id > 0)
            { 
                if (!Page.IsPostBack)
                {
                    r1.DataSource = admin.DisplayCouponCodeById(id);
                    r1.DataBind();
                }
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    r1.DataSource = admin.DisplayCouponCode();
                    r1.DataBind();
                }
            }

        }
        public string CheckCouponCode(object type, object value)
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

        public string  CheckCouponType(object type)
        {
            if (Convert.ToChar(type) == 'F')
            {
                return "Fixed";
            }
            else
            {
                return "Percentage";
            }
        }
    }
}