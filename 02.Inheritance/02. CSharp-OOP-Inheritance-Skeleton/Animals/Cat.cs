using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public static List<Cat> List { get; set; }
        public Cat(string name, int age, string gender)
            :base(name, age, gender)
        {
            
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow meow");
        }
    }
}
