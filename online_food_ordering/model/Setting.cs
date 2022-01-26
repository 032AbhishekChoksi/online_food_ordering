using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Setting
    {
        private int id;
        private decimal cart_min_price;
        private string cart_min_price_msg;
        private string website_close;
        private string website_close_msg;
        private decimal wallet_amt;
        private decimal referral_amt;
        private string theme_color;

        public Setting()
        {
            id = 0;
            cart_min_price = 0;
            cart_min_price_msg = string.Empty;
            website_close = string.Empty;
            website_close_msg = string.Empty;
            wallet_amt = 0;
            referral_amt = 0;
            theme_color = string.Empty;
        }
        public Setting(int id, decimal cart_min_price, string cart_min_price_msg, string website_close, string website_close_msg, decimal wallet_amt, decimal referral_amt, string theme_color)
        {
            this.id = id;
            this.cart_min_price = cart_min_price;
            this.cart_min_price_msg = cart_min_price_msg;
            this.website_close = website_close;
            this.website_close_msg = website_close_msg;
            this.wallet_amt = wallet_amt;
            this.referral_amt = referral_amt;
            this.theme_color = theme_color;
        }
        public Setting(decimal cart_min_price, string cart_min_price_msg, string website_close, string website_close_msg, decimal wallet_amt, decimal referral_amt, string theme_color)
        {
            this.cart_min_price = cart_min_price;
            this.cart_min_price_msg = cart_min_price_msg;
            this.website_close = website_close;
            this.website_close_msg = website_close_msg;
            this.wallet_amt = wallet_amt;
            this.referral_amt = referral_amt;
            this.theme_color = theme_color;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public decimal GetCartMinPrice() => cart_min_price;
        public void SetCartMinPrice(decimal cart_min_price) => this.cart_min_price = cart_min_price;
        public string GetCartMinPriceMsg() => cart_min_price_msg;
        public void SetCartMinPriceMsg(string cart_min_price_msg) => this.cart_min_price_msg = cart_min_price_msg;
        public string GetWebsiteClose() => website_close;
        public void SetWebsiteClose(string website_close) => this.website_close = website_close;
        public string GetWebsiteCloseMsg() => website_close_msg;
        public void SetWebsiteCloseMsg(string website_close_msg) => this.website_close_msg = website_close_msg;
        public decimal GetWalletAmt() => wallet_amt;
        public void SetWalletAmt(decimal wallet_amt) => this.wallet_amt = wallet_amt;
        public decimal GetReferralAmt() => referral_amt;
        public void SetReferralAmt(decimal referral_amt) => this.referral_amt = referral_amt;
        public string GetThemeColor() => theme_color;
        public void SetThemeColor(string theme_color) => this.theme_color = theme_color;
    }
}