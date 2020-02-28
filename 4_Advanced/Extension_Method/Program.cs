using System;
using System.Collections.Generic;

namespace Extension_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите целое число:");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int digit))
                {
                    if (/*IsEven(digit)*/ digit.IsEven())
                    {
                        Console.WriteLine("Опа...Четенькое число");

                    }
                    else
                    {
                        Console.WriteLine("Упс...эти ваши нечеткие числа...");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Неправильный формат числа!");
                }
            }


            //var divided = 133;
            Console.WriteLine("Делится без остатка? {0}", 133.IsDivided(4));

            List<Road> list = new List<Road>()
            {
                new Road().CreateRandomRoad(100, 600),
                new Road().CreateRandomRoad(100, 600),
                new Road().CreateRandomRoad(100, 600)
            };


            Console.WriteLine($"\nСписок в одну строку:\n{list.ConvertToString()}");
             

            Console.ReadKey();
        }

        static bool IsEven(int digit) => digit % 2 == 0; 
    }
}
