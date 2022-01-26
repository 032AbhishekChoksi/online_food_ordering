using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Wallet
    {
        private int id;
        private int user_id;
        private decimal amt;
        private string msg;
        private string wallet_type;
        private string payment_id;
        private DateTime added_on;

        public Wallet()
        {
            id = 0;
            user_id = 0;
            amt = 0;
            msg = string.Empty;
            wallet_type = string.Empty;
            payment_id = string.Empty;
        }
        public Wallet(int id, int user_id, decimal amt, string msg, string wallet_type, string payment_id, DateTime added_on)
        {
            this.id = id;
            this.user_id = user_id;
            this.amt = amt;
            this.msg = msg;
            this.wallet_type = wallet_type;
            this.payment_id = payment_id;
            this.added_on = added_on;
        }
        public Wallet(int user_id, decimal amt, string msg, string wallet_type, string payment_id, DateTime added_on)
        {
            this.user_id = user_id;
            this.amt = amt;
            this.msg = msg;
            this.wallet_type = wallet_type;
            this.payment_id = payment_id;
            this.added_on = added_on;
        }
        public Wallet(int id, int user_id, decimal amt, string msg, string wallet_type, DateTime added_on)
        {
            this.id = id;
            this.user_id = user_id;
            this.amt = amt;
            this.msg = msg;
            this.wallet_type = wallet_type;
            this.added_on = added_on;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public int GetUserId() => user_id;
        public void SetUserId(int user_id) => this.user_id = user_id;
        public decimal GetAmt() => amt;
        public void SetAmt(decimal amt) => this.amt = amt;
        public string GetMsg() => msg;
        public void SetMsg(string msg) => this.msg = msg;
        public string GetWalletType() => wallet_type;
        public void SetWalletType(string wallet_type) => this.wallet_type = wallet_type;
        public string GetPaymentId() => payment_id;
        public void SetPaymentId(string payment_id) => this.payment_id = payment_id;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
    }
}