using P08.Military.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.Military.Models 
{
    public abstract class Soldier : ISoldier
    {
        public string Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
