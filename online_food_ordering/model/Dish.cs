using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Dish
    {
        private int id;
        private int category_id;
        private string dish_name;
        private string dish_desc;
        private string image;
        private string type;
        private byte status;
        private DateTime added_on;

        public Dish()
        {
            id = 0;
            category_id = 0;
            dish_name = string.Empty;
            dish_desc = string.Empty;
            image = string.Empty;
            type = string.Empty;
        }

        public Dish(int id, int category_id, string dish_name, string dish_desc, string image, string type, byte status, DateTime added_on)
        {
            this.id = id;
            this.category_id = category_id;
            this.dish_name = dish_name;
            this.dish_desc = dish_desc;
            this.image = image;
            this.type = type;
            this.status = status;
            this.added_on = added_on;
        }

        public Dish(int category_id, string dish_name, string dish_desc, string image, string type, byte status, DateTime added_on)
        {
            this.category_id = category_id;
            this.dish_name = dish_name;
            this.dish_desc = dish_desc;
            this.image = image;
            this.type = type;
            this.status = status;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public int GetCategoryId() => category_id;
        public void SetCategoryId(int category_id) => this.category_id = category_id;
        public string GetDishName() => dish_name;
        public void SetDishName(string dish_name) => this.dish_name = dish_name;
        public string GetDishDesc() => dish_desc;
        public void SetDishDesc(string dish_desc) => this.dish_desc = dish_desc;
        public string GetImage() => image;
        public void SetImage(string image) => this.image = image;
        public string GetDishType() => type;
        public void SetDishType(string type) => this.type = type;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}