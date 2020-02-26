using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await_Thread
{
    class Program
    {
        public static object locker = new object();

        /// <summary>
        /// Deadlock
        /// </summary>

        public static int i1 = 0;

        static void M1()
        {
            for (int i = 0; i <= i1; i++)
            {

            }
        }

        static void M2()
        {
            for (int i = 0; i >= i1; i--)
            {

            }
        }

        /// <summary>
        /// End Example Deadlock
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {

            #region Threads

            //*** THREADS ***//

            // если метод с параметрами, то ParameterizedThreadStart, иначе просто ThreadStart
            //Thread thread1 = new Thread(new ThreadStart(DoWork));
            //thread1.Start();

            //Thread thread2 = new Thread(new ParameterizedThreadStart(DoWorkObject));
            //thread2.Start(int.MaxValue);

            //int j = 0;
            //for (var i = 0; i < int.MaxValue; i++)
            //{
            //    j++;

            //    if (j % 10000 == 0)
            //    {
            //        Console.WriteLine("Main");
            //    }
            //}

            #endregion


            //************************************************************************************//


            #region Async/Await

            //Console.WriteLine("Begin Main...\n");
            //DoWorkAsync();
            //Console.WriteLine("\nContinue Main...\n");

            //int j = 0;
            //for (var i = 0; i < 1000; i++)
            //{
            //    j++;

            //    if (j % 10 == 0)
            //    {
            //        Console.WriteLine("...Main");
            //    }
            //}

            //Console.WriteLine("\nEnd Main...\n");

            #endregion


            //************************************************************************************//

            //var result = SaveFile("./file.txt");
            var result = SaveFileAsync("./file.txt");

            var input = Console.ReadLine();

            // Так как result имеет тип Task<bool>, то мы чтобы получить результат от Task просто bool используем .Result
            Console.WriteLine(result.Result);


            //************************************************************************************//


            Console.ReadKey();
        }


        // Асинхронная обертка для функции
        // Task<bool> потому что у функции SaveFile возвращаемый тип bool.
        static async Task<bool> SaveFileAsync(string path)
        {
            Console.WriteLine("\nBegin Async...\n");
            var result = await Task.Run(() => SaveFile(path));
            Console.WriteLine("\nEnd Async...\n");
            return result;
        }

        static bool SaveFile(string path)
        {
            // Оператор lock получает взаимоисключающую блокировку заданного объекта перед выполнением определенных операторов,
            // а затем снимает блокировку. Во время блокировки поток, удерживающий блокировку, может снова
            // поставить и снять блокировку. Любой другой поток не может получить блокировку и ожидает ее снятия.
            // Здесь locker — это выражение ссылочного типа. Оно является точным эквивалентом
            lock (locker)
            {
                var rnd = new Random();
                string text = "";

                for (int i = 0; i < 100000; i++)
                {
                    text += rnd.Next();
                }


                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.WriteLine(text);
                }
            }

            return true;
        }

        // Асинхронная обертка
        // Task потому что функция DoWork ничего не возвращает (void).
        static async Task DoWorkAsync()
        {
            Console.WriteLine("\nBegin Async...\n");
            await Task.Run(() => DoWork(1000));
            Console.WriteLine("\nEnd Async...\n");
        }

        static void DoWork()
        {
            int j = 0;
            for(var i = 0; i < 1000; i++)
            {
                j++;

                if (j % 10 == 0)
                {
                    Console.WriteLine("Do Work...");
                }
            }
        }

        static void DoWork(int max)
        {
            int j = 0;
            for (var i = 0; i < max; i++)
            {
                j++;

                if (j % 10 == 0)
                {
                    Console.WriteLine("Do Work...");
                }
            }
        }

        static void DoWorkObject(object max)
        {
            int j = 0;
            for (var i = 0; i < (int)max; i++)
            {
                j++;

                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWorkObject");
                }
            }
        }
    }
}
