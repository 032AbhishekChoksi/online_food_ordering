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
    public partial class contact_us : System.Web.UI.Page
    {
        private Contact_UsBL contact_UsBL;
        private int id = 0;
        private string type = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            contact_UsBL = new Contact_UsBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Contact Us | Billy Admin Panel";
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }
            
            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();

                if (IsPostBack) return;
                Contact_UsAction(id, type);
            }
            FillRecords();
        }
        private void FillRecords()
        {
            Contact_Us contact_Us = new Contact_Us();
            contact_Us.SetStatus(1);
            r1.DataSource = contact_UsBL.DisplayContactUsByStatus(contact_Us);
            r1.DataBind();
        }
        private void Contact_UsAction(int p_id, string p_type)
        {
            byte status;
            if (p_id > 0 && p_type == "deactive")
            {
                status = 0;
                Contact_Us contact_Us = new Contact_Us();
                contact_Us.SetId(p_id);
                contact_Us.SetStatus(status);
                contact_UsBL.UpdateContactUsStatus(contact_Us);
                Response.Redirect("contact_us");
            }
            //if (p_id > 0 && p_type == "active")
            //{
            //    status = 1;
            //    Contact_Us contact_Us = new Contact_Us();
            //    contact_Us.SetId(p_id);
            //    contact_Us.SetStatus(status);
            //    contact_UsBL.UpdateContactUsStatus(contact_Us);
            //    Response.Redirect("category");
            //}
        }
    }
}