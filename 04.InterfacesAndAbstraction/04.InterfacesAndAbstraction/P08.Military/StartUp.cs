using P08.Military.Contracts;
using P08.Military.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Military
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = info[0];

                switch (type)
                {
                    case "Private":
                        {
                            ISoldier pr = CreatePrivate(info);
                            soldiers.Add(pr);
                        }
                        break;
                    case "Spy":
                        {
                            ISoldier spy = CreateSpy(info);
                            soldiers.Add(spy);
                        }
                        break;
                    case "LieutenantGeneral":
                        {
                            ISoldier general = CreateGeneral(info, soldiers);
                            soldiers.Add(general);
                        }
                        break;
                    case "Engineer":
                        {
                            if (info[5] != "Airforces" && info[5] != "Marines")
                            {
                                break;
                            }
                            ISoldier engineer = CreateEngineer(info);

                            soldiers.Add(engineer);
                        }
                        break;
                    case "Commando":
                        {
                            if (info[5] != "Airforces" && info[5] != "Marines")
                            {
                                break;
                            }
                            ISoldier commando = CreateCommando(info);

                            soldiers.Add(commando);
                        }
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static ISoldier CreateCommando(string[] info)
        {
            string id = info[1];
            string firstName = info[2];
            string lastName = info[3];
            decimal salary = decimal.Parse(info[4]);
            string corps = info[5];
            var commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < info.Length - 1; i += 2)
            {
                string codeName = info[i];
                string state = info[i + 1];
                if (state != "inProgress" && state != "Finished")
                {
                    continue;
                }
                Mission mission = new Mission(codeName, state);              
                commando.AddMission(mission);

            }
            return commando;
        }

        private static ISoldier CreateEngineer(string[] info)
        {
            string id = info[1];
            string firstName = info[2];
            string lastName = info[3];
            decimal salary = decimal.Parse(info[4]);
            string corps = info[5];

            var engineer = new Engineer(id, firstName, lastName, salary, corps);
            for (int i = 6; i < info.Length - 1; i += 2)
            {
                string partName = info[i];
                int workHours = int.Parse(info[i + 1]);
                if (workHours < 0 )
                {
                    continue;
                }
                Repair repair = new Repair(partName, workHours);
                engineer.AddRepair(repair);
            }
            return engineer;
        }

        private static ISoldier CreateGeneral(string[] info, List<ISoldier> soldiers)
        {
            string id = info[1];
            string firstName = info[2];
            string lastName = info[3];
            decimal salary = decimal.Parse(info[4]);
            var general = new LieutenantGeneral(id, firstName, lastName, salary);
            for (int i = 5; i < info.Length; i++)
            {
                ISoldier pr = soldiers.Where(x => x.Id == info[i])
                    .FirstOrDefault();
                general.AddPrivate((Private)pr);
            }
            return general;
        }

        private static ISoldier CreateSpy(string[] info)
        {
            string id = info[1];
            string firstName = info[2];
            string lastName = info[3];
            int codeNumber = int.Parse(info[4]);
            ISoldier spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private static ISoldier CreatePrivate(string[] info)
        {
            string id = info[1];
            string firstName = info[2];
            string lastName = info[3];
            decimal salary = decimal.Parse(info[4]);
            ISoldier pr = new Private(id, firstName, lastName, salary);
            return pr;
        }
    }
}
