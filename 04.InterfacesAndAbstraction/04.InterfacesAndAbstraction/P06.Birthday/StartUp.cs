using System;
using System.Collections.Generic;

namespace P06.Birthday
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<IIdentifiable> inhabitants = new List<IIdentifiable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 5)
                {
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    string birthday = info[4];

                    IIdentifiable citizen = new Citizen(name, age, id, birthday);
                    inhabitants.Add(citizen);
                }
                else
                {
                    if (info[0] == "Pet")
                    {
                        string name = info[1];
                        string birthday = info[2];
                        IIdentifiable pet = new Pet(name, birthday);
                        inhabitants.Add(pet);
                    }
                    
                }
            }

            string birthYear = Console.ReadLine();

            foreach (var item in inhabitants)
            {

                if (item.Bitrhday.EndsWith(birthYear))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
