using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(45);
            linkedQueue.Enqueue(4);
            linkedQueue.Enqueue(5);
            linkedQueue.Enqueue(43);
            linkedQueue.Enqueue(78);
            linkedQueue.Enqueue(777);

            Console.WriteLine(linkedQueue);
            Console.WriteLine();

            foreach(var l in linkedQueue)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();

            Console.WriteLine(linkedQueue.PeekFirst);
            Console.WriteLine(linkedQueue.PeekLast);
            Console.WriteLine();

            Console.WriteLine(linkedQueue.Dequeue());
            Console.WriteLine(linkedQueue.Dequeue());
            Console.WriteLine(linkedQueue.Dequeue());
            Console.WriteLine();

            foreach (var l in linkedQueue)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();

            Console.WriteLine(linkedQueue);
            Console.WriteLine(linkedQueue.PeekFirst);
            Console.WriteLine(linkedQueue.PeekLast);
            Console.WriteLine();

            Console.WriteLine(linkedQueue.Contains(45));
            Console.WriteLine(linkedQueue.Contains(777));

            Console.WriteLine(new string('-', 50));


            //*************************************************************************//


            var listQueue = new ListQueue<int>();
            listQueue.Enqueue(45);
            listQueue.Enqueue(4);
            listQueue.Enqueue(5);
            listQueue.Enqueue(43);
            listQueue.Enqueue(78);
            listQueue.Enqueue(777);

            Console.WriteLine(listQueue);
            Console.WriteLine();

            Console.WriteLine(listQueue.PeekFirst());
            Console.WriteLine(listQueue.PeekLast());
            Console.WriteLine();

            Console.WriteLine(listQueue.Dequeue());
            Console.WriteLine(listQueue.Dequeue());
            Console.WriteLine(listQueue.Dequeue());
            Console.WriteLine();

            
            Console.WriteLine(listQueue);
            Console.WriteLine(listQueue.PeekFirst());
            Console.WriteLine(listQueue.PeekLast());
            Console.WriteLine();

            Console.WriteLine(linkedQueue.Contains(45));
            Console.WriteLine(linkedQueue.Contains(777));

            Console.WriteLine(new string('-', 50));


            //*************************************************************************//


            var arrayQueue = new ArrayQueue<int>();
            arrayQueue.Enqueue(45);
            arrayQueue.Enqueue(4);
            arrayQueue.Enqueue(5);
            arrayQueue.Enqueue(43);
            arrayQueue.Enqueue(78);
            arrayQueue.Enqueue(777);

            Console.WriteLine(arrayQueue);
            Console.WriteLine();

            Console.WriteLine(arrayQueue.PeekFirst());
            Console.WriteLine(arrayQueue.PeekLast());
            Console.WriteLine();

            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine();


            Console.WriteLine(arrayQueue);
            Console.WriteLine(arrayQueue.PeekFirst());
            Console.WriteLine(arrayQueue.PeekLast());
            Console.WriteLine();

            Console.WriteLine(linkedQueue.Contains(45));
            Console.WriteLine(linkedQueue.Contains(777));


            //*************************************************************************//


            Console.ReadKey();

        }
    }
}
