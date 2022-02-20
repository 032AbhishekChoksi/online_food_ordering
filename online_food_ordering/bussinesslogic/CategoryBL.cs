using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class CategoryBL
    {
        public Int32 InsertCategory(Category category) {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.InsertCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public Int32 UpdateCategory(Category category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.UpdateCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public Category DisplayCategoryById(Category category) {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategoryById(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public DataTable DisplayCategoryByCategory(Category category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategoryByCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public DataTable DisplayCategoryByCategoryAndId(Category category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategoryByCategoryAndId(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public DataTable DisplayCategory()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategory();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public Int32 UpdateCategoryStatus(Category category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.UpdateCategoryStatus(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public Int32 RemoveCategory(Category category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.RemoveCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
        public DataTable DisplayCategoryByStatusOrderById(Category category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategoryByStatusOrderById(category);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                categoryDAO = null;
            }
        }
    }
}