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
    public class AdminDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public AdminDAO()
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
        public Int32 DisplayAdminByUsernameAndPassword(Admin admin)
        {
            int i = 0;
            DataTable dataTable = new DataTable();
            try
            { 
				SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_AdminByUsernameAndPassword")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@username", admin.GetName());
                cmd.Parameters.AddWithValue("@password", admin.GetPassword());
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dataTable);
                cmd.Dispose();

                i = Convert.ToInt32(dataTable.Rows.Count.ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dataTable.Dispose();
            }
            return i;
        }
        // getSale()
        public decimal GetSalesDetails(DateTime startdate, DateTime enddate)
        {
            decimal result = 0;
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Display_SalesReport")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@startdate", startdate);
                cmd.Parameters.AddWithValue("@enddate", enddate);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string r = cmd.ExecuteScalar().ToString();
                cmd.Dispose();
                
                if (r.Equals("0") || string.IsNullOrEmpty(r))
                {
                    result = 0;
                }
                else
                {
                  result = Convert.ToDecimal(r);
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
            return result;
        }
        public DataTable MostSaleDish()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_MostSaleDish")
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
        public DataTable MostActiveUser()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_MostActiveUser")
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
    }
}