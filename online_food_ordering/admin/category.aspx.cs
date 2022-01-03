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
        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        byte status = 1;
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();
            }

            if (IsPostBack) return;

            if (id > 0 && type=="delete")
            {
                admin.RemoveCategory(id);
                Response.Redirect("category.aspx");
            }

            if (id > 0 && type == "deactive")
            {
                status = 0;
                admin.UpdateCategoryStatus(id,status);
                Response.Redirect("category.aspx");
            }
            else if(id > 0 && type == "active")
            {
                status = 1;
                admin.UpdateCategoryStatus(id, status);
                Response.Redirect("category.aspx");
            }

            r1.DataSource = admin.DisplayCategory();
            r1.DataBind();
        }
    }
}