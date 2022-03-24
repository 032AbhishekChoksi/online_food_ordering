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
    public class Order_DetailDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public Order_DetailDAO()
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
        public Int32 InsertOrder_Detail(Order_Detail order_Detail)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insertion_Order_Detail")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@order_id", order_Detail.GetOrderId());
                cmd.Parameters.AddWithValue("@dish_details_id", order_Detail.GetDishDetailId());
                cmd.Parameters.AddWithValue("@qty", order_Detail.GetQty());
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
        // getOrderDetails()
        public DataTable DisplayOrderDetailsByOId(Order_Master order_Master)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_OrderDetailsByOid")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@oid", order_Master.GetId());
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dataTable);
                cmd.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dataTable.Dispose();
            }
            return dataTable;
        }
        public Dictionary<int, Dictionary<string, string>> getOrderDetails(Order_Master order_Master)
        {

            DataTable dt = DisplayOrderDetailsByOId(order_Master);
            Dictionary<int, Dictionary<string, string>> getOrderDetails = new Dictionary<int, Dictionary<string, string>>();
            if (dt.Rows.Count > 0)
            {               
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, string> temp = new Dictionary<string, string>();
                    temp.Add("price", dr["price"].ToString());
                    temp.Add("qty", dr["qty"].ToString());
                    temp.Add("attribute", dr["attribute"].ToString());
                    temp.Add("dish_name", dr["dish_name"].ToString());
                    temp.Add("dish_detail_id", dr["dish_detail_id"].ToString());
                    getOrderDetails.Add(Convert.ToInt32(dr["id"]), temp);
                }
            }
            return getOrderDetails;
        }
    }
}