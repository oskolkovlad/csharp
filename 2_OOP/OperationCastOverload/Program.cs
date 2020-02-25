using System;


namespace OperationCastOverload
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter1 = new Counter() { Seconds = 1000 };
            int timeSec = (int)counter1;

            Console.WriteLine($"counter1 = {counter1.Seconds}");
            Console.WriteLine($"timeSec = {timeSec}");

            timeSec = 1395;
            counter1 = timeSec + 12383;
            Console.WriteLine($"counter1 = {counter1.Seconds}");


            var timer = new Timer() { Seconds = 34, Minutes = 23, Hours = 23 };
            var counter2 = new Counter() { Seconds = 3745 };

            Console.WriteLine($"\ntimer = {timer.Hours}:{timer.Minutes}:{timer.Seconds}");
            Console.WriteLine($"counter2 = {counter2.Seconds}\n");

            timer = counter2;

            Console.WriteLine($"timer = {timer.Hours}:{timer.Minutes}:{timer.Seconds}");
            Console.WriteLine($"counter2 = {counter2.Seconds}\n");

            timer = counter1;
            counter2 = (Counter)timer;

            Console.WriteLine($"timer = {timer.Hours}:{timer.Minutes}:{timer.Seconds}");
            Console.WriteLine($"counter2 = {counter2.Seconds}\n");


            Console.ReadKey();
        }
    }
}
