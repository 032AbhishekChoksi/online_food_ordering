using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class Delivery_BoyBL
    {
        public DataTable DisplayDeliveryBoy()
        {
            Delivery_BoyDAO delivery_BoyDAO = new Delivery_BoyDAO();
            try
            {
                return delivery_BoyDAO.DisplayDeliveryBoy();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                delivery_BoyDAO = null;
            }
        }
        public Int32 UpdateDeliveryBoyStatus(Delivery_Boy delivery_Boy)
        {
            Delivery_BoyDAO delivery_BoyDAO = new Delivery_BoyDAO();
            try
            {
                return delivery_BoyDAO.UpdateDeliveryBoyStatus(delivery_Boy);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                delivery_BoyDAO = null;
            }
        }
    }
}