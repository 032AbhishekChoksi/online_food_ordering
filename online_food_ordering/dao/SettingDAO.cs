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
    public class SettingDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public SettingDAO()
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
        public Setting DisplaySettingById(Setting setting)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Display_SettingById")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id", setting.GetId());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Dispose();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    decimal cart_min_price = Convert.ToDecimal(dr["cart_min_price"]);
                    string cart_min_price_msg = dr["cart_min_price_msg"].ToString();
                    string website_close = dr["website_close"].ToString().Trim(' ');
                    decimal wallet_amt = Convert.ToDecimal(dr["wallet_amt"]);
                    string website_close_msg = dr["website_close_msg"].ToString();
                    decimal referral_amt = Convert.ToDecimal(dr["referral_amt"]);
                    string theme_color = dr["theme_color"].ToString();
                    setting = new Setting(id,cart_min_price,cart_min_price_msg,website_close,website_close_msg,wallet_amt,referral_amt,theme_color);
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
            return setting;
        }
        public Int32 UpdateSetting(Setting setting)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Update_Setting")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id", setting.GetId());
                cmd.Parameters.AddWithValue("@cart_min_price", setting.GetCartMinPrice());
                cmd.Parameters.AddWithValue("@cart_min_price_msg", setting.GetCartMinPriceMsg());
                cmd.Parameters.AddWithValue("@website_close", setting.GetWebsiteClose());
                cmd.Parameters.AddWithValue("@wallet_amt", setting.GetWalletAmt());
                cmd.Parameters.AddWithValue("@website_close_msg", setting.GetWebsiteCloseMsg());
                cmd.Parameters.AddWithValue("@referral_amt", setting.GetReferralAmt());
                cmd.Parameters.AddWithValue("@theme_color", setting.GetThemeColor());
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