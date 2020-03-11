using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Async_SeqParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorialAsync(5);
            FactorialIntAsync(6);
            int result = FactorialIntAsync1(7).Result;
            Console.WriteLine(result);

            StrWriterAsync();

            Console.WriteLine(new string('-', 50));

            SequentialAsync();
            ParallelAsync();


            Console.ReadKey();
        }


        // Асинхонный метод обладает следующими признаками:
        // - В заголовке метода используется модификатор async
        // - Метод содержит одно или несколько выражений await
        // - В качестве возвращаемого типа используется один из следующих:
        //      - void
        //      - Task
        //      - Task<T>
        //      - ValueTask<T> - Использование типа ValueTask<T> во многом аналогично применению Task<T> за исключением
        // некоторых различий в работе с памятью, поскольку ValueTask - структура, а Task - класс. По умолчанию тип
        // ValueTask недоступен, и чтобы использовать его, вначале надо установить через NuGet пакет
        // System.Threading.Tasks.Extensions.

        // Однако асинхронный метод не может определять параметры с модификаторами out и ref.

        static async void FactorialAsync(int n)
        {
            await Task.Run(() => Factorial(n));
        }

        static async void FactorialIntAsync(int n)
        {
            var res = await Task.Run(() => FactorialInt(n));
        }

        static async Task<int> FactorialIntAsync1(int n) => await Task.Run(() => FactorialInt(n));

        static async Task StrWriterAsync()
        {
            using (var sw = new StreamWriter("file.txt", false))
            {
                await sw.WriteLineAsync("Testing...");
                sw.Close();
            }
        }


        static async Task SequentialAsync()
        {
            await Task.Run(() => Factorial(5));
            await Task.Factory.StartNew(() => Factorial(5));
            await Task.Run(() => Factorial(10));
        }

        static async Task ParallelAsync()
        {
            var t1 = Task.Factory.StartNew(() => Factorial(5));
            var t2 = Task.Factory.StartNew(() => Factorial(8));
            var t3 = Task.Factory.StartNew(() => FactorialInt(10));

            await Task.WhenAll(new[] { t1, t2, t3 });

            Console.WriteLine(t3.Result);
        }



        static void Factorial(int n)
        {
            var result = 1;
            for(var i = 1; i <= n; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            Console.WriteLine($"Факториал {n} равен = {result}");
        }

        static int FactorialInt(int n)
        {
            var result = 1;
            for (var i = 1; i <= n; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            Console.WriteLine($"Факториал {n} равен = {result}");
            return result;
        }
    }
}
