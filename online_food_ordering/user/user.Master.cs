﻿using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class user : System.Web.UI.MasterPage
    {
        private ClassFunction classFunction;
        private ClassUser objUser;
        // Fronted Access Variable
        protected Dictionary<int, Dictionary<string, string>> cartArr;
        protected Int32 totalPrice;
        protected Int32 totalCartDish;
        private SettingBL settingBL;
        protected string websiteclose = string.Empty;
        protected string websiteclosemsg = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            classFunction = new ClassFunction();
            objUser = new ClassUser();
            settingBL = new SettingBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.SetId(1);
            setting = settingBL.DisplaySettingById(setting);
            if (setting != null)
            {
                websiteclose = setting.GetWebsiteClose();
                websiteclosemsg = setting.GetWebsiteCloseMsg();
            }

            cartArr = classFunction.getUserFullCart();
            totalPrice = classFunction.getcartTotalPrice();
            totalCartDish = cartArr.Count;
            decimal amt = 0;
            if (Session["FOOD_USER_NAME"] != null)
            {
                int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
                amt= objUser.getWalletAmt(Convert.ToInt32(uid));
                lblUsreName.Text = Session["FOOD_USER_NAME"].ToString();
            }
            lblWalletAmount.Text = "₹" + Math.Round(amt).ToString();
        }
    }
}