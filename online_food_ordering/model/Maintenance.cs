using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Maintenance
    {
        private int id;
        private string name;
        private byte status;
        public Maintenance()
        {
            id = 0;
            name = string.Empty;
            status = 0;
        }
        public Maintenance(int id,string name,byte status)
        {
            this.id = id;
            this.name = name;
            this.status = status;
        }
        public Maintenance(string name, byte status)
        {
            this.name = name;
            this.status = status;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetName() => name;
        public void SetName(string name) => this.name = name;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
    }
}