using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace online_food_ordering.user
{
    public class ClassUser
    {
        public static string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public static SqlConnection con = new SqlConnection(maincon);
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter adp = new SqlDataAdapter();
        public static DataTable dt = new DataTable();
        public static int id;

        public DataTable DisplayUserByEmail(string email)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_UserByEmail");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@email", email);
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

        public int InsertUser(string name,string email,long mobile,string password,byte status,byte email_verify,string rand_str,string referral_code,string from_referral_code,DateTime added_on)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Insertion_User");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@email_verify", email_verify);
                cmd.Parameters.AddWithValue("@rand_str", rand_str);
                cmd.Parameters.AddWithValue("@referral_code", referral_code);
                cmd.Parameters.AddWithValue("@from_referral_code", from_referral_code);
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
        public DataTable getSetting(int id)
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
        public void manageWallet(int user_id,decimal amt,string msg,string type,string payment_id,DateTime added_on)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Insertion_Wallet");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@amt", amt);
                cmd.Parameters.AddWithValue("@msg", msg);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@payment_id", payment_id);
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

        public DataTable DisplayUserByRandomString(string rand_str)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Display_UserByRandomString");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@rand_str", rand_str);
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
        public void UpdateUserEmailVerify(string rand_str, byte email_verify)
        {
            try
            {
                con.Close();
                cmd = new SqlCommand("SP_Update_UserEmailVerify");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@rand_str", rand_str);
                cmd.Parameters.AddWithValue("@email_verify", email_verify);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Decimal getWalletAmt(int uid)
        {
            decimal finalamt = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Display_WalletByUserId")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@user_id", uid);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Dispose();
                decimal inamt = 0;
                decimal outamt = 0;
                while (dr.Read())
                {
                    if (dr["type"].ToString().Trim(' ').Equals("in"))
                    {
                        inamt = inamt + Convert.ToDecimal(dr["amt"]);
                    }
                    if (dr["type"].ToString().Trim(' ').Equals("out"))
                    {
                        outamt = outamt + Convert.ToDecimal(dr["amt"]);
                    }
                }
                finalamt = inamt - outamt;
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
            return finalamt;
        }
    }
}