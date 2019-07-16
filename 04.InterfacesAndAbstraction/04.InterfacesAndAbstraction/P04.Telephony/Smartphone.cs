using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string site)
        {
            foreach (var letter in site)
            {
                if (char.IsDigit(letter))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }
            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            string result = $"Calling... {number}";
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
            return result;
        }
    }
}
