using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Метод Parallel.Invoke в качестве параметра принимает массив объектов Action, то есть мы можем
            // передать в данный метод набор методов, которые будут вызываться при его выполнении.

            Parallel.Invoke(
                () => Console.WriteLine("Wow | " + Task.CurrentId),
                () => FactorialCycle1(5),
                () => {
                    Console.WriteLine("Wow woW... | " + Task.CurrentId);
                    Thread.Sleep(1000);
                });

            Console.WriteLine();

            ParallelLoopResult fact = Parallel.For(1, 10, FactorialCycle);
            if (!fact.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {fact.LowestBreakIteration}");

            Console.WriteLine();
            //Parallel.ForEach(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, FactorialCycle);
            Console.WriteLine();

            Console.WriteLine("Main Program...");


            Console.ReadKey();
        }

        public static void FactorialCycle1(int x)
        {
            var fact = 1;
            for (var i = 1; i <= x; i++)
            {
                fact *= i;
            }

            Console.WriteLine($"Факториал {x} равен = {fact} | " + Task.CurrentId);
        }

        public static void FactorialCycle(int x, ParallelLoopState pls)
        {
            var fact = 1;
            for (var i = 1; i <= x; i++)
            {
                fact *= i;
                if (i == 5)
                    pls.Break();
            }

            Console.WriteLine($"Факториал {x} равен = {fact} | " + Task.CurrentId);
        }
    }
}
