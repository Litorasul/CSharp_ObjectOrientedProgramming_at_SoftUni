using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories
{
    public class Dough
    {
        private int weight;
        private string flour;
        private string baking;

        public int Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public string Flour
        {
            get { return this.flour; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flour = value;
            }
        }
        public string Baking
        {
            get { return this.baking; }
            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.baking = value;
            }
        }

        public Dough(string flour, string baking, int weight)
        {
            this.Flour = flour;
            this.Baking = baking;
            this.Weight = weight;
        }

        public double DoughCalories()
        {
            double calories = 2 * this.Weight;
            switch (this.Flour)
            {
                case "white":
                    { calories *= 1.5; }
                    break;
                case "wholegrain":
                    { calories *= 1.0; }
                    break;
            }

            switch (this.Baking)
            {
                case "crispy":
                    { calories *= 0.9; }
                    break;
                case "chewy":
                    { calories *= 1.1; }
                    break;
                case "homemade":
                    { calories *= 1.0; }
                    break;
            }
            return calories;

        }
    }
}
