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
        public static int id;

        public int DisplayAdminByUsernameAndPassword(string username,string password)
        {
            int i = 0;
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_AdminByUsernameAndPassword");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

                i = Convert.ToInt32(dt.Rows.Count.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return i;
        }
        public DataTable DisplayCategory()
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_Category");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
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
        public DataTable DisplayCategoryById(int id)
        {
            try
            {
                con.Close();
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
                con.Close();
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
                con.Close();
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
                con.Close();
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
                con.Close();
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

        public void RemoveCategory(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Remove_Category");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
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

        public DataTable DisplayDish()
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_Dish");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
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

        public void UpdateCategoryStatus(int id,byte status)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_CategoryStatus");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@status", status);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable DisplayCategoryByStatus()
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_CategoryByStatus");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
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

        public int InsertionDish(int category_id, string dish_name, string dish_desc, string image, string type, DateTime added_on)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Insertion_Dish");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@category_id", category_id);
                cmd.Parameters.AddWithValue("@dish_name", dish_name);
                cmd.Parameters.AddWithValue("@dish_desc", dish_desc);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@added_on", added_on);
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.Parameters["@id"].Value);
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id;
        }

        public void InsertionDishDetails(int dish_id, string attribute, int price, byte status, DateTime added_on)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Insertion_Dish_Details");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@dish_id", dish_id);
                cmd.Parameters.AddWithValue("@attribute", attribute);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@status", status);
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

        public void UpdateDishStatus(int id, byte status)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_DishStatus");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@status", status);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable DisplayDishById(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DishById");
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
        public DataTable DisplayDishByName(string dish_name)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DishByName");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@dish_name", dish_name);
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
        public DataTable DisplayDishByNameAndId(string dish_name, int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DishByNameAndId");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@dish_name", dish_name);
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

        public string DisplayDishImage(int id)
        {
            string url = string.Empty;
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DishImage");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                url=cmd.ExecuteScalar().ToString();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return url;
        }

        public void UpdateDish(int id,int category_id, string dish_name, string dish_desc, string type)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_Dish");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@category_id", category_id);
                cmd.Parameters.AddWithValue("@dish_name", dish_name);
                cmd.Parameters.AddWithValue("@dish_desc", dish_desc);
                cmd.Parameters.AddWithValue("@type", type);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateDishImage(int id, int category_id, string dish_name, string dish_desc, string image, string type)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_DishImage");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@category_id", category_id);
                cmd.Parameters.AddWithValue("@dish_name", dish_name);
                cmd.Parameters.AddWithValue("@dish_desc", dish_desc);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@type", type);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateDishDetails(int id, string attribute, int price, byte status)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_Dish_Details");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@attribute", attribute);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@status", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable DisplayDishDetailsByDishID(int dish_id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_Dish_DetailsByDishID");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@dish_id", dish_id);
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

        public void RemoveDishDetails(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Remove_Dish_Details");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
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