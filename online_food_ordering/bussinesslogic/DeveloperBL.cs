using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class DeveloperBL
    {
        public Int32 DisplayDeveloperByUsernameAndPassword(Developer developer)
        {
            DeveloperDAO developerDAO = new DeveloperDAO();
            try
            {
                return developerDAO.DisplayDeveloperByUsernameAndPassword(developer);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                developerDAO = null;
            }
        }
    }
}