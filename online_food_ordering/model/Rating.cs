using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Rating
    {
        private int id;
        private int user_id;
        private int order_id;
        private int dish_detail_id;
        private int rating;
        private DateTime added_on;
        public Rating()
        {
            id = 0;
            user_id = 0;
            order_id = 0;
            dish_detail_id = 0;
            rating = 0;
        }
        public Rating(int id, int user_id, int order_id, int dish_detail_id, int rating, DateTime added_on)
        {
            this.id = id;
            this.user_id = user_id;
            this.order_id = order_id;
            this.dish_detail_id = dish_detail_id;
            this.rating = rating;
            this.added_on = added_on;
        }
        public Rating(int user_id, int order_id, int dish_detail_id, int rating, DateTime added_on)
        {
            this.user_id = user_id;
            this.order_id = order_id;
            this.dish_detail_id = dish_detail_id;
            this.rating = rating;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public int GetUserId() => user_id;
        public void SetUserId(int user_id) => this.user_id = user_id;
        public int GetOrderId() => order_id;
        public void SetOrderId(int order_id) => this.order_id = order_id;
        public int GetDishDetailId() => dish_detail_id;
        public void SetDishDetailId(int dish_detail_id) => this.dish_detail_id = dish_detail_id;
        public int GetRating() => rating;
        public void SetRating(int rating) => this.rating = rating;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}