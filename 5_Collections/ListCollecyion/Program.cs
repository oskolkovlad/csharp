using System;
using System.Collections.Generic;

namespace ListCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Класс List<T> из пространства имен System.Collections.Generic представляет простейший список однотипных объектов.

            List<int> numbers = new List<int>() { 1, 2, 3, 54, 22 };
            numbers.Add(567);
            numbers.AddRange(new int[] { 13, 54, 543 });

            foreach(var n in numbers)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();

            numbers.RemoveAt(4);
            numbers.Insert(1, 6000);

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();

            numbers.Sort();
            Console.WriteLine(numbers.BinarySearch(543));

            Console.WriteLine();

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();


            //Указание начальной емкости списка(capacity) позволяет в будущем увеличить производительность
            // и уменьшить издержки на выделение памяти при добавлении элементов. Также начальную емкость можно
            // установить с помощью свойства Capacity, которое имеется у класса List.
            List<Person> persons = new List<Person>(2) { new Person() { Name = "Tom" } };
            persons.Add(new Person() { Name = "Bob" });
            persons.Add(new Person() { Name = "Bob" });

            persons.Capacity = 3;

            foreach(var p in persons)
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
