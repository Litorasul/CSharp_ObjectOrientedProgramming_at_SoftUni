using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private int age;
        public string Name { get; set; }
        public int Age
        {
            get
            {
               return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender { get; protected set; }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            if (gender == "Male" || gender == "Female")
            {
                Gender = gender;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid input!");
            }
        }

        public virtual void ProduceSound()
        {

        }
        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }
}
