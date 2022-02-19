using online_food_ordering.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class DishBL
    {
        public DataTable DisplayDishCategory()
        {
            DishDAO dishDAO = new DishDAO();
            try
            {
                return dishDAO.DisplayDishCategory();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dishDAO = null;
            }
        }
    }
}