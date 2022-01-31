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
            SqlConnection con = GetConnection();
            DataTable dataTable = new DataTable();
            try
            { 
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
    }
}