using System;
using System.Collections.Generic;
using System.Linq;

namespace Join_GroupJoin_Zip_AllAny_Delegate
{
    class Program
    {
        // Фактически LINQ-запрос разбивается на три этапа:

        // 1. Получение источника данных
        // 2. Создание запроса
        // 3. Выполнение запроса и получение его результатов

        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };

            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };


           // Важно понимать, что переменная запроса сама по себе не выполняет никаких действий и не возвращает никаких данных.О
           // на только хранит набор команд, которые необходимы для получения результатов.То есть выполнение запроса после его
           // создания откладывается. Само получение результатов производится при переборе в цикле foreach.

           // Отложенный запрос
           var join1 = from p in players
                        join t in teams on p.Team equals t.Name
                        select new { Name = p.Name, Team = p.Team, Country = t.Country };

            // Метод Join() принимает четыре параметра:
            // - второй список, который соединяем с текущим
            // - свойство объекта из текущего списка, по которому идет соединение
            // - свойство объекта из второго списка, по которому идет соединение
            // - новый объект, который получается в результате соединения
            var join2 = players.Join(teams, p => p.Team, t => t.Name, (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country });

            foreach (var r in join1)
            {
                Console.WriteLine($"{r.Name} - {r.Team} ({r.Country})");
            }
            Console.WriteLine();

            // С помощью ряда методов мы можем применить немедленное выполнение запроса. Это методы, которые возвращают одно
            // атомарное значение или один элемент. Например, Count(), Average(), First() / FirstOrDefault(), Min(), Max() и т.д.
            // Например, метод Count() возвращает числовое значение, которое представляет количество элементов в полученной последовательности. 
            // Также для немедленного выполнения LINQ-запроса и кэширования его результатов мы можем применять методы
            // преобразования ToArray<T>(), ToList<T>(), ToDictionary() и т.д..

            // Немедленный запрос
            var count = (from p in players
                         join t in teams on p.Team equals t.Name
                         select new { Name = p.Name, Team = p.Team, Country = t.Country }).Count();
            Console.WriteLine(count);
            Console.WriteLine();


            //*******************************************************************************************************//


            var groupjoin = teams.GroupJoin(players, t => t.Name, p => p.Team, (tm, pl) => new { Name = tm.Name, Country = tm.Country, Players = pl.Select(p => p.Name) });
            
            foreach (var g in groupjoin)
            {
                Console.WriteLine($"{g.Name}");

                foreach (var p in g.Players)
                {
                    Console.WriteLine($"{p}");
                }
                Console.WriteLine();

            }
            Console.WriteLine();


            //*******************************************************************************************************//


            var zip = players.Zip(teams, (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country });
            foreach (var z in zip)
            {
                Console.WriteLine($"{z.Name} - {z.Team} ({z.Country})");
            }
            Console.WriteLine();


            //*******************************************************************************************************//

            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };
            bool result1 = users.All(u => u.Age > 20); // true
            if (result1)
                Console.WriteLine("У всех пользователей возраст больше 20");
            else
                Console.WriteLine("Есть пользователи с возрастом меньше 20");

            bool result2 = users.All(u => u.Name.StartsWith("T")); //false
            if (result2)
                Console.WriteLine("У всех пользователей имя начинается с T");
            else
                Console.WriteLine("Не у всех пользователей имя начинается с T");


            bool result3 = users.Any(u => u.Age < 20); //false
            if (result3)
                Console.WriteLine("Есть пользователи с возрастом меньше 20");
            else
                Console.WriteLine("У всех пользователей возраст больше 20");

            bool result4 = users.Any(u => u.Name.StartsWith("T")); //true
            if (result4)
                Console.WriteLine("Есть пользователи, у которых имя начинается с T");
            else
                Console.WriteLine("Отсутствуют пользователи, у которых имя начинается с T");

            Console.WriteLine();


            //*******************************************************************************************************//


            // Хотя, как правило, в качестве параметров в методах расширения LINQ удобно использовать лямбда-выражения.
            // Но лямбда-выражения являются сокращенной нотацией анонимных методов. И если мы обратимся к определению этих методов,
            // то увидим, что в качестве параметра многие из них принимают делегаты типа Func<TSource, bool>, например, определение метода Where.

            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            var _delegate = numbers.Where(delegate (int num)
            {
                return num > 2;
            });
            foreach(var n in _delegate)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();


            var method = numbers.Where(Delegate);
            foreach (var n in method)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();



            int[] numberss = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };

            var result = numberss.Where(Delegate).Select(Factorial);
            foreach (var r in result)
            {
                Console.Write(r + " ");
            }


            //*******************************************************************************************************//


            Console.ReadKey();
        }

        public static bool Delegate(int num) => num > 2;

        public static int Factorial(int num)
        {
            var res = 1;
            for (int i = 1; i <= num; i++)
            {
                res *= i;
            }

            return res;
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
