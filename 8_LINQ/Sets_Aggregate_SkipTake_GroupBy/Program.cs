using System;
using System.Collections.Generic;
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

            int[] numb = { -3, -2, -1, 0, 1, 2, 3 };

            var take_skip = numb.Skip(3).Take(5);
            foreach(var t in take_skip)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();


            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            var takeWhile = teams.TakeWhile(t => t.ToLower().StartsWith("б"));
            foreach (var t in takeWhile)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            var skipWhile = teams.SkipWhile(t => t.ToLower().StartsWith("б"));
            foreach (var s in skipWhile)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine(new string('=', 50));


            //*****************************************************************************//

            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5"     , Company="Xiaomi" },
                new Phone {Name="LG G 3"   , Company="LG" },
                new Phone {Name="iPhone 5" , Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6" , Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4"   , Company="LG" }
            };

            // Если в выражении LINQ последним оператором, выполняющим операции над выборкой, является group, то оператор select не применяется.
            var groups = from p in phones
                         group p by p.Company;

            foreach(var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach(var phone in group)
                {
                    Console.WriteLine("\t{0}", phone.Name);
                }
            }
            Console.WriteLine();

            var countGroups = from p in phones
                              group p by p.Company into g
                              select new { Name = g.Key, Count = g.Count() };

            foreach(var g in countGroups)
            {
                Console.WriteLine($"{g.Name} - {g.Count}");
            }


            Console.WriteLine(new string('=', 50));



            //*****************************************************************************//


            Console.ReadKey();
        }
    }

    public class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
