using System;
using MortalEngines.Core;
using MortalEngines.Entities.Models;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachinesManager machinesManager = new MachinesManager();

            Console.WriteLine(machinesManager.HirePilot("Kiko"));
            Console.WriteLine(machinesManager.HirePilot("Nimo"));
            Console.WriteLine(machinesManager.PilotReport("Kiko"));

            Console.WriteLine(machinesManager.ManufactureTank("T22", 50, 30));
            Console.WriteLine(machinesManager.EngageMachine("Kiko", "T22"));
            Console.WriteLine(machinesManager.EngageMachine("Nimo", "T22"));
            Console.WriteLine(machinesManager.ManufactureFighter("F3" , 60, 20));
            Console.WriteLine(machinesManager.EngageMachine("Nimo", "F3"));

            Console.WriteLine(machinesManager.EngageMachine("Kiko", "F"));
            Console.WriteLine(machinesManager.AttackMachines("F3", "T22"));
            machinesManager.ManufactureFighter("A", 34, 22);
            machinesManager.ManufactureTank("B", 43, 66.4);
            Console.WriteLine(machinesManager.AttackMachines("F3", "B"));
            Console.WriteLine(machinesManager.PilotReport("Nimo"));






        }
    }
}