using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class Coupon_CodeBL
    {
        public DataTable DisplayCouponCode()
        {
            Coupon_CodeDAO coupon_codeDAO = new Coupon_CodeDAO();
            try
            {
                return coupon_codeDAO.DisplayCouponCode();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coupon_codeDAO = null;
            }
        }
        public Int32 UpdateCouponCodeStatus(Coupon_Code coupon_Code)
        {
            Coupon_CodeDAO coupon_codeDAO = new Coupon_CodeDAO();
            try
            {
                return coupon_codeDAO.UpdateCouponCodeStatus(coupon_Code);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coupon_codeDAO = null;
            }
        }
        public DataTable DisplayCouponCodeByCodeAndStatus(Coupon_Code coupon_Code)
        {
            Coupon_CodeDAO coupon_codeDAO = new Coupon_CodeDAO();
            try
            {
                return coupon_codeDAO.DisplayCouponCodeByCodeAndStatus(coupon_Code);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coupon_codeDAO = null;
            }
        }
    }
}