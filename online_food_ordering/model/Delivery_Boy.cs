using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Delivery_Boy
    {
        private int id;
        private string name;
        private long mobile;
        private string password;
        private byte status;
        private DateTime added_on;

        public Delivery_Boy()
        {
            id = 0;
            name = string.Empty;
            mobile = 0;
            password = string.Empty;
        }
        public Delivery_Boy(int id, string name, long mobile, string password, byte status, DateTime added_on)
        {
            this.id = id;
            this.name = name;
            this.mobile = mobile;
            this.password = password;
            this.status = status;
            this.added_on = added_on;
        }
        public Delivery_Boy(string name, long mobile, string password, byte status, DateTime added_on)
        {
            this.name = name;
            this.mobile = mobile;
            this.password = password;
            this.status = status;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetName() => name;
        public void SetName(string name) => this.name = name;
        public long GetMobile() => mobile;
        public void SetMobile(long mobile) => this.mobile = mobile;
        public string GetPassword() => password;
        public void SetPassword(string password) => this.password = password;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }

}