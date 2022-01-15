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

        public void InsertUser(string name,string email,long mobile,string password,byte status,byte email_verify,string rand_str,string referral_code,string from_referral_code,DateTime added_on)
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