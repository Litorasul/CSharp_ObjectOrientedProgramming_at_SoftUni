using System;
using System.Collections.Generic;
using System.Text;

namespace P06.Birthday
{
    public class Pet : IIdentifiable
    {
        public string Bitrhday { get; private set; }
        public string Name { get; set; }

        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Bitrhday = birthday;
        }

        public override string ToString()
        {
            return this.Bitrhday;
        }
    }
}
