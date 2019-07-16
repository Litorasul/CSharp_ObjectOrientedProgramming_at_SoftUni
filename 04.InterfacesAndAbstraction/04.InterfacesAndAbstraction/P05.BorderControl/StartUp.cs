using System;
using System.Collections.Generic;

namespace P05.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<IIdentifiable> inhabitants = new List<IIdentifiable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    IIdentifiable citizen = new Citizen(name, age, id);
                    inhabitants.Add(citizen);
                }
                else
                {
                    string model = info[0];
                    string id = info[1];

                    IIdentifiable robot = new Robot(model, id);
                    inhabitants.Add(robot);
                }
            }

            string toDetain = Console.ReadLine();

            foreach (var item in inhabitants)
            {
                
                if (item.Id.EndsWith(toDetain))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
