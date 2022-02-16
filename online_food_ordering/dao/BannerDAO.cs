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
    public class BannerDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public BannerDAO()
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
        public DataTable DisplayBanner()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_Banner")
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
        public Int32 UpdateBannerStatus(Banner banner)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Update_BannerStatus")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@status", banner.GetStatus());
                cmd.Parameters.AddWithValue("@id", banner.GetId());
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
        public Int32 RemoveBanner(Banner banner)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Remove_Banner")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id", banner.GetId());
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