using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Treasure
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            var bag = new Dictionary<string, Dictionary<string, long>>();

            SortTheTreasure(bagCapacity, bag);

            foreach (var treasureType in bag)
            {
                Console.WriteLine($"<{treasureType.Key}> ${treasureType.Value.Values.Sum()}");
                foreach (var treasureItem in treasureType.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{treasureItem.Key} - {treasureItem.Value}");
                }
            }
        }

        private static void SortTheTreasure(long bagCapacity, Dictionary<string, Dictionary<string, long>> bag)
        {
            string[] treasure = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < treasure.Length; i += 2)
            {
                string name = treasure[i];
                long ammount = long.Parse(treasure[i + 1]);

                string treasureType = WhatTypeIsTheTreasure(name);

                if (treasureType == "")
                {
                    continue;
                }

                if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + ammount)
                {
                    continue;
                }

                switch (treasureType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(treasureType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (ammount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[treasureType].Values.Sum() + ammount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(treasureType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (ammount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[treasureType].Values.Sum() + ammount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(treasureType))
                {
                    bag[treasureType] = new Dictionary<string, long>();
                }

                if (!bag[treasureType].ContainsKey(name))
                {
                    bag[treasureType][name] = 0;
                }

                bag[treasureType][name] += ammount;
            }
        }


        private static string WhatTypeIsTheTreasure(string name)
        {
            string treasureType = string.Empty;

            if (name.Length == 3)
            {
                treasureType = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                treasureType = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                treasureType = "Gold";
            }

            return treasureType;
        }
    }
}