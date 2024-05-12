using System;
using System.Windows;

namespace WpfJobFinding
{
    static public class Check
    {
        static string alphabet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        static string num = "0123456789";
        static string alphaNum = alphabet + num;
        static public bool CheckEmpty(string s)
        {
            if (s == null || s == "" || s == " ")
            {
                return false;
            }
            return true;
        }

        static public bool CheckEmail(string email)
        {
            int t = 0;
            foreach (char c in email)
            {
                if (Convert.ToString(c) == "@")
                {
                    t++;
                }
            }
            if (t != 1) { return false; }
            string[] e = email.Split('@');
          
            if (e[1] != "gmail.com")
            {
                return false;
            }


            foreach (char s in e[0])
            {
                int q = 0;
                foreach (char c in alphaNum)
                {
                    if (c == s || s.ToString() == ".")
                    {
                        q++;
                        break;
                    }
                }
                if (q == 0) { return false; }

            }
            return true;

        }

        public static bool CheckPhone(string phone)
        {
            int n = 0;
            foreach (char c in phone)
            {
                foreach (char s in num)
                {
                    if (c == s) { n++; }
                }
            }
            if (n != 10)
            {
                return false;
            }
            return true;

        }
    }
}
