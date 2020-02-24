using System;


namespace Method
{
    class Program
    {
        static void Main(string[] args)
        {
            SayHello("Boris");


            Person person1 = new Person("Иванов", "Иван");
            Person person2 = new Person("Петров", "Петр");

            string coordinates1;
            for (var i = 0; i < 10; i++)
            {
                coordinates1 = person1.Walk();

                Console.WriteLine(coordinates1);
                Console.WriteLine(person2.Walk());
                Console.WriteLine(new string('-', 50));
            }
            Console.WriteLine(person2.Walk(3, 5, 1));

            Console.WriteLine($"\nFactorial: {Factorial(6)}");


            Console.ReadKey();
        }

        public static void SayHello(string name)
        {
            Console.WriteLine("Hello, World and {0}!\n", name);

            //return; - можем использовать и в "void" методах но без вывода аргумента или чего-либо;
            // выполняет функцию завершения выполнения метода.
        }

        // Рекурсия
        public static int Factorial(int n)
        {
            if (n <= 1)
                return n;
            else
                return n * Factorial(n - 1);
        }
    }
}
