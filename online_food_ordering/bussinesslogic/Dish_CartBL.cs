using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using online_food_ordering.dao;
using online_food_ordering.model;
namespace online_food_ordering.bussinesslogic
{
    public class Dish_CartBL
    {
        public DataTable DisplayDishDetailsByDdidAndUid(Customer customer, Dish_Details dish_Details)
        {
            Dish_CartDAO dish_CartDAO = new Dish_CartDAO();
            try
            {
                return dish_CartDAO.DisplayDishDetailsByDdidAndUid(customer, dish_Details);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dish_CartDAO = null;
            }
        }
        public Int32 InsertDishCart(Dish_Cart dish_Cart)
        {
            Dish_CartDAO dish_CartDAO = new Dish_CartDAO();
            try
            {
                return dish_CartDAO.InsertDishCart(dish_Cart);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dish_CartDAO = null;
            }
        }
        public Int32 UpdateDishCart(Dish_Cart dish_Cart)
        {
            Dish_CartDAO dish_CartDAO = new Dish_CartDAO();
            try
            {
                return dish_CartDAO.UpdateDishCart(dish_Cart);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dish_CartDAO = null;
            }
        }
    }
}