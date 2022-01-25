using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Coupon_Code
    {
        private int id;
        private string coupon_code;
        private string coupon_type;
        private decimal coupon_value;
        private decimal cart_min_value;
        private string expired_on;
        private byte status;
        private DateTime added_on;

        public Coupon_Code()
        {
            id = 0;
            coupon_code = string.Empty;
            coupon_type = string.Empty;
            coupon_value = 0;
            cart_min_value = 0;
            expired_on = string.Empty;
        }
        public Coupon_Code(int id, string coupon_code, string coupon_type, decimal coupon_value, decimal cart_min_value, string expired_on, byte status, DateTime added_on)
        {
            this.id = id;
            this.coupon_code = coupon_code;
            this.coupon_type = coupon_type;
            this.coupon_value = coupon_value;
            this.cart_min_value = cart_min_value;
            this.expired_on = expired_on;
            this.status = status;
            this.added_on = added_on;
        }
        public Coupon_Code(string coupon_code, string coupon_type, decimal coupon_value, decimal cart_min_value, string expired_on, byte status, DateTime added_on)
        {
            this.coupon_code = coupon_code;
            this.coupon_type = coupon_type;
            this.coupon_value = coupon_value;
            this.cart_min_value = cart_min_value;
            this.expired_on = expired_on;
            this.status = status;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetCouponCode() => coupon_code;
        public void SetCouponCode(string coupon_code) => this.coupon_code = coupon_code;
        public string GetCouponType() => coupon_type;
        public void SetCouponType(string coupon_type) => this.coupon_type = coupon_type;
        public decimal GetCouponValue() => coupon_value;
        public void SetCouponValue(decimal coupon_value) => this.coupon_value = coupon_value;
        public decimal GetCartMinValue() => cart_min_value;
        public void SetCartMinValue(decimal cart_min_value) => this.cart_min_value = cart_min_value;
        public string GetExpiredOn() => expired_on;
        public void SetExpiredOn(string expired_on) => this.expired_on = expired_on;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}