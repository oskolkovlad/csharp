using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Errors_CanceledOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] numbers = new object[] { 1, 2, 3, 4, 5/*, "hello" */};

            try
            {
                /*var factorials1 = from num in numbers.AsParallel()
                                  let x = (int)num
                                  select Factorial(x);

                factorials1.ForAll(n => Console.WriteLine(n));*/


                //*************************************************************//

                CancellationTokenSource tokenSource = new CancellationTokenSource();

                new Task(() =>
                {
                    Thread.Sleep(10);
                    tokenSource.Cancel();
                }).Start();


                var factorials2 = from num in numbers.AsParallel().WithCancellation(tokenSource.Token)
                                  let x = (int)num
                                  select Factorial(x);

                factorials2.ForAll(n => Console.WriteLine(n));


            }
            catch(OperationCanceledException ex)
            {
                Console.WriteLine("Операция прервана...");
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
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
