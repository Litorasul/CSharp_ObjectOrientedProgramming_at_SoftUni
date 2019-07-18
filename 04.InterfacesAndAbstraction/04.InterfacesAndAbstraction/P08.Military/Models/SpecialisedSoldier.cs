using P08.Military.Contracts;
using System;

namespace P08.Military.Models
{
    public abstract class SpecialisedSoldier : Private, IPrivate, ISpecialisedSoldier
    {
        private string corps;

        public string Corps
        {
            get { return this.corps; }
            protected set
            {
              
                this.corps = value;
            }
        }

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

    }
}
