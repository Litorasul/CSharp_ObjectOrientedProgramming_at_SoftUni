using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public static List<Dog> List { get; set; }
        public Dog(string name, int age, string gender)
            :base(name, age, gender)
        {
            
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
