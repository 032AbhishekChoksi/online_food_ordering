using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Dish_Details
    {
        private int id;
        private int dish_id;
        private string attribute;
        private int price;
        private byte status;
        private DateTime added_on;

        public Dish_Details()
        {
            id = 0;
            dish_id = 0;
            attribute = string.Empty;
            price = 0;
        }
        public Dish_Details(int id, int dish_id, string attribute, int price, byte status, DateTime added_on)
        {
            this.id = id;
            this.dish_id = dish_id;
            this.attribute = attribute;
            this.price = price;
            this.status = status;
            this.added_on = added_on;
        }
        public Dish_Details(int dish_id, string attribute, int price, byte status, DateTime added_on)
        {
            this.dish_id = dish_id;
            this.attribute = attribute;
            this.price = price;
            this.status = status;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public int GetDishID() => dish_id;
        public void SetDishID(int dish_id) => this.dish_id = dish_id;
        public string GetAttribute() => attribute;
        public void SetAttribute(string attribute) => this.attribute = attribute;
        public int GetPrice() => price;
        public void SetPrice(int price) => this.price = price;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;

    }
}