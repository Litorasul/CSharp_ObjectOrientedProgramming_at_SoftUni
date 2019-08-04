using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        public MotorcycleRepository MotorcycleRepository { get; private set; }
        public RaceRepository RaceRepository { get; private set; }
        public RiderRepository RiderRepository { get; private set; }

        public ChampionshipController()
        {
            this.MotorcycleRepository = new MotorcycleRepository();
            this.RiderRepository = new RiderRepository();
            this.RaceRepository = new RaceRepository();
        }


        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (this.RaceRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            else if (this.MotorcycleRepository.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            Motorcycle motorcycle = this.MotorcycleRepository.GetByName(motorcycleModel);
            this.RiderRepository.GetByName(riderName).AddMotorcycle(motorcycle);           

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (this.RaceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            else if (this.RiderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            Rider rider = this.RiderRepository.GetByName(riderName);
            this.RaceRepository.GetByName(raceName).AddRider(rider);         


            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.MotorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }
            string result = string.Empty;
            if (type == "Speed")
            {
                var motorcycle = new SpeedMotorcycle(model, horsePower);
                this.MotorcycleRepository.Add(motorcycle);
                result = $"{motorcycle.GetType().Name} {model} is created.";

            }
            else
            {
                var motorcycle = new PowerMotorcycle(model, horsePower);
                this.MotorcycleRepository.Add(motorcycle);
                result = $"{motorcycle.GetType().Name} {model} is created.";

            }

            return result;
        }

        public string CreateRace(string name, int laps)
        {
            if (this.RaceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            Race race = new Race(name, laps);
            this.RaceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            if (RiderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            Rider rider = new Rider(riderName);
            this.RiderRepository.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            if (this.RaceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            Race race = this.RaceRepository.GetByName(raceName);

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            List<IRider> riders = new List<IRider>();

            foreach (var rider in race.Riders.OrderBy(r => r.Motorcycle.CalculateRacePoints(race.Laps)))
            {
                riders.Add(rider);
            }

            Rider winner = (Rider)riders[0];
            Rider second = (Rider)riders[1];
            Rider third = (Rider)riders[3];

            StringBuilder result = new StringBuilder()
                .AppendLine($"Rider {winner.Name} wins {race.Name} race.")
                .AppendLine($"Rider {second} is second in {race.Name} race.")
                .AppendLine($"Rider {third} is third in {race.Name} race.");

            return result.ToString().Trim();
                
        }

        public void End()
        {
            Environment.Exit(0);
        }
    }
}
