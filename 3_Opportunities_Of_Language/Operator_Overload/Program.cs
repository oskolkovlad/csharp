using System;


namespace Operator_Overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Apple apple1 = new Apple("Красное яблоко", 100, 100);
            Apple apple2 = new Apple("Зеленое яблоко", 90, 110);

            var appleSum1 = Apple.Add(apple1, apple2);
            var appleSum2 = apple1 + apple2;

            Console.WriteLine(apple1);
            Console.WriteLine(apple2);
            Console.WriteLine(appleSum1);
            Console.WriteLine(appleSum2);

            Console.WriteLine(apple1 == apple2);
            Console.WriteLine(appleSum1 == appleSum2);


            Console.ReadKey();
        }
    }
}
