using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class Contact_UsBL
    {
        public DataTable DisplayContactUsByStatus(Contact_Us contact_Us)
        {
            Contact_UsDAO contact_UsDAO = new Contact_UsDAO();
            try
            {
                return contact_UsDAO.DisplayContactUsByStatus(contact_Us);
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                contact_UsDAO = null;
            }
        }
        public Int32 UpdateContactUsStatus(Contact_Us contact_Us)
        {
            Contact_UsDAO contact_UsDAO = new Contact_UsDAO();
            try
            {
                return contact_UsDAO.UpdateContactUsStatus(contact_Us);
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                contact_UsDAO = null;
            }
        }
        public Int32 InserContactUs(Contact_Us contact_Us)
        {
            Contact_UsDAO contact_UsDAO = new Contact_UsDAO();
            try
            {
                return contact_UsDAO.InserContactUs(contact_Us);
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                contact_UsDAO = null;
            }
        }
    }
}