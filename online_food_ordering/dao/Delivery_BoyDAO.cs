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
    public class Delivery_BoyDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public Delivery_BoyDAO()
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
        public DataTable DisplayDeliveryBoy()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_DeliveryBoy")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
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
        public Int32 UpdateDeliveryBoyStatus(Delivery_Boy delivery_Boy)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Update_DeliveryBoyStatus")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@status", delivery_Boy.GetStatus());
                cmd.Parameters.AddWithValue("@id", delivery_Boy.GetId());
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