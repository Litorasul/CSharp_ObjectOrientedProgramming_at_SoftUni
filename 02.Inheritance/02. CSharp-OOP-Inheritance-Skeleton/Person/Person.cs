using System;

namespace Person
{
    public class Person
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

                age = value;
            }
        }
       

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
