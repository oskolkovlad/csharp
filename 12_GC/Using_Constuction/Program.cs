using System;

namespace Using_Constuction
{
    // Конструкция using оформляет блок кода и создает объект некоторого класса, который реализует интерфейс
    // IDisposable, в частности, его метод Dispose. При завершении блока кода у объекта вызывается метод Dispose.

    // Важно, что данная конструкция применяется только для классов, которые реализуют интерфейс IDisposable.

    class Program
    {
        static void Main(string[] args)
        {
            Test1();

            Console.WriteLine();

            Test2();



            Console.ReadLine();
        }

        private static void Test1()
        {
            using (Person p = new Person { Name = "Tom" })
            {
                // переменная p доступна только в блоке using
                Console.WriteLine($"Некоторые действия с объектом Person. Получим его имя: {p.Name}");
            }
            Console.WriteLine("Конец метода Test");
        }

        // Начиная с версии C# 8.0 мы можем задать в качестве области действия всю окружающую область видимости, например, метод.
        private static void Test2()
        {
            using Person p = new Person { Name = "Tom" };
            // переменная p доступна до конца метода Test
            Console.WriteLine($"Некоторые действия с объектом Person. Получим его имя: {p.Name}");

            Console.WriteLine("Конец метода Test");
        }
    }

    public class Person : IDisposable
    {
        public string Name { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
}
