using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Error_CancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorialAsync(-1);
            FactorialAsync(2);

            ParallelAsync();

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            CancelAsync(token);
            Thread.Sleep(1500);
            tokenSource.Cancel();


            Console.ReadKey();
        }


        static async Task CancelAsync(CancellationToken token)
        {
            await Task.Factory.StartNew(() => Factorial(5));

            Task.Delay(100);

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана...");
                return;
            }
        }

        static async Task FactorialAsync(int n)
        {
            Task task = null;

            try
            {
                task = Task.Run(() => Factorial(n));
                await task;
            }
            catch(Exception ex)
            {
                Console.WriteLine(task.IsFaulted);
                Console.WriteLine(task.IsCompleted);
                Console.WriteLine(task.Exception.InnerException.ToString());

                await Task.Run(() => Console.WriteLine(ex.Message));
            }
            finally
            {
                await Task.Run( () => Console.WriteLine("Блок finally"));
            }
        }

        static async Task ParallelAsync()
        {
            Task allTasks = null;

            try
            {
                var t1 = Task.Factory.StartNew(() => Factorial(5));
                var t2 = Task.Factory.StartNew(() => Factorial(-8));
                var t3 = Task.Factory.StartNew(() => Factorial(10));

                allTasks = Task.WhenAll(new[] { t1, t2, t3 });

                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(allTasks.IsFaulted);
                Console.WriteLine(ex.Message);

                foreach(var t in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine("Внутреннее: " + t.Message);
                }
            }
        }



        static void Factorial(int n, CancellationToken token)
        {
            var result = 1;

            if (n < 0)
                throw new Exception("Аргумент не может быть меньше нуля!");

            for (var i = 1; i <= n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана...");
                    return;
                }

                result *= i;
                Thread.Sleep(1000);
            }

            Console.WriteLine($"Факториал {n} равен = {result}");
        }

        static void Factorial(int n)
        {
            var result = 1;

            if (n < 0)
                throw new Exception("Аргумент не может быть меньше нуля!");

            for (var i = 1; i <= n; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            Console.WriteLine($"Факториал {n} равен = {result}");
        }
    }
}
