using System;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            int result = Factorial(number);

            Console.WriteLine($"Факториал числа {number} равен {result}");
        }

        public static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
