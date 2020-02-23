using System;
using System.Collections.Generic;


namespace Cycles
{
    class Program
    {
        static void Main(string[] args)
        {
            //*** FOR ***//

            List<int> list = new List<int>
            {
                1, 2, 3, 4, 5
            };

            // for (<инициализация>; <условие>; <порядок выполнения>)
            for (int i = 0; i < 3; i++)
            {
                list.Add(i);
            }

            //for(,,){} - бесконечный цикл


            // foreach (var <Элемент массива> in <Массив>) - для работы с коллекциями
            // !!! - нельзя присваивать элементам коллекции какое-то значение
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"\nLength:\t{list.Count}");


            //********************************************************************//


            //*** WHILE ***//

            // while (<Условие>)
            while (list.Count > 5)
            {
                list.RemoveAt(list.Count - 1);
            }

            // while (true) - бесконечный цикл


            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"\nLength:\t{list.Count}");


            //********************************************************************//


            //*** DO ... WHILE ***//

            // do ... while (<Условие>)
            do
            {
                list.RemoveAt(list.Count - 1);

            } while (list.Count > 3);

            // do ... while (true) - бесконечный цикл


            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"\nLength:\t{list.Count}");


            //********************************************************************//


            /*
             * Для управления циклом в языке C# используются два оператора: break и continue.
             * Оператор break используется для прерывания выполнения цикла.
             * Оператор continue используется для перехода к следующей итерации цикла.
            */


            //********************************************************************//


            List<int> listTask = new List<int>();
            const int N = 5;
            int count = 0;

            Console.WriteLine("\nВведите {0} целых числел в список.", N);
            while (count < N)
            {
                if (int.TryParse(Console.ReadLine(), out int parseResult)) {
                    listTask.Add(parseResult);
                    count++;
                }
                else
                {
                    Console.WriteLine("Введенное не является целым числом или чмслом вовсе. Повторите попытку...");
                }
            }

            int res = 0;
            for (int i = 0; i < listTask.Count; i++)
            {
                res += listTask[i];
            }
            Console.WriteLine("\nSum = {0}", res);

            res = 0;
            count = listTask.Count - 1;
            while (count >= 0)
            {
                res -= listTask[count];
                count--;
            }
            Console.WriteLine("Dif = {0}", res);

            res = 1;
            count = listTask.Count - 1;
            do
            {
                res *= listTask[count];
                count--;
            } while (count >= 0);
            Console.WriteLine("Mult = {0}\n", res);

            foreach (int i in listTask)
            {
                Console.WriteLine(i);
            }


            Console.ReadKey();
        }
    }
}
