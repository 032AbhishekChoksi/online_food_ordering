using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class RatingBL
    {
        public string getRatingList(Order_Detail order_Detail)
        {
            string html = string.Empty;
            RatingDAO ratingDAO = new RatingDAO();
            try
            {
                html = ratingDAO.getRatingList(order_Detail);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ratingDAO = null;
            }
            return html;
        }
        public string getRating(Order_Detail order_Detail)
        {
            string html = string.Empty;
            RatingDAO ratingDAO = new RatingDAO();
            try
            {
                html = ratingDAO.getRating(order_Detail);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ratingDAO = null;
            }
            return html;
        }
        public string getRatingByDishId(Dish dish)
        {
            string html = string.Empty;
            RatingDAO ratingDAO = new RatingDAO();
            try
            {
                html = ratingDAO.getRatingByDishId(dish);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ratingDAO = null;
            }
            return html;
        }
        public Int32 InsertRating(Rating rating)
        {
            int result = 0;
            RatingDAO ratingDAO = new RatingDAO();
            try
            {
                result = ratingDAO.InsertRating(rating);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ratingDAO = null;
            }
            return result;
        }
    }
}