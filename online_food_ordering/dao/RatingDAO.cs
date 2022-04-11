using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace online_food_ordering.dao
{
    public class RatingDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public RatingDAO()
        {

        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(maincon);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }

        //getRatingList()
        public string getRatingList(Order_Detail order_Detail)
        {
            string html = string.Empty;
            try
            {
                string[] arr = new string[] { "Bad", "Below Average", "Average", "Good", "Very Good" };
                html = "<select onchange=updaterating('" + order_Detail.GetDishDetailId() + "','" + order_Detail.GetOrderId() + "') id='rate" + order_Detail.GetDishDetailId() + "'>";
                html += "<option value=''>Select Rating</option>";
                for(int i = 0; i < arr.Length; i++)
                {
                    int id = i + 1;
                    html += "<option value='"+ id +"'>"+ arr[i] +"</option>";
                }
                html += "</select>";
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return html;
        }
        //getRating()
        public string getRating(Order_Detail order_Detail)
        {
            string html = string.Empty;
            try
            {
                DataTable dataTable = new DataTable();
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_RattingByOidAndDdid")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@oid",order_Detail.GetOrderId());
                cmd.Parameters.AddWithValue("@ddid",order_Detail.GetDishDetailId());

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dataTable);
                cmd.Dispose();

                if(dataTable.Rows.Count > 0)
                {
                    foreach(DataRow dr in dataTable.Rows)
                    {
                        int rating = Convert.ToInt32(dr["rating"]);
                        string[] arr = new string[] {"", "Bad", "Below Average", "Average", "Good", "Very Good" };
                        html = "<div class='set_rating'>" + arr[rating] + "</div>";
                    }
                }
                else
                {
                    html = getRatingList(order_Detail);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return html;
        }
        public string getRatingByDishId(Dish dish)
        {
            string html = string.Empty;
            try
            {
                Dish_DetailsBL dish_DetailsBL = new Dish_DetailsBL();
                DataTable dataTable = dish_DetailsBL.DisplayDishDetailsByDid(dish);
                string str = string.Empty;
                foreach (DataRow dr in dataTable.Rows)
                {
                    str += "dish_detail_id='" + dr["DDID"].ToString() + "' or ";
                }
                str = str.Remove(str.Length - 3);
                str = str.TrimEnd(' ');
                string[] arr = new string[] { "", "Bad", "Below Average", "Average", "Good", "Very Good" };
                string sql = "SELECT SUM(rating) AS 'rating',COUNT(*) AS 'total' FROM Rating WHERE " + str;

                DataTable dt = new DataTable();
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = sql,
                    CommandType = CommandType.Text,
                    Connection = con
                };

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                cmd.Dispose();

                if(dt.Rows.Count > 0) { 
                    foreach(DataRow dr in dt.Rows)
                    {
                        if(Convert.ToDecimal(dr["total"]) > 0)
                        {
                            decimal totalRate = Convert.ToDecimal(dr["rating"]) / Convert.ToDecimal(dr["total"]);
                            int i = Convert.ToInt32(Math.Round(totalRate));
                            html = "<span class='rating'> ("+ arr[i] + " rated by " + dr["total"].ToString() + " users)</span>";
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return html;
        }
        public Int32 InsertRating(Rating rating)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insertion_Rating")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@user_id", rating.GetUserId());
                cmd.Parameters.AddWithValue("@order_id", rating.GetOrderId());
                cmd.Parameters.AddWithValue("@dish_detail_id", rating.GetDishDetailId());
                cmd.Parameters.AddWithValue("@rating", rating.GetRating());                
                cmd.Parameters.AddWithValue("@added_on", rating.GetAddedOn());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
    }
}