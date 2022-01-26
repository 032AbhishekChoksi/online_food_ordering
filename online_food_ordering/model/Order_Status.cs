using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Order_Status
    {
        private int id;
        private string order_status;

        public Order_Status()
        {
            id = 0;
            order_status = string.Empty;
        }
        public Order_Status(int id, string order_status)
        {
            this.id = id;
            this.order_status = order_status;
        }
        public Order_Status(string order_status)
        {
            this.order_status = order_status;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetOrderStatus() => order_status;
        public void SetOrderStatus(string order_status) => this.order_status = order_status;
    }

}