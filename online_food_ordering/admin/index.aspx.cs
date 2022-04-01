using online_food_ordering.bussinesslogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class index : System.Web.UI.Page
    {
        private AdminBL  adminBL;
        private Order_MasterBL order_MasterBL;
        protected string dishname = string.Empty;
        protected string totaldish = string.Empty;
        protected string username = string.Empty;
        protected string totalUser = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            adminBL = new AdminBL();
            order_MasterBL = new Order_MasterBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Dashboard | Billy Admin Panel";

            FillRedcords();
        }
        private void FillRedcords()
        {
            DataTable dataTable = adminBL.MostSaleDish();
            if(dataTable.Rows.Count > 0)
            {
                foreach(DataRow dr in dataTable.Rows)
                {
                    dishname = dr["dish_name"].ToString();
                    totaldish = dr["TotalDish"].ToString();
                }
            }

            DataTable dt = adminBL.MostActiveUser();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    totalUser = dr["TotalUser"].ToString();
                    username = dr["CName"].ToString();                    
                }
            }
            r1.DataSource = order_MasterBL.DisplayLastFiveOrderDetails();
            r1.DataBind();
        }
        protected String[] ApplyCoupon(object coupon_code, object final_price)
        {
            String[] result = new String[2];
            string coupon = coupon_code.ToString().Trim(' ');
            decimal final = Convert.ToDecimal(final_price.ToString());

            if (!string.IsNullOrEmpty(coupon))
            {
                result[0] = "Coupon Code:- " + coupon + "<br />";
                result[1] = "Final Price:- " + Math.Round((decimal)final) + " Rs.";
            }
            else
            {
                result[0] = "";
                result[1] = "";
            }
            return result;
        }
        protected string ToDaySales()
        {
            string str = string.Empty;
            string startdate = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string enddate = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59.000";
            DateTime s = Convert.ToDateTime(startdate);
            DateTime e = Convert.ToDateTime(enddate);
            decimal amt = adminBL.GetSalesDetails(s, e);
            str = String.Format("{0} Rs.", Math.Round(amt));
            return str;
        }
        protected string SevenDaySales()
        {
            string str = string.Empty;
            string startdate = DateTime.Now.Date.AddDays(-7).ToString("yyyy-MM-dd") + " 00:00:00.000";
            string enddate = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59.000";
            DateTime s = Convert.ToDateTime(startdate);
            DateTime e = Convert.ToDateTime(enddate);
            decimal amt = adminBL.GetSalesDetails(s, e);
            str = String.Format("{0} Rs.", Math.Round(amt));
            return str;
        }
        protected string ThirtyDaySales()
        {
            string str = string.Empty;
            string startdate = DateTime.Now.Date.AddDays(-30).ToString("yyyy-MM-dd") + " 00:00:00.000";
            string enddate = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59.000";
            DateTime s = Convert.ToDateTime(startdate);
            DateTime e = Convert.ToDateTime(enddate);
            decimal amt = adminBL.GetSalesDetails(s, e);
            str = String.Format("{0} Rs.", Math.Round(amt));
            return str;
        }
        protected string OneYearSales()
        {
            string str = string.Empty;
            string startdate = DateTime.Now.Date.AddDays(-365).ToString("yyyy-MM-dd") + " 00:00:00.000";
            string enddate = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59.000";
            DateTime s = Convert.ToDateTime(startdate);
            DateTime e = Convert.ToDateTime(enddate);
            decimal amt = adminBL.GetSalesDetails(s, e);
            str = String.Format("{0} Rs.", Math.Round(amt));
            return str;
        }
    }
}