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
        public Int32 InsertCustomer(Customer customer)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            try
            {
                return customerDAO.InsertCustomer(customer);
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
        public Int32 UpdateCustomer(Customer customer)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            try
            {
                return customerDAO.UpdateCustomer(customer);
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
        public DataTable DisplayCustomerByPassword(Customer customer)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            try
            {
                return customerDAO.DisplayCustomerByPassword(customer);
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
        public Int32 UpdateCustomerPasswordById(Customer customer)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            try
            {
                return customerDAO.UpdateCustomerPasswordById(customer);
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
        public Int32 DisplayCustomerIdByReferralCode(Customer customer)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            try
            {
                return customerDAO.DisplayCustomerIdByReferralCode(customer);
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