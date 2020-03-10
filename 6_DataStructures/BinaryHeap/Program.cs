using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            var rnd = new Random();
            var items = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                items.Add(rnd.Next(-100, 1000));
            }

            timer.Start();
            Heap<int> heap = new Heap<int>(items);
            timer.Stop();
            Console.WriteLine("timer = " + timer.Elapsed);

            timer.Restart();
            for (var i = 0; i < 100; i++)
            {
                heap.Add(rnd.Next(-100, 1000));
            }
            timer.Stop();
            Console.WriteLine("timer = " + timer.Elapsed);

            Console.WriteLine();
            timer.Restart();
            foreach (var h in heap)
            {
                Console.WriteLine(h);
            }
            timer.Stop();
            Console.WriteLine();
            Console.WriteLine("timer = " + timer.Elapsed);

            //Console.WriteLine(heap.PeekMaxNode());
            //Console.WriteLine(heap.PopMaxNode());


            Console.ReadKey();
        }
    }
}
