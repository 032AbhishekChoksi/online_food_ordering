using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Order_Master
    {
        private int id;
        private int user_id;
        private string address;
        private decimal total_price;
        private string coupon_code;
        private decimal final_price;
        private int zipcode;
        private int delivery_boy_id;
        private string payment_status;
        private string payment_type;
        private string payment_id;
        private int order_status;
        private string cancel_by;
        private DateTime cancel_at;
        private DateTime delivered_on;
        private byte refund_status;
        private DateTime added_on;

        public Order_Master()
        {
            id = 0;
            user_id = 0;
            address = string.Empty;
            total_price = 0;
            coupon_code = string.Empty;
            final_price = 0;
            zipcode = 0;
            delivery_boy_id = 0;
            payment_status = string.Empty;
            payment_type = string.Empty;
            order_status = 0;
            cancel_by = string.Empty;
        }

        public Order_Master(int id, int user_id, string address, decimal total_price, string coupon_code, decimal final_price, int zipcode, int delivery_boy_id, string payment_status, string payment_type, string payment_id, int order_status, string cancel_by, DateTime cancel_at, DateTime delivered_on, byte refund_status, DateTime added_on)
        {
            this.id = id;
            this.user_id = user_id;
            this.address = address;
            this.total_price = total_price;
            this.coupon_code = coupon_code;
            this.final_price = final_price;
            this.zipcode = zipcode;
            this.delivery_boy_id = delivery_boy_id;
            this.payment_status = payment_status;
            this.payment_type = payment_type;
            this.payment_id = payment_id;
            this.order_status = order_status;
            this.cancel_by = cancel_by;
            this.cancel_at = cancel_at;
            this.delivered_on = delivered_on;
            this.refund_status = refund_status;
            this.added_on = added_on;
        }
        public Order_Master(int user_id, string address, decimal total_price, string coupon_code, decimal final_price, int zipcode, int delivery_boy_id, string payment_status, string payment_type, string payment_id, int order_status, string cancel_by, DateTime cancel_at, DateTime delivered_on, byte refund_status, DateTime added_on)
        {
            this.user_id = user_id;
            this.address = address;
            this.total_price = total_price;
            this.coupon_code = coupon_code;
            this.final_price = final_price;
            this.zipcode = zipcode;
            this.delivery_boy_id = delivery_boy_id;
            this.payment_status = payment_status;
            this.payment_type = payment_type;
            this.payment_id = payment_id;
            this.order_status = order_status;
            this.cancel_by = cancel_by;
            this.cancel_at = cancel_at;
            this.delivered_on = delivered_on;
            this.refund_status = refund_status;
            this.added_on = added_on;
        }
    }
}