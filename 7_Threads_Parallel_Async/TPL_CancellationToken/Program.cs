using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_CancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            // Токен
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;


            // Для Task
            Task task = new Task(() => FactorialCycle(5, token));
            task.Start();

            Console.WriteLine("Введите Y для отмены операции или любой другой символ для ее продолжения:");
            var key = Console.ReadLine();

            if (key.ToLower().Equals("y"))
                tokenSource.Cancel();

            Console.WriteLine(new string('-', 50));



            // Токен
            CancellationTokenSource tokenSource1 = new CancellationTokenSource();
            CancellationToken token1 = tokenSource1.Token;

            // Для Parallel

            new Task(() =>
            {
                Thread.Sleep(400);
                tokenSource1.Cancel();
            });

            try
            {
                ParallelLoopResult result = Parallel.ForEach(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                                                             new ParallelOptions { CancellationToken = token },
                                                             FactorialCycle);

            }
            catch(OperationCanceledException ex)
            {
                Console.WriteLine("Операция была прервана!!!");
            }
            finally
            {
                tokenSource1.Dispose();
            }


            Console.ReadKey();
        }

        public static void FactorialCycle(int x, CancellationToken token)
        {
            var fact = 1;
            for (var i = 1; i <= x; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция была прервана...");
                    return;
                }

                fact *= i;
                Thread.Sleep(3000);
            }
           
            Console.WriteLine($"Факториал {x} равен = {fact} | " + Task.CurrentId);
        }

        public static void FactorialCycle(int x)
        {
            var fact = 1;
            for (var i = 1; i <= x; i++)
            {
                fact *= i;
                Thread.Sleep(3000);
            }

            Console.WriteLine($"Факториал {x} равен = {fact} | " + Task.CurrentId);
        }
    }
}
