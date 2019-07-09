using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50M;
        private const double CoffeeMilliliters = 50;
    
        public double Coffeine { get; set; }

        public Coffee(string name, double coffeine)
            :base(name, CoffeePrice, CoffeeMilliliters)
        {
            Coffeine = coffeine;
        }
    }
}
