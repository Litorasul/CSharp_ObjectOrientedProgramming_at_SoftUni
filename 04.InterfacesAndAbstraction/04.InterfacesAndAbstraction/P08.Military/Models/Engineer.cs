using P08.Military.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.Military.Models
{
    public class Engineer : SpecialisedSoldier, ISpecialisedSoldier, IEngineer
    {
        public List<Repair> Repairs { get; private set; }
        public Engineer(string id, string firstName,
            string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public void AddRepair(Repair repair)
        {
            this.Repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            sb.Append(string.Join(Environment.NewLine, this.Repairs));
            return sb.ToString().Trim();
        }
    }
}
