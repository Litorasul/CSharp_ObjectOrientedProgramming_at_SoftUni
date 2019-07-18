using P08.Military.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.Military.Models
{
    public class LieutenantGeneral : Soldier, IPrivate, ILieutenantGeneral
    {
        public decimal Salary { get; private set; }
        public HashSet<Private> Platoon { get; private set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Platoon = new HashSet<Private>();
        }

        public void AddPrivate(Private pr)
        {
            this.Platoon.Add(pr);
        }

        public override string ToString()
        {          
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine("Privates:");           
            sb.Append(string.Join(Environment.NewLine, this.Platoon));
            return sb.ToString().Trim();
        }
    }
}
