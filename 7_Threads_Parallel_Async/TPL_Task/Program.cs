using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // Класс Task имеет ряд свойств, с помощью которых мы можем получить информацию об объекте.Некоторые из них:

            // - AsyncState: возвращает объект состояния задачи
            // - CurrentId: возвращает идентификатор текущей задачи
            // - Exception: возвращает объект исключения, возникшего при выполнении задачи
            // - Status: возвращает статус задачи

            // Первый способ определения
            Task task1 = new Task(() => Console.WriteLine("Выполняется первая задача"));
            
            // Второй способ определения
            Task task2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Выполняется вторая задача");
            });
            
            // Третий способ определения
            Task task3 = Task.Run(() =>
            {
                Console.WriteLine("Выполняется третья задача");
            });

            task1.Start();
            task3.Wait(); // ожидание выполнения задачи


            Console.WriteLine("\nFinished taskes 1-3...\n");


            // Вложенные задачи
            Task outter = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Start Outter Task...");

                Task inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Start Inner Task...");
                    Thread.Sleep(3000);
                    Console.WriteLine("Finish Inner Task...");
                }, TaskCreationOptions.AttachedToParent);
            });
            outter.Wait();


            Console.WriteLine("\nFinished tasks otter and inner...\n");


            // Массив задач

            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("Первый элемент массива...")),
                new Task(() => Console.WriteLine("Второй элемент массива...")),
                new Task(() => Console.WriteLine("Третий элемент массива..."))
            };

            foreach(var t in tasks1)
            {
                t.Start();
            }
            Task.WaitAll(tasks1);


            Task[] tasks2 = new Task[3];

            var j = 1;
            for (var i = 0; i < tasks2.Length; i++)
            {
                tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"{j++} - элемент task2..."));
            }
            Task.WaitAll(tasks2);


            Console.WriteLine("\nFinished array tasks...\n");


            // Возвращение результатов из задач
            Task<int> taskFactorial = Task.Factory.StartNew(() => FactorialCycle(5));
            Console.WriteLine(FactorialRecursion(5));
            taskFactorial.Wait();
            Console.WriteLine(taskFactorial.Result);

            Task<Person> taskPerson = new Task<Person>(() => new Person("Tom", 23));
            taskPerson.Start();
            Person b = taskPerson.Result;

            Console.WriteLine(b.Name + " " + b.Age);

            Console.WriteLine();

            // Задачи продолжения
            Task<int> taskOne = new Task<int>(() => FactorialCycle(5));

            Task taskTwo = taskOne.ContinueWith((Task t) =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            Task taskTree = taskOne.ContinueWith((x) => Console.WriteLine($"Result of TaskOne = {x.Result}"));

            taskOne.Start();
            taskTree.Wait();


            Console.WriteLine("\nMain program...");


            Console.ReadKey();
        }


        public static int FactorialRecursion(int x)
        {
            if (x == 0)
                return 1;

            return x * FactorialRecursion(x - 1);
        }

        public static int FactorialCycle(int x)
        {
            var fact = 1;
            for (var i = 1; i <= x; i++)
            {
                fact *= i;
            }

            Console.WriteLine($"Факториал {x} равен = {fact}");

            return fact;
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}
