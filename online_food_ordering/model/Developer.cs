using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Developer
    {
        private int id;
        private string name;
        private string username;
        private string password;
        private string email;

        public Developer()
        {
            id = 0;
            name = string.Empty;
            username = string.Empty;
            password = string.Empty;
            email = string.Empty;
        }
        public Developer(int id, string name, string username, string password, string email)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        public Developer(string name, string username, string password, string email)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetName() => name;
        public void SetName(string name) => this.name = name;
        public string GetUserName() => username;
        public void SetUserName(string username) => this.username = username;
        public string GetPassword() => password;
        public void SetPassword(string password) => this.password = password;
        public string GetEmail() => email;
        public void SetEmail(string email) => this.email = email;
    }
}