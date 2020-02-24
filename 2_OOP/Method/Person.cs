using System;


namespace Method
{
    public class Person
    {
        public Person(string LastName, string Name)
        {
            this.LastName = LastName;
            this.Name = Name;
        }


        public string LastName { get; set; }
        public string Name { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }


        public string Walk()
        {
            var rnd = new Random();

            X += rnd.Next(-5, 5);
            Y += rnd.Next(-5, 5);
            Z += rnd.Next(-5, 5);

            return $"{Name}({X}; {Y}; {Z})";
        }

        public string Walk(int x, int y, int z)
        {
            var rnd = new Random();

            X += x;
            Y += y;
            Z += z;

            return $"{Name}({X}; {Y}; {Z})";
        }
    }
}
