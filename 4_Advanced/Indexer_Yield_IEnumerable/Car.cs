using System;
using System.Collections.Generic;
using System.Text;

namespace Indexer_Yield_IEnumerable
{
    class Car
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public Car(string name, string number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString() => $"Name: {Name}; Number: {Number}";
    }
}
