﻿using ValidationAttributes.Attributes;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        private const int minAge = 12;
        private const int maxAge = 90;
        [MyRequired]
        public string FullName { get; private set; }
        [MyRange(minAge, maxAge)]
        public int Age { get; private set; }

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
    }
}
