using P08.Military.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.Military.Models
{
    public class Private : Soldier, IPrivate, ISoldier
    {
        public decimal Salary { get; private set; }

        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            string toReturn = $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
            return toReturn;
        }
    }
}
