using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class RefundMoneyBL
    {
        public DataTable DisplayRefundDetails()
        {
            RefundMoneyDAO refundMoneyDAO = new RefundMoneyDAO();
            try
            {
                return refundMoneyDAO.DisplayRefundDetails();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                refundMoneyDAO = null;
            }
        }
        public DataTable DisplaySendMoney(Customer customer)
        {
            RefundMoneyDAO refundMoneyDAO = new RefundMoneyDAO();
            try
            {
                return refundMoneyDAO.DisplaySendMoney(customer);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                refundMoneyDAO = null;
            }
        }
        public Int32 UpdateRefundStatus(Order_Master order_Master)
        {
            RefundMoneyDAO refundMoneyDAO = new RefundMoneyDAO();
            try
            {
                return refundMoneyDAO.UpdateRefundStatus(order_Master);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                refundMoneyDAO = null;
            }
        }
    }
}