using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class Order_MasterBL
    {
        public Int32 InsertOrderMaster(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.InsertOrderMaster(order_Master);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                order_MasterDAO = null;
            }
        }
        public Int32 UpdateOrderMasterPaymentStatusById(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.UpdateOrderMasterPaymentStatusById(order_Master);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                order_MasterDAO = null;
            }
        }
        public DataTable DisplayOrderMasterByUserId(Customer customer)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.DisplayOrderMasterByUserId(customer);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                order_MasterDAO = null;
            }
        }
    }
}