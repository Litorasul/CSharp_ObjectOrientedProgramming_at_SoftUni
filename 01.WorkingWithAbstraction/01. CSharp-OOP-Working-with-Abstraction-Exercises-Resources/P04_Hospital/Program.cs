using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();

            RegisterPatients(doctors, departments);

            PrintOutput(doctors, departments);
        }

        private static void PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }

        private static void RegisterPatients(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                string department = tokens[0];
                string firstName = tokens[1];
                string familyName = tokens[2];
                string patient = tokens[3];
                string fullName = firstName + familyName;

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                bool hasFreeBeds = departments[department]
                    .SelectMany(x => x).Count() < 60;
                if (hasFreeBeds)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);
                    for (int curentRoom = 0; curentRoom < departments[department].Count; curentRoom++)
                    {
                        if (departments[department][curentRoom].Count < 3)
                        {
                            room = curentRoom;
                            break;
                        }
                    }
                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }
        }
    }
}
