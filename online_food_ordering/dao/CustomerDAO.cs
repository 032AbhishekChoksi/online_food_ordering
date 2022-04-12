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
    public class CustomerDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public CustomerDAO()
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
        public Int32 InsertCustomer(Customer customer)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insertion_User")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@name", customer.GetName());
                cmd.Parameters.AddWithValue("@email", customer.GetEmail());
                cmd.Parameters.AddWithValue("@mobile", customer.GetMobile());
                cmd.Parameters.AddWithValue("@password", customer.GetPassword());
                cmd.Parameters.AddWithValue("@status", customer.GetStatus());
                cmd.Parameters.AddWithValue("@email_verify", customer.GetEmailVerify());
                cmd.Parameters.AddWithValue("@rand_str", customer.GetRandStr());
                cmd.Parameters.AddWithValue("@referral_code", customer.GetReferralCode());
                cmd.Parameters.AddWithValue("@from_referral_code", customer.GetFromReferralCode());
                cmd.Parameters.AddWithValue("@added_on", customer.GetAddedOn());
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int result;
                int cid;
                result = cmd.ExecuteNonQuery();
                cid = Convert.ToInt32(cmd.Parameters["@id"].Value);
                cmd.Dispose();
                if (result > 0)
                {

                    return cid;
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
        public DataTable DisplayCustomerByCid(Customer customer)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_CustomerCid")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@uid", customer.GetId());
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
        public Int32 UpdateCustomer(Customer customer)
        {
            int result;
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Update_User")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@cid", customer.GetId());
                cmd.Parameters.AddWithValue("@name", customer.GetName());
                cmd.Parameters.AddWithValue("@mobile", customer.GetMobile());
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
        public DataTable DisplayCustomerByPassword(Customer customer)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_UserByPassword")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@password", customer.GetPassword());
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
        public Int32 UpdateCustomerPasswordById(Customer customer)
        {
            int result;
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Update_UserPasswordByUid")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@uid", customer.GetId());
                cmd.Parameters.AddWithValue("@password", customer.GetPassword());

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
        public Int32 DisplayCustomerIdByReferralCode(Customer customer)
        {
            int result;
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Display_UserIdByReferralCode")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@referral_code", customer.GetReferralCode());

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToInt32(cmd.ExecuteScalar());
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