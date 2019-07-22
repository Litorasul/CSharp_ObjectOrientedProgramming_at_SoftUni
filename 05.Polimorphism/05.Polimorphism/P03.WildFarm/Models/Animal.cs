using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public abstract void AskForFood();
        public abstract void Eat(IFood food);
    }
}
