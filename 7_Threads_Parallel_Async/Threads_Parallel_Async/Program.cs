using System;
using System.Threading;

namespace Thread_Start_Lock
{
    class Program
    {
        static int x = 0;

        public static object locker = new object();

        static void Main(string[] args)
        {
            // Статусы потока содержатся в перечислении ThreadState:

            // - Aborted: поток остановлен, но пока еще окончательно не завершен
            // - AbortRequested: для потока вызван метод Abort, но остановка потока еще не произошла
            // - Background: поток выполняется в фоновом режиме
            // - Running: поток запущен и работает(не приостановлен)
            // - Stopped: поток завершен
            // - StopRequested: поток получил запрос на остановку
            // - Suspended: поток приостановлен
            // - SuspendRequested: поток получил запрос на приостановку
            // - Unstarted: поток еще не был запущен
            // - WaitSleepJoin: поток заблокирован в результате действия методов Sleep или Join



            // Приоритеты потоков располагаются в перечислении ThreadPriority:

            // - Lowest
            // - BelowNormal
            // - Normal
            // - AboveNormal
            // - Highest


            //***********************************************************************************************************//

            var counter = new Counter(4, 2);


            Thread thread = Thread.CurrentThread;

            Console.WriteLine();
            thread.Name = "Main Tread";
            Console.WriteLine(thread.Name);
            Console.WriteLine(thread.IsAlive);
            Console.WriteLine(thread.IsBackground);
            Console.WriteLine(thread.ThreadState);
            Console.WriteLine(thread.Priority);
            Console.WriteLine();

            Thread thread1 = new Thread(new ThreadStart(GetCalc));
            //thread1.Start();

            Console.WriteLine();
            thread1.Name = "Tread 1";
            Console.WriteLine(thread1.Name);
            Console.WriteLine(thread1.IsAlive);
            Console.WriteLine(thread1.IsBackground);
            Console.WriteLine(thread1.ThreadState);
            Console.WriteLine(thread1.Priority);
            Console.WriteLine();

            Thread thread2 = new Thread(new ParameterizedThreadStart(GetCalc));
            //thread2.Start(10);

            Console.WriteLine();
            thread2.Name = "Tread 2";
            Console.WriteLine(thread2.Name);
            Console.WriteLine(thread2.IsAlive);
            Console.WriteLine(thread2.IsBackground);
            Console.WriteLine(thread2.ThreadState);
            Console.WriteLine(thread2.Priority);
            Console.WriteLine();

            Thread thread3 = new Thread(new ParameterizedThreadStart(GetCounter));
            //thread3.Start(counter);

            Console.WriteLine();
            thread3.Name = "Tread 3";
            Console.WriteLine(thread3.Name);
            Console.WriteLine(thread3.IsAlive);
            Console.WriteLine(thread3.IsBackground);
            Console.WriteLine(thread3.ThreadState);
            Console.WriteLine(thread3.Priority);
            Console.WriteLine();

            Thread thread4 = new Thread(counter.GetCount);
            //thread4.Start();

            Console.WriteLine();
            thread4.Name = "Tread 4";
            Console.WriteLine(thread4.Name);
            Console.WriteLine(thread4.IsAlive);
            Console.WriteLine(thread4.IsBackground);
            Console.WriteLine(thread4.ThreadState);
            Console.WriteLine(thread4.Priority);
            Console.WriteLine();


            for (var i = 0; i < 5; i++)
            {
                Thread threadX = new Thread(GetCounterX);
                threadX.Name = $"Поток {i}";
                threadX.Start();
            }


            // DEADLOCKes

            // Синхронизируем потоки и ограничим доступ к разделяемым ресурсам на время их использования каким-нибудь потоком.
            // Для этого используется ключевое слово lock. Оператор lock определяет блок кода, внутри которого весь код
            // блокируется и становится недоступным для других потоков до завершения работы текущего потока. 


            // Для блокировки с ключевым словом lock используется объект-заглушка, в данном случае это переменная locker. 
            // Когда выполнение доходит до оператора lock, объект locker блокируется, и на время его блокировки
            // монопольный доступ к блоку кода имеет только один поток. После окончания работы блока кода,
            // объект locker освобождается и становится доступным для других потоков.


            Console.ReadKey();
        }


        public static void GetCalc()
        {
            for(var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread1: GetCalc() - {i * i}");
                Thread.Sleep(400);
            }
        }

        public static void GetCalc(object obj)
        {
            for (var i = 0; i < (int)obj; i++)
            {
                Console.WriteLine($"Thread2_Param: GetCalc(object obj) - {i * i}");
                Thread.Sleep(500);
            }
        }

        public static void GetCounter(object obj)
        {
            Counter counter = (Counter)obj;

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread3_Counter: GetCounter(object obj) - {i * counter.X} | {i * counter.Y}");
                Thread.Sleep(600);
            }
        }

        public static void GetCounterX()
        {
            Console.WriteLine("{0}", Thread.CurrentThread.Name);

            lock (locker)
            {
                x = 1;
                for (var i = 0; i < 9; i++)
                {
                    Console.WriteLine("{0} : {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
