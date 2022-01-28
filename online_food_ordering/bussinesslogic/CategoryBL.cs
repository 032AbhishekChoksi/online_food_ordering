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
        public Category DisplayCategoryById(int p_id) {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategoryById(p_id);
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
        public DataTable DisplayCategoryByCategory(string p_category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategoryByCategory(p_category);
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
        public DataTable DisplayCategoryByCategoryAndId(int p_id, string p_category)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            try
            {
                return categoryDAO.DisplayCategoryByCategoryAndId(p_id,p_category);
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