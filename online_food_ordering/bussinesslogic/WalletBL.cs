using online_food_ordering.dao;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace online_food_ordering.bussinesslogic
{
    public class WalletBL
    {
        public DataTable DisplayWalletDetailsByUid(Customer customer)
        {
            WalletDAO  walletDAO = new WalletDAO();
            try
            {
                return walletDAO.DisplayWalletDetailsByUid(customer);
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}