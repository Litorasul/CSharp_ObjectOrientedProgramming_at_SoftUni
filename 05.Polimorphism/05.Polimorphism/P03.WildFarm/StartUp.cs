using P03.WildFarm.Models;
using P03.WildFarm.Models.Animals.Birds;
using P03.WildFarm.Models.Animals.Mammals;
using P03.WildFarm.Models.Animals.Mammals.Felines;
using P03.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P03.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<IAnimal> animals = new List<IAnimal>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    GetTheAnimal(animals, animalInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine( string.Join(Environment.NewLine, animals));
        }

        private static Food GetFood()
        {
            string[] foodInfo = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string food = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);
            switch (food)
            {
                case "Fruit":
                    {
                        Food fruit = new Fruit(quantity);
                        return fruit;
                    }                 
                case "Meat":
                    {
                        Food meat = new Meat(quantity);
                        return meat;
                    }
                case "Seeds":
                    {
                        Food seed = new Seeds(quantity);
                        return seed;
                    }
                case "Vegetable":
                    {
                        Food vegitable = new Vegetable(quantity);
                        return vegitable;
                    }
            }
            return null;
        }

        private static void GetTheAnimal(List<IAnimal> animals, string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            switch (type)
            {
                case "Owl":
                    {
                        int wingSize = int.Parse(animalInfo[3]);
                        Owl owl = new Owl(name, weight, wingSize);
                        owl.AskForFood();
                        animals.Add(owl);
                        Food food = GetFood();
                        owl.Eat(food);
                    }
                    break;
                case "Hen":
                    {
                        int wingSize = int.Parse(animalInfo[3]);
                        Hen hen = new Hen(name, weight, wingSize);
                        hen.AskForFood();
                        animals.Add(hen);
                        Food food = GetFood();
                        hen.Eat(food);
                    }
                    break;
                case "Mouse":
                    {
                        string livingRegion = animalInfo[3];
                        Mouse mouse = new Mouse(name, weight, livingRegion);
                        mouse.AskForFood();
                        animals.Add(mouse);
                        Food food = GetFood();
                        mouse.Eat(food);
                    }
                    break;
                case "Dog":
                    {
                        string livingRegion = animalInfo[3];
                        Dog dog = new Dog(name, weight, livingRegion);
                        dog.AskForFood();
                        animals.Add(dog);
                        Food food = GetFood();
                        dog.Eat(food);
                    }
                    break;
                case "Cat":
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        Cat cat = new Cat(name, weight, livingRegion, breed);
                        cat.AskForFood();
                        animals.Add(cat);
                        Food food = GetFood();
                        cat.Eat(food);

                    }
                    break;
                case "Tiger":
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        Tiger tiger = new Tiger(name, weight, livingRegion, breed);
                        tiger.AskForFood();
                        animals.Add(tiger);
                        Food food = GetFood();
                        tiger.Eat(food);
                    }
                    break;
            }
        }
    }
}
