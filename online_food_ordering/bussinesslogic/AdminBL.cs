using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class AdminBL
    {
        public Int32 DisplayAdminByUsernameAndPassword(Admin admin)
        {
            AdminDAO adminDAO = new AdminDAO();
            try
            {
                return adminDAO.DisplayAdminByUsernameAndPassword(admin);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                adminDAO = null;
            }
        }
    }
}