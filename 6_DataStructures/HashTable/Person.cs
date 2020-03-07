using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class Person
    {
        public Person() { }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.Length + Age + (int)Name[0];
        }
    }
}
