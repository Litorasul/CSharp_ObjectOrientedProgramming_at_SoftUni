using P08.Military.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.Military.Models
{
    public class Commando : SpecialisedSoldier, ISpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; private set; }
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public void AddMission(Mission mission)
        {
            this.Missions.Add(mission);
        }

        public override string ToString()
        {
            this.Missions = this.Missions.Where(x => x.State == "inProgress")
                .ToList();
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            sb.Append(string.Join(Environment.NewLine, this.Missions));
            return sb.ToString().Trim();
        }
    }
}
