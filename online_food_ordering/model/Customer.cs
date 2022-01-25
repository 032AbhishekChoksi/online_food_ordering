using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Customer
    {
        private int id;
        private string name;
        private string email;
        private long mobile;
        private string password;
        private byte status;
        private byte email_verify;
        private string rand_str;
        private string referral_code;
        private string from_referral_code;
        private DateTime added_on;

        public Customer()
        {
            id = 0;
            name = string.Empty;
            email = string.Empty;
            mobile = 0;
            password = string.Empty;
            rand_str = string.Empty;
            referral_code = string.Empty;
            from_referral_code= string.Empty;
        }

        public Customer(int id, string name, string email, long mobile, string password, byte status, byte email_verify, string rand_str, string referral_code, string from_referral_code, DateTime added_on)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.mobile = mobile;
            this.password = password;
            this.status = status;
            this.email_verify = email_verify;
            this.rand_str = rand_str;
            this.referral_code = referral_code;
            this.from_referral_code = from_referral_code;
            this.added_on = added_on;
        }
        public Customer(string name, string email, long mobile, string password, byte status, byte email_verify, string rand_str, string referral_code, string from_referral_code, DateTime added_on)
        {
            this.name = name;
            this.email = email;
            this.mobile = mobile;
            this.password = password;
            this.status = status;
            this.email_verify = email_verify;
            this.rand_str = rand_str;
            this.referral_code = referral_code;
            this.from_referral_code = from_referral_code;
            this.added_on = added_on;
        }
        public Customer(int id, string name, string email, long mobile, string password, byte status, byte email_verify, string rand_str, string referral_code, DateTime added_on)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.mobile = mobile;
            this.password = password;
            this.status = status;
            this.email_verify = email_verify;
            this.rand_str = rand_str;
            this.referral_code = referral_code;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetName() => name;
        public void SetName(string name) => this.name = name;
        public string GetEmail() => email;
        public void SetEmail(string email) => this.email = email;
        public long GetMobile() => mobile;
        public void SetMobile(long mobile) => this.mobile = mobile;
        public string GetPassword() => password;
        public void SetPassword(string password) => this.password = password;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
        public byte GetEmailVerify() => email_verify;
        public void SetEmailVerify(byte email_verify) => this.email_verify = email_verify;
        public string GetRandStr() => rand_str;
        public void SetRandStr(string rand_str) => this.rand_str = rand_str;
        public string GetReferralCode() => referral_code;
        public void SetReferralCode(string referral_code) => this.referral_code = referral_code;
        public string GetFromReferralCode() => from_referral_code;
        public void SetFromReferralCode(string from_referral_code) => this.from_referral_code = from_referral_code;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}