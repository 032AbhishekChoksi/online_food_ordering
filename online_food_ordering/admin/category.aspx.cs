using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class category : System.Web.UI.Page
    {
        private CategoryBL categoryBL;
        private int id = 0;
        private string type = string.Empty;

        protected void Page_Init(object sender, EventArgs e)
        {
            categoryBL = new CategoryBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Category | Billy Admin Panel";
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }
            //if(RouteData.Values["id"] != null) { 
            //    var routeid = RouteData.Values["id"];
            //    var routetype = RouteData.Values["type"];
            //}
            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();

                if (IsPostBack) return;
                CategoryAction(id, type);
            }
            FillData();

        }
        private void FillData()
        {
            r1.DataSource = categoryBL.DisplayCategory();
            r1.DataBind();
        }
        private void CategoryAction(int p_id, string p_type)
        {
            byte status;
            if (p_id > 0 && p_type == "deactive")
            {
                status = 0;
                Category category = new Category();
                category.SetId(p_id);
                category.SetStatus(status);
                categoryBL.UpdateCategoryStatus(category);
                Response.Redirect("category");
            }
            else if (p_id > 0 && p_type == "active")
            {
                status = 1;
                Category category = new Category();
                category.SetId(p_id);
                category.SetStatus(status);
                categoryBL.UpdateCategoryStatus(category);
                Response.Redirect("category");
            }
            else if(id > 0 && type == "delete")
            {
                Category category = new Category();
                category.SetId(p_id);
                categoryBL.RemoveCategory(category);
                Response.Redirect("category");
            }
        }
    }
}