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
    }
}