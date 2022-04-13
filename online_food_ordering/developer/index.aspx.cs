using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.developer
{
    public partial class index : System.Web.UI.Page
    {
        private MaintenanceBL maintenanceBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            maintenanceBL = new MaintenanceBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Index | Billy Developer Panel";
            if (Session["DEVELOPER_USER"] == null)
            {
                Response.Redirect("login");
            }
            lblDEVELOPER_USER.Text = Session["DEVELOPER_USER"].ToString();
            if (!this.Page.IsPostBack)
            {
                FillRecords();
            }            
        }
        protected void btnAdminOn_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance("Admin", 1);
            if(maintenanceBL.UpdateMaintenanceByName(maintenance) > 0)
            {
                lbladmin.Text = "ON";
                btnAdminOn.CssClass = "btn btn-success";
                btnAdminOFF.CssClass = "btn btn-default";
            }
        }

        protected void btnAdminOFF_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance("Admin", 0);
            if (maintenanceBL.UpdateMaintenanceByName(maintenance) > 0)
            {
                lbladmin.Text = "OFF";
                btnAdminOn.CssClass = "btn btn-default";
                btnAdminOFF.CssClass = "btn btn-success";
            }
        }

        protected void btnCUSTON_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance("Customer", 1);
            if (maintenanceBL.UpdateMaintenanceByName(maintenance) > 0)
            {
                lblcust.Text = "ON";
                btnCUSTON.CssClass = "btn btn-success";
                btncustOFF.CssClass = "btn btn-default";
            }
        }

        protected void btncustOFF_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance("Customer", 0);
            if (maintenanceBL.UpdateMaintenanceByName(maintenance) > 0)
            {
                lblcust.Text = "OFF";
                btnCUSTON.CssClass = "btn btn-default";
                btncustOFF.CssClass = "btn btn-success";
            }
        }

        protected void btnDeliveryOn_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance("DeliveryBoy", 1);
            if (maintenanceBL.UpdateMaintenanceByName(maintenance) > 0)
            {
                lbldeli.Text = "ON";
                btnDeliveryOn.CssClass = "btn btn-success";
                btnDeliveryOFF.CssClass = "btn btn-default";
            }
        }
        protected void btnDeliveryOFF_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance("DeliveryBoy", 0);
            if (maintenanceBL.UpdateMaintenanceByName(maintenance) > 0)
            {
                lbldeli.Text = "OFF";
                btnDeliveryOn.CssClass = "btn btn-default";
                btnDeliveryOFF.CssClass = "btn btn-success";
            }          
        }
        private void FillRecords()
        {
            DataTable dt = new DataTable();
            
            // Fill Record For Admin Toggle Button
            Maintenance maintenance = new Maintenance();
            maintenance.SetName("Admin");
            dt = maintenanceBL.DisplayMaintenanceByName(maintenance);

            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {                   
                    if (dr["name"].ToString().Equals("Admin"))
                    {
                        bool status = Convert.ToBoolean(dr["status"]);
                        if (status)
                        {
                            lbladmin.Text = "ON";
                            btnAdminOn.CssClass = "btn btn-success";
                            btnAdminOFF.CssClass = "btn btn-default";
                        }
                        else
                        {
                            lbladmin.Text = "OFF";
                            btnAdminOn.CssClass = "btn btn-default";
                            btnAdminOFF.CssClass = "btn btn-success";
                            
                        }                   
                    }
                }
            }

            // Fill Record For Customer Toggle Button
            maintenance = new Maintenance();
            maintenance.SetName("Customer");
            dt = maintenanceBL.DisplayMaintenanceByName(maintenance);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["name"].ToString().Equals("Customer"))
                    {
                        bool status = Convert.ToBoolean(dr["status"]);
                        if (status)
                        {
                            lblcust.Text = "ON";
                            btnCUSTON.CssClass = "btn btn-success";
                            btncustOFF.CssClass = "btn btn-default";
                        }
                        else
                        {
                            lblcust.Text = "OFF";
                            btnCUSTON.CssClass = "btn btn-default";
                            btncustOFF.CssClass = "btn btn-success";
                        }
                    }
                }
            }

            // Fill Record For Delivery Boy Toggle Button
            maintenance = new Maintenance();
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
                            lbldeli.Text = "ON";
                            btnDeliveryOn.CssClass = "btn btn-success";
                            btnDeliveryOFF.CssClass = "btn btn-default";
                        }
                        else
                        {
                            lbldeli.Text = "OFF";
                            btnDeliveryOn.CssClass = "btn btn-default";
                            btnDeliveryOFF.CssClass = "btn btn-success";
                        }
                    }
                }
            }
        }
    }
}