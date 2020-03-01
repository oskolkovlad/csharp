using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Словарь хранит объекты, которые представляют пару ключ-значение. Каждый такой объект является
            // объектом структуры KeyValuePair<TKey, TValue>. Благодаря свойствам Key и Value, которые есть у данной
            // структуры, мы можем получить ключ и значение элемента в словаре.


            Dictionary<int, string> dict = new Dictionary<int, string>(5);
            dict.Add(1, "Russia");
            dict.Add(2, "The UK");
            dict.Add(3, "USA");
            dict.Add(4, "France");
            dict.Add(5, "China");

            //foreach(var key in dict.Keys)
            //{
            //    Console.WriteLine(dict[key]);
            //}

            foreach(var d in dict)
            {
                Console.WriteLine(d.Key + " " + d.Value);
            }

            Console.WriteLine();

            Console.WriteLine(dict[4]);
            dict[4] = "Spain";
            Console.WriteLine(dict[4]);

            Console.WriteLine();
            Console.WriteLine(dict.Remove(5));
            foreach (var d in dict)
            {
                Console.WriteLine(d.Key + " " + d.Value);
            }


            Console.WriteLine(new string('-', 50));


            Dictionary<char, Person> people = new Dictionary<char, Person>();

            people.Add('b', new Person() { Name = "Bill" });
            people['t'] = new Person() { Name = "Tom" };
            people['a'] = new Person() { Name = "Alex" };

            foreach (var p in people)
            {
                Console.WriteLine(p.Key + " " + p.Value.Name);
            }

            Console.WriteLine();

            // перебор ключей
            foreach (char c in people.Keys)
            {
                Console.WriteLine(c);
            }

            // перебор по значениям
            foreach (Person p in people.Values)
            {
                Console.WriteLine(p.Name);
            }


            Console.WriteLine(new string('-', 50));


            Dictionary<string, string> countries1 = new Dictionary<string, string>()
            {
                ["Россия"] = "Москва",
                ["Великобритания"] = "Лондон"

            };

            Dictionary<string, string> countries2 = new Dictionary<string, string>()
            {
                { "Россия", "Москва" },
                { "Великобритания", "Лондон" }

            };


            Console.ReadKey();
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}
