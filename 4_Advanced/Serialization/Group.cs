using System;

namespace Serialization
{
    [Serializable]
    public class Group
    {
        //[NonSerialized]
        private int i = 123456789;
        public int Number { get; set; }

        public string Name { get; set; }

        public Group()
        {
            Number = (new Random(DateTime.Now.Millisecond)).Next(1, 10);
            Name = Name + Number;
        }
        public Group(int number, string name)
        {
            Number = number;
            Name = name;
        }
        public override string ToString()
        {
            return $"Name: {Name}; Private field: {i}";
        }
    }
}
