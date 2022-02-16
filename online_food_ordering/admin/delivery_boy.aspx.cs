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
    public partial class delivery_boy : System.Web.UI.Page
    {
        private Delivery_BoyBL delivery_BoyBL;
        private int id = 0;
        private string type = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            delivery_BoyBL = new Delivery_BoyBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Delivery Boy | Billy Admin Panel";
            
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

           FillData();
        }
        private void FillData()
        {
            r1.DataSource = delivery_BoyBL.DisplayDeliveryBoy();
            r1.DataBind();
        }
        private void UpdateStatus(int p_id, string p_type)
        {
            byte status;
            if (p_id > 0 && p_type.Equals("deactive"))
            {
                status = 0;
                Delivery_Boy delivery_Boy = new Delivery_Boy();
                delivery_Boy.SetId(p_id);
                delivery_Boy.SetStatus(status);
                delivery_BoyBL.UpdateDeliveryBoyStatus(delivery_Boy);
                Response.Redirect("delivery_boy");
            }
            else if (p_id > 0 && p_type.Equals("active"))
            {
                status = 1;
                Delivery_Boy delivery_Boy = new Delivery_Boy();
                delivery_Boy.SetId(p_id);
                delivery_Boy.SetStatus(status);
                delivery_BoyBL.UpdateDeliveryBoyStatus(delivery_Boy);
                Response.Redirect("delivery_boy");
            }
        }
    }
}