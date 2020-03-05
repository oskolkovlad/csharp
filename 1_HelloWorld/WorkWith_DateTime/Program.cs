using System;

namespace WorkWith_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var date1 = DateTime.Now;
            var date2 = DateTime.UtcNow;
            var date3 = DateTime.Today;

            var date4 = DateTime.Now.ToShortDateString();
            var date5 = DateTime.Now.ToShortTimeString();
            var date6 = DateTime.Now.ToLongDateString();

            var date7 = DateTime.Now.Subtract(date1);
            var date8 = DateTime.Now.AddDays(-655);
            var date9 = DateTime.Now.AddHours(+32);

            Console.WriteLine(date1);
            Console.WriteLine(date2);
            Console.WriteLine(date3);
            Console.WriteLine();
            Console.WriteLine(date4);
            Console.WriteLine(date5);
            Console.WriteLine(date6);
            Console.WriteLine();
            Console.WriteLine(date7);
            Console.WriteLine(date8);
            Console.WriteLine(date9);

            Console.WriteLine(new string('-', 50));


            Console.WriteLine(date1.ToString("dd.MM.yyyy"));
            Console.WriteLine(date1.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine(date1.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine();

            DateTime now = DateTime.Now;
            Console.WriteLine("D: " + now.ToString("D"));
            Console.WriteLine("d: " + now.ToString("d"));
            Console.WriteLine("F: " + now.ToString("F"));
            Console.WriteLine("f: {0:f}", now);
            Console.WriteLine("G: {0:G}", now);
            Console.WriteLine("g: {0:g}", now);
            Console.WriteLine("M: {0:M}", now);
            Console.WriteLine("O: {0:O}", now);
            Console.WriteLine("o: {0:o}", now);
            Console.WriteLine("R: {0:R}", now);
            Console.WriteLine("s: {0:s}", now);
            Console.WriteLine("T: {0:T}", now);
            Console.WriteLine("t: {0:t}", now);
            Console.WriteLine("U: {0:U}", now);
            Console.WriteLine("u: {0:u}", now);
            Console.WriteLine("Y: {0:Y}", now);


            Console.ReadKey();
        }
    }
}
