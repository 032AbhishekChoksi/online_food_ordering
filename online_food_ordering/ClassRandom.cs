using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering
{
    public class ClassRandom
    {
        public static string GetRandomPassword(int length)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(1, chars.Length);
                //For avoiding Repetation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i = i - 1;
            }
            return password;
        }
        public static string GetRandomMobile(int length)
        {
            length = length + 1;
            Random random = new Random();
            string mobile = string.Empty;
            int i;
            for (i = 1; i < length; i++)
            {
                mobile += random.Next(0, 9).ToString();
            }
            return mobile;
        }
    }
}