using P03.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,
            string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(IFood food)
        {

            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Quantity * 0.30;
                this.FoodEaten += food.Quantity;
            }
        }
    }
}
