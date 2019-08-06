using System.Collections.Generic;
using System.Linq;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Models;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public IReadOnlyCollection<IPilot> Pilots => pilots.AsReadOnly();
        public IReadOnlyCollection<IMachine> Machines => machines.AsReadOnly();

        public string HirePilot(string name)
        {
            IPilot pilot = pilots.Where(p => p.Name == name)
                .FirstOrDefault();
            if (pilot != null)
            {
                return $"Pilot {name} is hired already";
            }
            pilot = new Pilot(name);
            pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            IMachine tank = machines
                .FirstOrDefault(m => m.Name == name && m.GetType().Name == "Tank");
               
            if (tank != null)
            {
                return $"Machine {name} is manufactured already";
            }
            tank = new Tank(name, attackPoints, defensePoints);
            machines.Add(tank);

            return $"Tank {name} manufactured - attack: {attackPoints:F2}; defense: {defensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IMachine fighter = machines
                .FirstOrDefault(m => m.Name == name && m.GetType().Name == "Fighter");
            if (fighter != null)
            {
                return $"Machine {name} is manufactured already";
            }
            fighter = new Fighter(name, attackPoints, defensePoints);
            machines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {attackPoints:F2}; defense: {defensePoints:F2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = pilots.Where(p => p.Name == selectedPilotName)
                .FirstOrDefault();
            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            IMachine machine = machines.Where(m => m.Name == selectedMachineName)
                .FirstOrDefault();
            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = machines.Where(m => m.Name == attackingMachineName)
                .FirstOrDefault();
            if (attacker == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            IMachine defender = machines.Where(m => m.Name == defendingMachineName)
                .FirstOrDefault();
            if (defender == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attacker.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defender.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attacker.Attack(defender);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defender.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = pilots.Where(p => p.Name == pilotReporting)
                .FirstOrDefault();


            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = machines.Where(m => m.Name == machineName)
                .FirstOrDefault();


            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            Fighter fighter = (Fighter)machines.Where(m => m.Name == fighterName)
                .FirstOrDefault();
            if (fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            fighter.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            Tank tank = (Tank)machines.Where(m => m.Name == tankName)
                .FirstOrDefault();
            if (tank == null)
            {
                return $"Machine {tankName} could not be found";
            }
            tank.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}