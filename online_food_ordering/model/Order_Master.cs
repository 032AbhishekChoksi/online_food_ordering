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

        public Order_Master(int user_id, string address, decimal total_price, string coupon_code, decimal final_price, int zipcode, int delivery_boy_id, string payment_status, string payment_type, string payment_id, int order_status, string cancel_by, byte refund_status, DateTime added_on)
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
            this.refund_status = refund_status;
            this.added_on = added_on;
        }

        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public int GetUserId() => user_id;
        public void SetUserId(int user_id) => this.user_id = user_id;
        public string GetAddress() => address;
        public void SetAddress(string address) => this.address = address;
        public decimal GetTotalPrice() => total_price;
        public void SetTotalPrice(decimal total_price) => this.total_price = total_price;
        public string GetCouponCode() => coupon_code;
        public void SetCouponCode(string coupon_code) => this.coupon_code = coupon_code;
        public decimal GetFinalPrice() => final_price;
        public void SetFinalPrice(decimal final_price) => this.final_price = final_price;
        public int GetZipCode() => zipcode;
        public void SetZipCode(int zipcode) => this.zipcode = zipcode;
        public int GetDeliveryBoyId() => delivery_boy_id;
        public void SetDeliveryBoyId(int delivery_boy_id) => this.delivery_boy_id = delivery_boy_id;
        public string GetPaymentStatus() => payment_status;
        public void SetPaymentStatus(string payment_status) => this.payment_status = payment_status;
        public string GetPaymentType() => payment_type;
        public void SetPaymentType(string payment_type) => this.payment_type = payment_type;
        public string GetPaymentId() => payment_id;
        public void SetPaymentId(string payment_id) => this.payment_id = payment_id;
        public int GetOrderStatus() => order_status;
        public void SetOrderStatus(int order_status) => this.order_status = order_status;
        public string GetCancelBy() => cancel_by;
        public void SetCancelBy(string cancel_by) => this.cancel_by = cancel_by;
        public DateTime GetCancelAt() => cancel_at;
        public void SetCancelAt(DateTime cancel_at) => this.cancel_at = cancel_at;
        public DateTime GetDeliveredOn() => delivered_on;
        public void SetDeliveredOn(DateTime delivered_on) => this.delivered_on = delivered_on;
        public byte GetRefundStatus() => refund_status;
        public void SetRefundStatus(byte refund_status) => this.refund_status = refund_status;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}