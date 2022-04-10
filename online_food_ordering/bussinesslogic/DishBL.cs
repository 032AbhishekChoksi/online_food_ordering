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
        public DataTable DisplayDishCategory(string FilterCategory, string cat_dish_str, string FilterDishType, string dishType)
        {
            DishDAO dishDAO = new DishDAO();
            try
            {
                return dishDAO.DisplayDishCategory(FilterCategory, cat_dish_str,FilterDishType,dishType);
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