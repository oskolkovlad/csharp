using System;
using System.Collections.Generic;
using System.Linq;

namespace SamplingFiltering_Projection
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ(Language - Integrated Query) представляет простой и удобный язык запросов к источнику данных.
            // В качестве источника данных может выступать объект, реализующий интерфейс IEnumerable(например,
            // стандартные коллекции, массивы), набор данных DataSet, документ XML. Но вне зависимости от типа источника
            // LINQ позволяет применить ко всем один и тот же подход для выборки данных.

            // Существует несколько разновидностей LINQ:

            // - LINQ to Objects: применяется для работы с массивами и коллекциями
            // - LINQ to Entities: используется при обращении к базам данных через технологию Entity Framework
            // - LINQ to Sql: технология доступа к данным в MS SQL Server
            // - LINQ to XML: применяется при работе с файлами XML
            // - LINQ to DataSet: применяется при работе с объектом DataSet
            // - Parallel LINQ(PLINQ): используется для выполнения параллельных запросов


            string[] names = { "Tom", "Alex", "John", "Michael", "George", "Bob" , "Timmy" };

            // Стандартная форма
            var name1 = from n in names
                        where n.ToLower().StartsWith("t")
                        orderby n descending // ascending
                        select n;

            foreach(var n in name1)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            // Методы расширений
            var name2 = names.Where(n => n.ToLower().StartsWith("t"))
                             .OrderByDescending(n => n);
            foreach (var n in name2)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            // Микс
            var count = (from n in names
                         where n.ToLower().StartsWith("t")
                         orderby n
                         select n).Count();
            Console.WriteLine(count);
            Console.WriteLine(new string('=', 50));


            //***********************************************************************************************//


            // Выборка сложных объектов
            List<Person> people = new List<Person>()
            {
                new Person("Tom", 23)     {Language = new List<string>(){ "english", "german" }},
                new Person("Alex", 75)    {Language = new List<string>(){ "english", "franch" }},
                new Person("John", 34)    {Language = new List<string>(){ "english", "spanish" }},
                new Person("Michael", 45) {Language = new List<string>(){ "spanish", "german" }},
                new Person("George", 27)  {Language = new List<string>(){ "franch",  "german" }},
                new Person("Bob", 13)     {Language = new List<string>(){ "franch",  "spanish" }},
            };

            var persons1 = from p in people
                           where p.Age > 27
                           orderby p.Name, p.Age // Множественный критерий сортировки
                           select p;

            foreach(var p in persons1)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // Сложные фильтры
            var persons2 = from p in people
                           from lang in p.Language
                           where p.Age > 27
                           where lang == "english"
                           orderby p.Name
                           select p;

            foreach (var p in persons2)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // Метод SelectMany() в качестве первого параметра принимает последовательность, которую надо проецировать,
            // а в качестве второго параметра -функцию преобразования, которая применяется к каждому элементу.
            var persons3 = people.SelectMany(l => l.Language, (u, l) => new { User = u, Lang = l })
                                .Where(u => u.User.Age > 27 && u.Lang == "english")
                                .OrderBy(u => u.User.Name)
                                .ThenBy(u => u.User.Age)
                                .Select(u => u.User);

            foreach (var p in persons3)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine(new string('=', 50));



            //***********************************************************************************************//


            // Проекция

            var user1 = new User("Tom",  23);
            var user2 = new User("Alex", 75);
            var users = new List<User>() { user1, user2 };

            var items = from u in users
                        let name = "Mr. " + u.Name
                        select new
                        {
                            FirstName = name,
                            Birthday = DateTime.Now.Year - u.Age
                        };

            foreach(var i in items)
            {
                Console.WriteLine(i.FirstName + " " + i.Birthday);
            }


            //***********************************************************************************************//





            //***********************************************************************************************//


            Console.ReadKey();
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Language = new List<string>();
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public List<string> Language { get; set; }


        public override string ToString() => $"{Name} - {Age}";
    }

    public class User
    {
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public override string ToString() => $"{Name} - {Age}";
    }
}
