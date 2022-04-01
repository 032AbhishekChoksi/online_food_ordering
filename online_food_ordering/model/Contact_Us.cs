using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Contact_Us
    {
        private int id;
        private string name;
        private string email;
        private long mobile;
        private string subject;
        private string message;
        private DateTime added_on;
        private byte status;
        public Contact_Us()
        {
            id = 0;
            name = string.Empty;
            email = string.Empty;
            mobile = 0;
            subject = string.Empty;
            message = string.Empty;
            status = 1;
        }
        public Contact_Us(int id, string name, string email, long mobile, string subject, string message, DateTime added_on, byte status)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.mobile = mobile;
            this.subject = subject;
            this.message = message;
            this.added_on = added_on;
            this.status = status;
        }
        public Contact_Us(string name, string email, long mobile, string subject, string message, DateTime added_on, byte status)
        {
            this.name = name;
            this.email = email;
            this.mobile = mobile;
            this.subject = subject;
            this.message = message;
            this.added_on = added_on;
            this.status = status;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetName() => name;
        public void SetName(string name) => this.name = name;
        public string GetEmail() => email;
        public void SetEmail(string email) => this.email = email;
        public long GetMobile() => mobile;
        public void SetMobile(long mobile) => this.mobile = mobile;
        public string GetSubject() => subject;
        public void SetSubject(string subject) => this.subject = subject;
        public string GetMessage() => message;
        public void SetMessage(string message) => this.message = message;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
    }
}