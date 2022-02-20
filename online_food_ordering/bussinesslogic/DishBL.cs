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
        public DataTable DisplayDishCategory(string FilterType, string cat_dish_str)
        {
            DishDAO dishDAO = new DishDAO();
            try
            {
                return dishDAO.DisplayDishCategory(FilterType, cat_dish_str);
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