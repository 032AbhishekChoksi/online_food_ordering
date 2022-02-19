using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class Dish_DetailsBL
    {
        public DataTable DisplayDishDetailsByDid(Dish dish)
        {
            Dish_DetailsDAO dish_DetailsDAO = new Dish_DetailsDAO();
            try
            {
                return dish_DetailsDAO.DisplayDishDetailsByDid(dish);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dish_DetailsDAO = null;
            }
        }
        // getDishDetailById
        public DataTable DisplayDishAndDishDetailsByDDId(Dish_Details dish_Details)
        {
            Dish_DetailsDAO dish_DetailsDAO = new Dish_DetailsDAO();
            try
            {
                return dish_DetailsDAO.DisplayDishAndDishDetailsByDDId(dish_Details);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dish_DetailsDAO = null;
            }
        }
    }
}