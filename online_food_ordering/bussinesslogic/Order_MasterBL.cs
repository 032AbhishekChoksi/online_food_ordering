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
        public DataTable DisplayOrderMaster()
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.DisplayOrderMaster();
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
        public DataTable DisplayOrderMasterByOId(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.DisplayOrderMasterByOId(order_Master);
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
        public Dictionary<string, string> GetOrderByIdFunction(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.GetOrderByIdFunction(order_Master);
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
        public DataTable DisplayOrderReportByOid(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.DisplayOrderReportByOid(order_Master);
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
        public Dictionary<string, string> GetOrderRow(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.GetOrderRow(order_Master);
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
        public Int32 UpdateOrderStatusById(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.UpdateOrderStatusById(order_Master);
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
        public Int32 UpdateOrderStatusAndCancelStatusById(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.UpdateOrderStatusAndCancelStatusById(order_Master);
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
        public Int32 UpdateDeliveryBoyStatusByOid(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.UpdateDeliveryBoyStatusByOid(order_Master);
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
        public DataTable DisplayOrderDeliveryByDeliveryBoyId(Delivery_Boy delivery_Boy)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.DisplayOrderDeliveryByDeliveryBoyId(delivery_Boy);
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
        public Int32 UpdatePaymentStatusByOIdAndDid(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.UpdatePaymentStatusByOIdAndDid(order_Master);
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
        public Int32 UpdateOrderStatusByOIdAndDid(Order_Master order_Master)
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.UpdateOrderStatusByOIdAndDid(order_Master);
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
        public DataTable DisplayLastFiveOrderDetails()
        {
            Order_MasterDAO order_MasterDAO = new Order_MasterDAO();
            try
            {
                return order_MasterDAO.DisplayLastFiveOrderDetails();
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