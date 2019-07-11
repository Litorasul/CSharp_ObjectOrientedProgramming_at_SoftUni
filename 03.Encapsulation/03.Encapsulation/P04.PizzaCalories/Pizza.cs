using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get { return this.dough; }
            private set
            {
                this.dough = value;
            }
        }

        public IReadOnlyCollection<Topping> Toppings
        {
            get { return this.toppings.AsReadOnly(); }
            private set
            {
                this.toppings = value.ToList();
            }
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count + 1 > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double PizzaCalories()
        {
            double calories = this.Dough.DoughCalories();

            foreach (var item in this.Toppings)
            {
                calories += item.ToppingCalories();
            }

            return calories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {PizzaCalories():F2} Calories.";
        }
    }
}
