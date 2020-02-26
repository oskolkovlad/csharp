using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    class Person
    {
        private byte age;

        public string Name { get; set; }
        public byte Age
        {
            get => age;
            set
            {
                if (age < 18)
                {
                    throw new AgeOverExeption("Лицам до 18 лет регистрация запрещена!!!", value);
                }
                else
                {
                    age = value;
                }
            }
        }

        public Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }
    }

    class AgeOverExeption : ArgumentException
    {
        public byte Value { get; set; }
        public AgeOverExeption(string message)
            :base(message) { }

        public AgeOverExeption(string message, byte value)
            : base(message)
        {
            Value = value;
        }
    }
}
