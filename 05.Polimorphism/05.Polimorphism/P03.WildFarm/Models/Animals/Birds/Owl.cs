using P03.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"Owl does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Quantity * 0.25;
                this.FoodEaten += food.Quantity;
            }
        }
    }
}
