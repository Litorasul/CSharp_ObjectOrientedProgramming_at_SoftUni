using System;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            :base(name, age)
        {
            if (age > 15)
            {
                throw new ArgumentOutOfRangeException("Child can not be older than 15!");
            }
        }
    }
}
