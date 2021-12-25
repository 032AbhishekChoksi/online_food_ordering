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
    public partial class manage_category : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if(Request.QueryString["id"]!=null) { 
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (IsPostBack) return;

            if (id > 0)
            {
                foreach (DataRow dr in admin.DisplayCategoryById(id).Rows)
                {
                    txtcategory.Text = dr["category"].ToString();
                }
            }
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            string category = txtcategory.Text;
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            string sql2 = null;
            int i = 0;

            if (id == 0)
            {
                i = Convert.ToInt32(admin.DisplayCategoryByCategory(category).Rows.Count.ToString());
            }
            else
            {
                i = Convert.ToInt32(admin.DisplayCategoryByCategoryAndId(category, id).Rows.Count.ToString());
            }


            if (i > 0)
            {
                error.Style.Add("display", "block");
            }
            else
            {
                if(id == 0)
                {
                    admin.InsertCategory(category,added_on);
                    Response.Redirect("category.aspx");
                }
                else
                {
                    admin.UpdateCategory(category, id);
                    Response.Redirect("category.aspx");
                }
            }
        }
    }
}