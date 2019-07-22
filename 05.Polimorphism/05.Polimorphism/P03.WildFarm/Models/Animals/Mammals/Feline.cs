using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; private set; }
        public Feline(string name, double weight,
            string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
            return result;
        }
    }
}
