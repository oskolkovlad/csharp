using System;
using System.Threading;

namespace Timers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Первым делом создается объект делегата TimerCallback, который в качестве параметра принимает метод.
            // Причем данный метод должен в качестве параметра принимать объект типа object.

            // И затем создается таймер. Данная перегрузка конструктора таймера принимает четыре параметра:
            // - объект делегата TimerCallback
            // - объект, передаваемый в качестве параметра в метод Count
            // - количество миллисекунд, через которое таймер будет запускаться. В данном случае таймер
            // будет запускать немедленно после создания, так как в качестве значения используется 0
            // - интервал между вызовами метода Count (для использования таймера один раз - Timeout.Infiniteф)


            TimerCallback timerCallback = new TimerCallback(Count);
            Timer timer = new Timer(timerCallback, (new Random()).Next(5, 10) /*null*/, 0, 2000);


            Console.ReadKey();
        }

        static void Count(object o)
        {
            int counts = (int)o;
            int res = 0;

            for (var i = 0; i < counts; i++)
            {
                res += i;
            }

            Console.WriteLine("Result of sum is: {0}", res);
        }
    }
}
