using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Dish_Cart
    {
        private int id;
        private int user_id;
        private int dish_detail_id;
        private int qty;
        private DateTime added_on;

        public Dish_Cart()
        {
            id = 0;
            user_id = 0;
            dish_detail_id = 0;
            qty = 0;
        }
        public Dish_Cart(int id, int user_id, int dish_detail_id, int qty, DateTime added_on)
        {
            this.id = id;
            this.user_id = user_id;
            this.dish_detail_id = dish_detail_id;
            this.qty = qty;
            this.added_on = added_on;
        }
        public Dish_Cart(int user_id, int dish_detail_id, int qty, DateTime added_on)
        {
            this.user_id = user_id;
            this.dish_detail_id = dish_detail_id;
            this.qty = qty;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public int GetUserId() => user_id;
        public void SetUserId(int user_id) => this.user_id = user_id;
        public int GetDishDetailId() => dish_detail_id;
        public void SetDishDetailId(int dish_detail_id) => this.dish_detail_id = dish_detail_id;
        public int GetQty() => qty;
        public void SetQty(int qty) => this.qty = qty;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}