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
        public DataTable DisplayBanner()
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_Banner");
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

        public DataTable DisplayBannerById(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_BannerById");
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
            return dt;
        }

        public void InsertBanner(string image, string heading, string sub_heading, string link, string link_text, int banner_order, DateTime added_on)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Insertion_Banner");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@heading", heading);
                cmd.Parameters.AddWithValue("@sub_heading", sub_heading);
                cmd.Parameters.AddWithValue("@link", link);
                cmd.Parameters.AddWithValue("@link_text", link_text);
                cmd.Parameters.AddWithValue("@banner_order", banner_order);
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
        public string DisplayBannerImage(int id)
        {
            string url = string.Empty;
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_BannerImage");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                url = cmd.ExecuteScalar().ToString();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return url;
        }
        public void UpdateBannerImage(int id, string image, string heading, string sub_heading, string link, string link_text, int banner_order)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_BannerImage");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@heading", heading);
                cmd.Parameters.AddWithValue("@sub_heading", sub_heading);
                cmd.Parameters.AddWithValue("@link", link);
                cmd.Parameters.AddWithValue("@link_text", link_text);
                cmd.Parameters.AddWithValue("@banner_order", banner_order);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateBanner(int id, string heading, string sub_heading, string link, string link_text, int banner_order)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_Banner");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@heading", heading);
                cmd.Parameters.AddWithValue("@sub_heading", sub_heading);
                cmd.Parameters.AddWithValue("@link", link);
                cmd.Parameters.AddWithValue("@link_text", link_text);
                cmd.Parameters.AddWithValue("@banner_order", banner_order);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveBanner(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Remove_Banner");
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
        public void UpdateBannerStatus(int id, byte status)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_BannerStatus");
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
        public DataTable DisplaySettingById(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_SettingById");
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

        public void UpdateSetting(int id,decimal cart_min_price,string cart_min_price_msg,string website_close,string website_close_msg,decimal wallet_amt, decimal referral_amt)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_Setting");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cart_min_price", cart_min_price);
                cmd.Parameters.AddWithValue("@cart_min_price_msg", cart_min_price_msg);
                cmd.Parameters.AddWithValue("@website_close", website_close);                
                cmd.Parameters.AddWithValue("@wallet_amt", wallet_amt);
                cmd.Parameters.AddWithValue("@website_close_msg", website_close_msg);
                cmd.Parameters.AddWithValue("@referral_amt", referral_amt);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable DisplayDeliveryBoy()
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DeliveryBoy");
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
        public DataTable DisplayDeliveyBoyById(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DeliveryBoyById");
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
        public DataTable DisplayDeliveyBoyByMobile(long mobile)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DeliveyBoyByMobile");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@mobile", mobile);
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
        public DataTable DisplayDeliveyBoyByMobileAndId(long mobile, int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_DeliveyBoyByMobileAndId");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@mobile", mobile);
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
        public void InsertDeliveyBoy(string name,long mobile,string password, DateTime added_on)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Insertion_DeliveryBoy");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@password", password);
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

        public void UpdateDeliveyBoy(string name, long mobile, string password,int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_DeliveryBoy");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@password", password);
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

        public void UpdateDeliveryBoyStatus(int id, byte status)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_DeliveryBoyStatus");
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

        public DataTable DisplayCouponCode() {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_CouponCode");
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

        public void InsertionCouponCode(string coupon_code, char coupon_type, decimal coupon_value, decimal cart_min_value, string expired_on, DateTime added_on)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Insertion_CouponCode");
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@coupon_code", coupon_code);
                cmd.Parameters.AddWithValue("@coupon_type", coupon_type);
                cmd.Parameters.AddWithValue("@coupon_value", coupon_value);
                cmd.Parameters.AddWithValue("@cart_min_value", cart_min_value);
                cmd.Parameters.AddWithValue("@expired_on", expired_on);
                cmd.Parameters.AddWithValue("@added_on", added_on);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable DisplayCouponCodeById(int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_CouponCodeById");
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
        public void UpdateCouponCode(string coupon_code, char coupon_type, decimal coupon_value, decimal cart_min_value, string expired_on, DateTime added_on,int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_CouponCode");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@coupon_code", coupon_code);
                cmd.Parameters.AddWithValue("@coupon_type", coupon_type);
                cmd.Parameters.AddWithValue("@coupon_value", coupon_value);
                cmd.Parameters.AddWithValue("@cart_min_value", cart_min_value);
                cmd.Parameters.AddWithValue("@expired_on", expired_on);
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
        public DataTable DisplayCouponCodeByCode(string coupon_code)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_CouponCodeByCode");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@coupon_code", coupon_code);
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
        public DataTable DisplayCouponCodeByCodeAndId(string coupon_code,int id)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_CouponCodeByCodeAndId");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@coupon_code", coupon_code);
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

        public void UpdateCouponCodeStatus(int id, byte status)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_CouponCodeStatus");
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
        public DataTable DisplayUser()
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_User");
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
        public void UpdateUserStatus(int id, byte status)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_UserStatus");
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
    }
}