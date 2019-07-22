using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models
{
    public abstract class Food : IFood
    {
        public int Quantity { get; private set; }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
