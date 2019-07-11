using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;

        public string Type
        {
            get { return this.type; }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public int Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double ToppingCalories()
        {
            double calories = 2 * this.Weight;
            switch (this.Type.ToLower())
            {
                case "meat":
                    { calories *= 1.2; }
                    break;
                case "veggies":
                    { calories *= 0.8; }
                    break;
                case "cheese":
                    { calories *= 1.1; }
                    break;
                case "sauce":
                    { calories *= 0.9; }
                    break;
            }

            return calories;
        }

        public override string ToString()
        {
            return this.Type;
        }
    }
}
