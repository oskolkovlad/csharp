using System;

namespace LazyCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();

            reader.ReadEBook();
            reader.ReadEBook();
            reader.ReadEBook();
            reader.ReadBook();

            Console.ReadKey();
        }
    }
}
