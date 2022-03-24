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
    public class Order_MasterDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public Order_MasterDAO()
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
        public Int32 InsertOrderMaster(Order_Master order_Master)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insertion_Order_Master")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@user_id", order_Master.GetUserId());
                cmd.Parameters.AddWithValue("@address", order_Master.GetAddress());
                cmd.Parameters.AddWithValue("@zipcode",order_Master.GetZipCode());
                cmd.Parameters.AddWithValue("@total_price", order_Master.GetTotalPrice());
                cmd.Parameters.AddWithValue("@final_price", order_Master.GetFinalPrice());
                cmd.Parameters.AddWithValue("@coupon_code", order_Master.GetCouponCode());
                cmd.Parameters.AddWithValue("@order_status",order_Master.GetOrderStatus());
                cmd.Parameters.AddWithValue("@payment_status", order_Master.GetPaymentStatus());
                cmd.Parameters.AddWithValue("@payment_type", order_Master.GetPaymentType());
                cmd.Parameters.AddWithValue("@refund_status", order_Master.GetRefundStatus());
                cmd.Parameters.AddWithValue("@added_on", order_Master.GetAddedOn());
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@id"].Value);
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
        public Int32 UpdateOrderMasterPaymentStatusById(Order_Master order_Master)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Update_OrderMasterPaymentStatusById")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@payment_status", order_Master.GetPaymentStatus());
                cmd.Parameters.AddWithValue("@payment_id",order_Master.GetPaymentId());
                cmd.Parameters.AddWithValue("@id", order_Master.GetId());
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
        public DataTable DisplayOrderMasterByUserId(Customer customer)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_OrderMasterByUserId")
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
        public DataTable DisplayOrderMaster()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_OrderMaster")
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
        public DataTable DisplayOrderMasterByOId(Order_Master order_Master)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_OrderMasterByOid")
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
        public Dictionary<string, string> GetOrderByIdFunction(Order_Master order_Master)
        {
            Dictionary<string, string> getOrderById = new Dictionary<string, string>();
            DataTable dt = DisplayOrderMasterByOId(order_Master);
            try
            {               
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        getOrderById.Add("id", dr["id"].ToString());
                        getOrderById.Add("user_id", dr["user_id"].ToString());
                        getOrderById.Add("address", dr["address"].ToString());
                        getOrderById.Add("total_price", dr["total_price"].ToString());
                        getOrderById.Add("coupon_code", dr["coupon_code"].ToString());
                        getOrderById.Add("final_price", dr["final_price"].ToString());
                        getOrderById.Add("zipcode", dr["zipcode"].ToString());
                        getOrderById.Add("delivery_boy_id", dr["delivery_boy_id"].ToString());
                        getOrderById.Add("payment_status", dr["payment_status"].ToString());
                        getOrderById.Add("payment_type", dr["payment_type"].ToString());
                        getOrderById.Add("payment_id", dr["payment_id"].ToString());
                        getOrderById.Add("order_status", dr["order_status"].ToString());
                        getOrderById.Add("cancel_by", dr["cancel_by"].ToString());
                        getOrderById.Add("cancel_at", dr["cancel_at"].ToString());
                        getOrderById.Add("delivered_on", dr["delivered_on"].ToString());
                        getOrderById.Add("refund_status", dr["refund_status"].ToString());
                        getOrderById.Add("added_on", dr["added_on"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dt.Dispose();
            }
            return getOrderById;
        }
    }
}