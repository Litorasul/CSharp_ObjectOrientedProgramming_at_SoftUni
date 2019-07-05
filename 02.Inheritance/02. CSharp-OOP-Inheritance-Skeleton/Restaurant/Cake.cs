using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public decimal CakePrice { get; set; }

        public Cake(string name, decimal price, double grams = 250,
            double calories = 1000, decimal cakePrice = 5)
            :base(name, price, grams, calories)
        {

        }
    }
}
