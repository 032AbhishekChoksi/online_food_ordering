using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace online_food_ordering.admin
{
    class ClassAdmin
    {
        public static string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public static SqlConnection con = new SqlConnection(maincon);
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter adp = new SqlDataAdapter();
        public static DataTable dt = new DataTable();

        public DataTable DisplayCategoryById(int id)
        {
            try
            {
                cmd = new SqlCommand("SP_Display_CategoryById");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public DataTable DisplayCategoryByCategory(string category)
        {
            try
            {
                cmd = new SqlCommand("SP_Display_CategoryByCategory");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@category", category);
                adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public DataTable DisplayCategoryByCategoryAndId(string category,int id)
        {
            try
            {
                cmd = new SqlCommand("SP_Display_CategoryByCategoryAndId");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@id", id);
                adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public void InsertCategory(string category, DateTime added_on)
        {
            try
            {
                cmd = new SqlCommand("SP_Insertion_Category");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@added_on", added_on);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateCategory(string category, int id)
        {
            try
            {
                cmd = new SqlCommand("SP_Update_Category");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}