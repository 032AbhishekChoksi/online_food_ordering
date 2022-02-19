using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class BannerBL
    {
        public DataTable DisplayBanner()
        {
            BannerDAO bannerDAO = new BannerDAO();
            try
            {
                return bannerDAO.DisplayBanner();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bannerDAO = null;
            }
        }
        public DataTable DisplayBannerByStatus()
        {
            BannerDAO bannerDAO = new BannerDAO();
            try
            {
                return bannerDAO.DisplayBannerByStatus();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bannerDAO = null;
            }
        }
        public DataTable DisplayBannerById(Banner banner)
        {
            BannerDAO bannerDAO = new BannerDAO();
            try
            {
                return bannerDAO.DisplayBannerById(banner);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bannerDAO = null;
            }

        }
        public Int32 UpdateBannerStatus(Banner banner)
        {
            BannerDAO bannerDAO = new BannerDAO();
            try
            {
                return bannerDAO.UpdateBannerStatus(banner);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bannerDAO = null;
            }
        }
        public Int32 RemoveBanner(Banner banner)
        {
            BannerDAO bannerDAO = new BannerDAO();
            try
            {
                return bannerDAO.RemoveBanner(banner);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bannerDAO = null;
            }
        }
    }
}