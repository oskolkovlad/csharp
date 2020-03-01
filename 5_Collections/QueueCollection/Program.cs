using System;
using System.Collections.Generic;

namespace QueueCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Класс Queue<T> представляет обычную очередь, работающую по алгоритму FIFO ("первый вошел - первый вышел").

            // У класса Queue<T> можно отметить следующие методы:
            // - Dequeue: извлекает и возвращает первый элемент очереди
            // - Enqueue: добавляет элемент в конец очереди
            // - Peek: просто возвращает первый элемент из начала очереди без его удаления

            Queue<string> queue = new Queue<string>();

            queue.Enqueue("apple"); // "apple"
            queue.Enqueue("banan"); // "apple" "banan"
            queue.Enqueue("ananas"); // "apple" "banan" "ananas"

            foreach (var q in queue)
            {
                Console.WriteLine(q);
            }
            Console.WriteLine();

            Console.WriteLine(queue.Peek()); // "apple" "banan" "ananas"
            Console.WriteLine();
            foreach (var q in queue)
            {
                Console.WriteLine(q);
            }
            Console.WriteLine();

            Console.WriteLine(queue.Dequeue()); // "banan" "ananas"
            Console.WriteLine();

            foreach (var q in queue)
            {
                Console.WriteLine(q);
            }
            Console.WriteLine(new string('-', 50));



            Queue<Person> persons = new Queue<Person>();

            persons.Enqueue(new Person() { Name = "Tom" }); // "Tom"
            persons.Enqueue(new Person() { Name = "Bob" }); // "Tom" "Bob"
            persons.Enqueue(new Person() { Name = "Alex" }); // "Tom" "Bob" "Alex"

            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine();

            Person pp = persons.Peek();  // "Tom"
            Console.WriteLine(pp.Name);
            Console.WriteLine();

            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine();

            Console.WriteLine(persons.Dequeue().Name); // "Bob" "Alex"
            Console.WriteLine();

            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }


            Console.ReadKey();
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}
