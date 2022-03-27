using online_food_ordering.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class Order_StatusBL
    {
        public DataTable DisplayOrderStatusOrderByOrderStatus()
        {
            Order_StatusDAO order_StatusDAO = new Order_StatusDAO();
            try
            {
                return order_StatusDAO.DisplayOrderStatusOrderByOrderStatus();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                order_StatusDAO = null;
            }
        }
    }
}