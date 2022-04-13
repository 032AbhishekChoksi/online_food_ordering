using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class MaintenanceBL
    {
        public DataTable DisplayMaintenanceByName(Maintenance maintenance)
        {
            MaintenanceDAO maintenanceDAO = new MaintenanceDAO();
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = maintenanceDAO.DisplayMaintenanceByName(maintenance);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                maintenanceDAO = null;
            }
            return dataTable;
        }
        public Int32 UpdateMaintenanceByName(Maintenance maintenance)
        {
            MaintenanceDAO maintenanceDAO = new MaintenanceDAO();
            int result = 0;
            try
            {
                result = maintenanceDAO.UpdateMaintenanceByName(maintenance);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                maintenanceDAO = null;
            }
            return result;
        }
    }
}