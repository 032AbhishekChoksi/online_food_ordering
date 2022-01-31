using online_food_ordering.bussinesslogic;
using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class manage_category : System.Web.UI.Page
    {
        private CategoryBL categoryBL;
        private int id = 0;
        protected void Page_Init(object sender, EventArgs e)
        {
            categoryBL = new CategoryBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Manage Category | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if(Request.QueryString["id"]!=null) { 
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (IsPostBack) return;

            if (id > 0)
            {
                FillRecords();
            }
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            string category = txtcategory.Text;
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            int i = 0;

            if (id == 0)
            {
                i = CheckCategoryByCategory(category);
            }
            else
            {
                i = CheckCategoryByCategoryAndId(id, category);
            }

            if (i > 0)
            {
                error.Style.Add("display", "block");
            }
            else
            {
                if(id == 0)
                {
                    InsertRecords(category,added_on);
                }
                else
                {
                    UpdateRecords(id, category);
                }
            }
        }
        private void InsertRecords(string p_category, DateTime p_added_on)
        {
            Category category = new Category();
            try
            { 
                category = new Category(p_category,1,p_added_on);
                int retVal = categoryBL.InsertCategory(category);
                if (retVal > 0)
                {
                    Response.Redirect("category", false);
                }
                else
                {
                    Response.Write("Not Inserted Category");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void UpdateRecords(int p_id, string p_category)
        {
            try
            {
                Category category = new Category();
                category.SetId(p_id);
                category.SetCategory(p_category);
                int retVal = categoryBL.UpdateCategory(category);
                if (retVal > 0)
                {
                    Response.Redirect("category", false);
                }
                else
                {
                    Response.Write("Not Updated Category");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void FillRecords() { 
            try
            {
                Category category = new Category();
                category.SetId(id);
                category = categoryBL.DisplayCategoryById(category);
                txtcategory.Text = category.GetCategory();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private Int32 CheckCategoryByCategory(string p_category)
        {
            int retVal = 0;
            try
            {
                Category category = new Category();
                category.SetCategory(p_category);
                retVal = categoryBL.DisplayCategoryByCategory(category).Rows.Count;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            return retVal;
        }
        private Int32 CheckCategoryByCategoryAndId(int p_id, string p_category)
        {
            int retVal = 0;
            try
            {
                Category category = new Category();
                category.SetId(p_id);
                category.SetCategory(p_category);
                retVal = categoryBL.DisplayCategoryByCategoryAndId(category).Rows.Count;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            return retVal;
        }
    }
}