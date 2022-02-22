using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class Order_DetailBL
    {
        public Int32 InsertOrder_Detail(Order_Detail order_Detail)
        {
            Order_DetailDAO order_DetailDAO = new Order_DetailDAO();
            try
            {
                return order_DetailDAO.InsertOrder_Detail(order_Detail);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                order_DetailDAO = null;
            }
        }
    }
}