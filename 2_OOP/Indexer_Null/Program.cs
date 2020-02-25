using System;


namespace Indexer_Null
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People(3);

            people[0] = new Person("Миша");
            people[1] = new Person("Борис");
            people[2] = new Person("Денис");

            // Выражение ?. и представляет оператор условного null.
            Console.WriteLine($"[0]: {people[0]?.Name}");
            Console.WriteLine($"[1]: {people[1]?.Name}");
            Console.WriteLine($"[2]: {people[2]?.Name}\n");

            Console.WriteLine("Name: {0}\n", people["Миша"]?.Name);


            //***********************************************************//


            User user = new User();
            user["name"] = "Вася";
            user["phone"] = "+79863256454";
            user["email"] = "opd@gmail.com";

            Console.WriteLine(user);

            // Оператор ?? называется оператором null-объединения. Он применяется для установки значений
            // по умолчанию для типов, которые допускают значение null. Оператор ?? возвращает левый операнд,
            // если этот операнд не равен null. Иначе возвращается правый операнд.
            Console.WriteLine(user["geo"] ?? "Такого поля нет!!!");


            //***********************************************************//


            Console.ReadKey();
        }
    }
}
