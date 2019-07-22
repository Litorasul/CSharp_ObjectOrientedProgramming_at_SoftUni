using P03.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(IFood food)
        {

            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Quantity * 0.1;
                this.FoodEaten += food.Quantity;
            }
        }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
            return result;
        }
    }
}
