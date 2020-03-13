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
            Console.WriteLine();


            //*****************************************************************************//







            //*****************************************************************************//






            //*****************************************************************************//







            //*****************************************************************************//


            Console.ReadKey();
        }
    }
}
