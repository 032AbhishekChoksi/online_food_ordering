using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.deliveryboy
{
    public partial class login : System.Web.UI.Page
    {
        private SettingBL settingBL;
        private Delivery_BoyBL deliveryBoyBL;
        private MaintenanceBL maintenanceBL;
        private DataTable dt;
        protected void Page_Init(object sender, EventArgs e)
        {
            settingBL = new SettingBL();
            deliveryBoyBL = new Delivery_BoyBL();
            maintenanceBL = new MaintenanceBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Login | Billy Delivery Boy Panel";
            UnderMaintenance();
            if (Session["DELIVERY_BOY_USER_LOGIN"] != null)
            {
                Response.Redirect("index");
            }
            FetchThemeColor(1);
            
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            long mobile = Convert.ToInt64(txtmobile.Text);
            string password = txtpassword.Text;
            CheckDeliveryBoyByMobileAndPassword(mobile, password);
        }
        private void FetchThemeColor(int p_id)
        {
            try
            {
                Setting setting = new Setting();
                setting.SetId(p_id);
                setting = settingBL.DisplaySettingById(setting);
                lnkstyle.Attributes["href"] = "../admin/assets/css/" + setting.GetThemeColor();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void CheckDeliveryBoyByMobileAndPassword(long p_mobile, string p_password)
        {
            try
            { 
                int retVal = 0;
                Delivery_Boy delivery_Boy = new Delivery_Boy();
                delivery_Boy.SetMobile(p_mobile);
                delivery_Boy.SetPassword(p_password);
                DataTable dt = new DataTable();
                dt = deliveryBoyBL.DisplayDeliveyBoyByMobileAndPassword(delivery_Boy);
                retVal = dt.Rows.Count;
                if (retVal > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        if (Convert.ToBoolean(dr["status"]))
                        { 
                            Session["DELIVERY_BOY_USER_LOGIN"] = "yes";
                            Session["DELIVERY_BOY_USER"] = dr["name"].ToString();
                            Session["DELIVERY_BOY_ID"] = dr["id"].ToString();
                            Response.Redirect("index", false);
                        }
                        else
                        {
                            lblMessage.Text = "Your account has been deactivated";
                            error.Style.Add("display", "block");
                        }
                    }                    
                }
                else
                {
                    lblMessage.Text = "Please enter valid login details";
                    error.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void UnderMaintenance()
        {
            // Fill Record For Customer Toggle Button
            Maintenance maintenance = new Maintenance();
            maintenance.SetName("DeliveryBoy");
            dt = maintenanceBL.DisplayMaintenanceByName(maintenance);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["name"].ToString().Equals("DeliveryBoy"))
                    {
                        bool status = Convert.ToBoolean(dr["status"]);
                        if (status)
                        {
                            Response.Redirect("~/page/underconstructor.html", false);
                        }
                    }
                }
            }
        }
    }
}