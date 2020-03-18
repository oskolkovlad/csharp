using System;
using System.Linq;

namespace AsParalell_AsOrdered
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { -2, -1, 0, 1, 2, 4, 3, 5, 6, 7, 8, };

            var factorials1 = from num in numbers.AsParallel()
                              where num > 0
                              select Factorial(num);

            var factorials2 = numbers.AsParallel().Where(num => num > 0).Select(Factorial);

            foreach(var f in factorials1)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine(new string('=', 50));

            foreach (var f in factorials2)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine(new string('=', 50));


            //*******************************************************************************************//


            (from num in numbers.AsParallel()
             where num > 0
             select Factorial(num)).ForAll(Console.WriteLine);
            Console.WriteLine(new string('=', 50));


            //*******************************************************************************************//


            var factorials3 = from n in numbers.AsParallel().AsOrdered()
                              where n > 0
                              select Factorial(n);
            foreach (var f in factorials3)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine(new string('=', 50));


            var factorials4 = from n in numbers.AsParallel().AsOrdered()
                             where n > 0
                             select Factorial(n);

            var query = from n in factorials4.AsUnordered()
                        where n > 100
                        select n;


            //*******************************************************************************************//


            Console.ReadKey();
        }

        public static int Factorial(int n)
        {
            var result = 1;
            for (var i = 1; i <= n; i++)
            {
                result += n;
            }
            return result;
        }
    }
}
