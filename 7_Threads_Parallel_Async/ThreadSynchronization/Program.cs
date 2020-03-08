//#define MONITOR
//#define AUTORESETEVENT
//#define MUTEX
#define SEMAPHORE

using System;
using System.Threading;

namespace ThreadSynchronization
{
    class Program
    {
#if MONITOR
        public static object locker = new object();

#endif
        public static int x = 0;

#if AUTORESETEVENT
        // Передавая в конструктор значение true, мы тем самым указываем, что создаваемый объект изначально будет в сигнальном состоянии.
        static AutoResetEvent lockEvent = new AutoResetEvent(true);
#endif

#if MUTEX
        static Mutex mutex = new Mutex();
#endif

        static void Main(string[] args)
        {

#if MONITOR || AUTORESETEVENT || MUTEX
            for (var i = 0; i < 6; i++)
            {
                Thread thread = new Thread(GetCountX);
                thread.Name = "Thread " + i;
                thread.Start();
            }
#endif

#if SEMAPHORE

            Reader.semaphore.Release();
            Reader.semaphore.Release();

            for (var i = 0; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }
#endif


            Console.ReadKey();
        }

        static void GetCountX()
        {
#if MONITOR
            bool acquiredLock = false;

            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                // Метод Monitor.Enter принимает два параметра - объект блокировки и значение типа bool,
                // которое указывает на результат блокировки (если он равен true, то блокировка успешно выполнена).
#endif

#if AUTORESETEVENT
            lockEvent.WaitOne(); // Первый пришедший поток захватывает ресурсы, остальные ждут пока он закончит. Перевод в несиг-ое состояние.
#endif

#if MUTEX
            mutex.WaitOne();
#endif

                x = 1;
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
                    x++;
                    Thread.Sleep(100);
                }

#if MONITOR
            }
            finally
            {
                if (acquiredLock) Monitor.Exit(locker);

                // Кроме блокировки и разблокировки объекта класс Monitor имеет еще ряд методов, которые
                // позволяют управлять синхронизацией потоков. Так, метод Monitor.Wait освобождает блокировку объекта и
                // переводит поток в очередь ожидания объекта. Следующий поток в очереди готовности объекта блокирует данный объект.
                // А все потоки, которые вызвали метод Wait, остаются в очереди ожидания, пока не получат сигнала
                // от метода Monitor.Pulse или Monitor.PulseAll, посланного владельцем блокировки.
                // Если метод Monitor.Pulse отправил сигнал, то поток, находящийся во главе очереди ожидания,
                // получает сигнал и блокирует освободившийся объект. Если же метод Monitor.PulseAll отправлен,
                // то все потоки, находящиеся в очереди ожидания, получают сигнал и переходят в очередь готовности, где
                // им снова разрешается получать блокировку объекта.

            }
#endif

#if AUTORESETEVENT
            lockEvent.Set(); // Первый пришедший поток закончит, и перевел делегат в сигнальное состояние

            // Если у нас в программе используются несколько объектов AutoResetEvent, то мы можем использовать
            // для отслеживания состояния этих объектов методы WaitAll и WaitAny, которые в качестве параметра принимают
            // массив объектов класса WaitHandle - базового класса для AutoResetEvent.
            // AutoResetEvent.WaitAll(new WaitHandle[] {waitHandler});

            // AutoResetEvent подаёт сигнал потоку, что ресурс освободился, когда выполнены все условия. Например, мы
            // создали несколько переменных класса AutoResetEvent, присвоили им значения. И написали где-то в коде
            // AutoResetEvent.WaitAll(new AutoResetEvent[] {1_переменная, 2_переменная}) Тогда поток получит доступ к
            // данной части , если обе переменные равны true.
#endif

#if MUTEX
            mutex.ReleaseMutex();

            // Основную работу по синхронизации выполняют методы WaitOne() и ReleaseMutex(). 
            // Метод mutexObj.WaitOne() приостанавливает выполнение потока до тех пор, пока не будет получен мьютекс mutexObj.
            // После выполнения всех действий, когда мьютекс больше не нужен, поток освобождает его с помощью
            // метода mutexObj.ReleaseMutex()
            // Таким образом, когда выполнение дойдет до вызова mutexObj.WaitOne(), поток будет ожидать,
            // пока не освободится мьютекс. И после его получения продолжит выполнять свою работу.
#endif

        }
    }

    class Reader
    {
        // Для создания семафора используется класс Semaphore: static Semaphore sem = new Semaphore(3, 3);.
        // Его конструктор принимает два параметра:
        // - первый указывает, какому числу объектов изначально будет доступен семафор, 
        // - а второй параметр указывает, какой максимальное число объектов будет использовать данный семафор. 
        // В данном случае у нас только три читателя могут одновременно находиться в библиотеке, поэтому максимальное число равно 3.

        // Основной функционал сосредоточен в методе Read, который и выполняется в потоке.
        // В начале для ожидания получения семафора используется метод sem.WaitOne().
        // После того, как в семафоре освободится место, данный поток заполняет свободное место и начинает выполнять
        // все дальнейшие действия. После окончания чтения мы высвобождаем семафор с помощью метода sem.Release().
        // После этого в семафоре освобождается одно место, которое заполняет другой поток.


        // В отличие от Lock (Monitor) и Mutex, у Semaphore нет «владельца» - он не зависит от потоков.
        // Любой поток может вызвать Release на семафоре, тогда как с помощью Mutex и lock его может освободить только поток,
        // получивший блокировку.


        public static Semaphore semaphore = new Semaphore(1, 3);
        Thread thread;

        private int count = 3;
        public Reader(int i)
        {
            thread = new Thread(Read);
            thread.Name = "Reader " + i;
            thread.Start();
        }
        public void Read()
        {
            while (count > 0)
            {
                semaphore.WaitOne();
                
                Console.WriteLine("{0} : Читатель вошел в библиотеку и начал чтение...", Thread.CurrentThread.Name);
                Thread.Sleep(1000);
                Console.WriteLine("{0} : Читатель закончил чтение и выходит из библиотеки...", Thread.CurrentThread.Name);

                semaphore.Release();

                count--;
                Thread.Sleep(1000);
            }            
        }
    }
}
