using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Category
    {
        private int id;
        private string category;
        private byte status;
        private DateTime added_on;

        public Category()
        {
            id = 0;
            category = string.Empty;
            status = 1;
        }
        public Category(int id, string category, byte status, DateTime added_on)
        {
            this.id = id;
            this.category = category;
            this.status = status;
            this.added_on = added_on;
        }
        public Category(string category, byte status, DateTime added_on)
        {
            this.category = category;
            this.status = status;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetCategory() => category;
        public void SetCategory(string category) => this.category = category;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}