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
    public class Coupon_CodeDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public Coupon_CodeDAO()
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
        public DataTable DisplayCouponCode()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_CouponCode")
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
        public Int32 UpdateCouponCodeStatus(Coupon_Code coupon_Code)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Update_CouponCodeStatus")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@status", coupon_Code.GetStatus());
                cmd.Parameters.AddWithValue("@id", coupon_Code.GetId());
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
        public DataTable DisplayCouponCodeByCodeAndStatus(Coupon_Code coupon_Code)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_CouponCodeByCodeAndStatus")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@code", coupon_Code.GetCouponCode());
                cmd.Parameters.AddWithValue("@status", coupon_Code.GetStatus());

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
    }
}