using System;
using System.Linq;

namespace P04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {

                string[] tokens = input
                        .Split(" ");
                string ingredient = tokens[0];
                string pizzaName = string.Empty;

                if (ingredient.ToLower() == "pizza")
                {
                    pizzaName = tokens[1];
                }
                tokens = Console.ReadLine()
                        .Split(" ");
                ingredient = tokens[0];
                string flour = string.Empty;
                string baking = string.Empty;
                int weight = 0;
                if (ingredient.ToLower() == "dough")
                {
                    flour = tokens[1];
                    baking = tokens[2];
                    weight = int.Parse(tokens[3]);
                }

                Dough dough = new Dough(flour.ToLower(), baking.ToLower(), weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while ((input = Console.ReadLine()) != "END")
                {
                    tokens = input
                        .Split(" ");



                    string type = tokens[1];
                    int toppingWeight = int.Parse(tokens[2]);

                    Topping topping = new Topping(type, toppingWeight);
                    pizza.AddTopping(topping);


                }
                Console.WriteLine(pizza);                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




        }
    }
}
