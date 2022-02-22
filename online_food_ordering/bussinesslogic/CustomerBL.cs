using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class CustomerBL
    {
        public DataTable DisplayCustomerByCid(Customer customer)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            try
            {
                return  customerDAO.DisplayCustomerByCid(customer);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                customerDAO = null;
            }
        }
    }
}