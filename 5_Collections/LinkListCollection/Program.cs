using System;
using System.Collections.Generic;

namespace LinkedListCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Класс LinkedList<T> представляет двухсвязный список, в котором каждый элемент хранит ссылку
            // одновременно на следующий и на предыдущий элемент.

            // Если в простом списке List<T> каждый элемент представляет объект типа T, то в LinkedList<T>
            // каждый узел представляет объект класса LinkedListNode<T>.


            LinkedList<int> linkList = new LinkedList<int>();

            linkList.AddLast(1);
            linkList.AddFirst(2);
            linkList.AddAfter(linkList.Last, 3);

            foreach(var ll in linkList)
            {
                Console.WriteLine(ll);
            }

            Console.WriteLine();



            LinkedList<Person> persons = new LinkedList<Person>();

            LinkedListNode<Person> per = persons.AddLast(new Person() { Name = "Tom" });
            persons.AddLast(new Person() { Name = "Bob" });
            persons.AddBefore(persons.Last, new Person() { Name = "Alex" });

            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine();

            Console.WriteLine(per.Value.Name);
            Console.WriteLine(per.Next.Value.Name);
            Console.WriteLine(per.Next.Next.Value.Name);
            Console.WriteLine(per.List.AddLast(new Person() { Name = "GoGa" }));

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
