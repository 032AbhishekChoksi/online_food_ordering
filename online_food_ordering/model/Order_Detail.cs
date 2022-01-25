using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Order_Detail
    {
        private int id;
        private int order_id;
        private int dish_detail_id;
        private int qty;

        public Order_Detail()
        {
            id = 0;
            order_id = 0;
            dish_detail_id = 0;
            qty = 0;
        }
        public Order_Detail(int id, int order_id, int dish_detail_id, int qty)
        {
            this.id = id;
            this.order_id = order_id;
            this.dish_detail_id = dish_detail_id;
            this.qty = qty;
        }
        public Order_Detail(int order_id, int dish_detail_id, int qty)
        {
            this.order_id = order_id;
            this.dish_detail_id = dish_detail_id;
            this.qty = qty;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public int GetOrderId() => order_id;
        public void SetOrderId(int order_id) => this.order_id = order_id;
        public int GetDishDetailId() => dish_detail_id;
        public void SetDishDetailId(int dish_detail_id) => this.dish_detail_id = dish_detail_id;
        public int GetQty() => qty;
        public void SetQty(int qty) => this.qty = qty;
    }
}