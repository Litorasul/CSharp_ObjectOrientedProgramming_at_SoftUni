using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public double CoffeeMilliliters { get; set; }
        public decimal CoffeePrice { get; set; }
        public double Coffeine { get; set; }

        public Coffee(string name, decimal price, double milliliters,
            double coffeeMilliliters = 50, decimal coffeePrice = 3.50M)
            :base(name, price, milliliters)
        {
            CoffeeMilliliters = coffeeMilliliters;
            CoffeePrice = coffeePrice;
        }
    }
}
