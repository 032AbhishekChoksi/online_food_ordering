using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class SettingBL
    {
        public Setting DisplaySettingById(Setting setting)
        {
            SettingDAO settingDAO = new SettingDAO();
            try
            {
                return settingDAO.DisplaySettingById(setting);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                settingDAO = null;
            }
        }
        public Int32 UpdateSetting(Setting setting)
        {
            SettingDAO settingDAO = new SettingDAO();
            try
            {
                return settingDAO.UpdateSetting(setting);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                settingDAO = null;
            }
        }
    }
}