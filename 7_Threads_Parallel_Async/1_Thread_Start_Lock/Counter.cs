using System;
using System.Threading;

namespace Thread_Start_Lock
{
    class Counter
    {
        public Counter(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void GetCount()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread4_Counter_Method: GetCount() - {i * X} | {i * Y}");
                Thread.Sleep(700);
            }
        }
    }
}
