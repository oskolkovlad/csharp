using System;
using System.Collections.Generic;

namespace StackCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Класс Stack<T> представляет коллекцию, которая использует алгоритм LIFO ("последний вошел - первый вышел").
            // При такой организации каждый следующий добавленный элемент помещается поверх предыдущего.
            // Извлечение из коллекции происходит в обратном порядке - извлекается тот элемент, который находится выше всех в стеке.

            // В классе Stack можно выделить два основных метода, которые позволяют управлять элементами:

            // - Push: добавляет элемент в стек на первое место
            // - Pop: извлекает и возвращает первый элемент из стека
            // - Peek: просто возвращает первый элемент из стека без его удаления


            Stack<int> num = new Stack<int>();
            num.Push(4); // 4
            num.Push(6); // 4 6
            num.Push(1); // 4 6 1

            foreach(var n in num)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            int stackPop = num.Pop(); // 1
            Console.WriteLine(stackPop);
            Console.WriteLine();

            foreach (var n in num)
            {
                Console.WriteLine(n);
            }


            Console.WriteLine(new string('-', 50));



            Stack<Person> persons = new Stack<Person>();

            persons.Push(new Person() { Name = "Tom" }); // "Tom"
            persons.Push(new Person() { Name = "Bob" }); // "Tom" "Bob"
            persons.Push(new Person() { Name = "Alex" }); // "Tom" "Bob" "Alex"

            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine();

            Person pp = persons.Peek();  // "Alex"
            Console.WriteLine(pp.Name);
            Console.WriteLine();

            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine();

            Console.WriteLine(persons.Pop().Name); // "Tom ""Bob"
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
