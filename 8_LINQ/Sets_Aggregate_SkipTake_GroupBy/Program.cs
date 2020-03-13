using System;
using System.Linq;

namespace Sets_Aggregate_SkipTake_GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Операции над множествами

            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            // Объединение
            var union = soft.Union(hard);
            var concat = soft.Concat(hard);

            // Пересечение
            var intersect = soft.Intersect(hard);

            // Разность
            var except = soft.Except(hard);


            // Симметричная разность
            var sym = union.Except(intersect);


            foreach(var u in union)
            {
                Console.WriteLine(u);
            }
            Console.WriteLine();

            foreach (var c in concat)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            foreach (var i in intersect)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            foreach (var e in except)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            foreach (var s in sym)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(new string('=', 50));


            //*****************************************************************************//

            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            // Метод Aggregate
            int mult = numbers.Aggregate((x, y) => x + y);
            Console.WriteLine(mult);
            Console.WriteLine();


            // Получение размера выборки. Метод Count
            int size = (from i in numbers where i % 2 == 0 && i > 10 select i).Count();
            Console.WriteLine(size);

            int _size = numbers.Count(i => i % 2 == 0 && i > 10);
            Console.WriteLine(_size);
            Console.WriteLine();


            // Получение суммы
            int sum = numbers.Sum();
            Console.WriteLine(sum);
            Console.WriteLine();


            // Максимальное, минимальное и среднее значения
            int min = numbers.Min();
            int max = numbers.Max();
            double avr = numbers.Average();
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(avr);


            Console.WriteLine(new string('=', 50));



            //*****************************************************************************//




            Console.WriteLine(new string('=', 50));

            //*****************************************************************************//



            Console.WriteLine(new string('=', 50));



            //*****************************************************************************//


            Console.ReadKey();
        }
    }
}
