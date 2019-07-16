using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split();
                if (info.Length == 4)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    string birthday = info[3];
                    IBuyer citizen = new Citizen(name, age, id, birthday);
                    buyers.Add(citizen);

                }
                else
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string group = info[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                IBuyer currentBuyer = buyers.Where(x => x.Name == command)
                    .FirstOrDefault();

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
            }

            int allFood = buyers.Sum(x => x.Food);
            Console.WriteLine(allFood);
        }
    }
}
