using System;

namespace Deque
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedDeque<int> deque = new LinkedDeque<int>();

            deque.AddFirst(3);
            deque.AddFirst(77);
            deque.AddLast(34);
            deque.AddLast(65);
            deque.AddFirst(8);
            deque.AddLast(25);

            Console.WriteLine(deque);
            Console.WriteLine();

            foreach(var d in deque)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine();

            Console.WriteLine(deque.Contains(999));
            Console.WriteLine(deque.Contains(77));
            Console.WriteLine();

            Console.WriteLine(deque.First());
            Console.WriteLine(deque.Last());
            Console.WriteLine();

            Console.WriteLine(deque.RemoveFirst());
            Console.WriteLine(deque.RemoveFirst());
            Console.WriteLine(deque.RemoveLast());
            Console.WriteLine(deque.RemoveFirst());
            Console.WriteLine(deque.RemoveLast());
            Console.WriteLine();

            Console.WriteLine(deque);
            Console.WriteLine();

            foreach (var d in deque)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine();
            Console.WriteLine(deque.First());
            Console.WriteLine(deque.Last());
            Console.WriteLine();

            Console.WriteLine(deque.RemoveLast());
            Console.WriteLine();

            Console.WriteLine(deque);
            //Console.WriteLine(deque.First());
            //Console.WriteLine(deque.Last());


            Console.ReadKey();
        }
    }
}
