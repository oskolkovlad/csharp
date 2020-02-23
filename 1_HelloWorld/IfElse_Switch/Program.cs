using System;
using System.Collections.Generic;


namespace IfElse_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            //*** Условный оператор - IF ... ELSE ***//

            int a = 7, b = 10;

            // Логические опреаторы - >, <, >=, <=, ==, !=, ||, &&
            if (a > b)
            {
                Console.WriteLine(a);
                b -= 1;
            } else
            {
                Console.WriteLine(b);
                a += 1;
            }

            a = b;
            if (a > b)
            {
                Console.WriteLine(a);
                b -= 1;
            }
            else if (a == b)
            {
                Console.WriteLine("Переменные равны!");
            }
            else
            {
                Console.WriteLine(b);
                a += 1;
            }


            //*********************************************************************//


            //*** Услованя конструкция - SWITCH ***//

            int k = new Random().Next(0, 3);

            switch (k)
            {
                case 0:
                    Console.WriteLine("Case 1");
                    break;
                case 1:
                    Console.WriteLine("Case 2");
                    break;
                case 2:
                    Console.WriteLine("Case 3");
                    break;
                case 3:
                    Console.WriteLine("Case 4");
                    break;
                default:
                    Console.WriteLine("Default...");
                    break;
            }


            //*********************************************************************//


            //*** Тернарный условный оператор ***//

            // condition ? consequent : alternative
            int j = 1 > 0 ? 1 : 5;
            Console.WriteLine(j);


            //*********************************************************************//


            Console.Write("Input Digit 1:\t");
            int digit1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Digit 2:\t");
            int digit2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Digit 3:\t");
            int digit3 = Convert.ToInt32(Console.ReadLine());
            int digitMax = 0;

            if ((digit1 >= digit2 && digit1 > digit3) || (digit1 > digit2 && digit1 >= digit3))
            {
                Console.WriteLine($"\nMax:\t{digit1}");
                digitMax = digit1;
            }
            else if ((digit2 >= digit1 && digit2 > digit3) || (digit2 > digit1 && digit2 >= digit3))
            {
                Console.WriteLine($"Max:\t{digit2}");
                digitMax = digit2;
            }
            else if (digit1 == digit2 && digit1 == digit3)
            {
                Console.WriteLine($"Все введенные числа равны и следовательно Max:\t{digit1}");
                digitMax = digit1;
            }

            else
            {
                Console.WriteLine($"Max:\t{digit3}");
                digitMax = digit3;
            }

            switch (digitMax % 2)
            {
                case 0:
                    Console.WriteLine("Max digit is even ...");
                    break;
                case 1:
                    Console.WriteLine("Max digit is odd ...");
                    break;
            }

            Console.WriteLine(digitMax > 100 ? "More then 100" : "Less then 100");


            //*********************************************************************//


            Console.ReadKey();
        }
    }
}
