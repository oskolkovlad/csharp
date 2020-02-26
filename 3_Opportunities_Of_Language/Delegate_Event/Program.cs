using System;
using static Delegate_Event.DelegateMethods;

namespace Delegate_Event
{
    // Делегат - коробка, содержащая ссылки на методы.

    // delegate type_return name_of_delegate(type_of_arg)
    public delegate void MyDelagate();

    class Program
    {
        public delegate int ValueDelegate(int i);

        // События
        public event MyDelagate MyEvent;
        // событие выше и ниже равнозначны
        public event Action ActionEvent;




        static void Main(string[] args)
        {

            #region Delegates

            MyDelagate myDelagate = Method1;
            myDelagate += Method4; // Добавляем в делегат еще метод со схожей сигнатурой (void _ () )
            myDelagate(); // Вызываем делегат, а делегат вызывает метод Method1 и Method4

            Console.WriteLine(new string('-', 60));

            MyDelagate myDelagate1 = new MyDelagate(Method4);
            myDelagate1 += Method4;
            myDelagate1.Invoke();
            myDelagate1 -= Method4;

            Console.WriteLine(new string('-', 60));

            MyDelagate myDelagate2 = myDelagate + myDelagate1;
            myDelagate2.Invoke();

            Console.WriteLine(new string('-', 60));

            ValueDelegate valueDelegate = new ValueDelegate(MethodValue);
            valueDelegate((new Random()).Next(0,20));
            valueDelegate += MethodValue;
            valueDelegate += MethodValue;
            valueDelegate.Invoke((new Random()).Next(0, 20));

            Console.WriteLine(new string('-', 60));


            //*** Шаблонные делегаты ***//

            //** Action **// - группа делегатов, не возвращающие значения, но способные принимать от 0 до 16 возможных значений

            // По сигнатуре совпадает со следующим делегатом: public delegate void Action();
            Action actionDelegate = new Action(Method1);
            // По сигнатуре совпадает со следующим делегатом: public delegate void Action(int i);
            Action<int> actionDelegate1 = new Action<int>(Method3);
            actionDelegate();
            actionDelegate1(20);


            Console.WriteLine(new string('-', 60));


            //** Predicate **//
            // принимает один параметр

            // public delegate bool Predicate<T>(T value);
            Predicate<int> predicate = MethodPredicate;
            predicate(100);


            Console.WriteLine(new string('-', 60));


            //** Function **//
            // принимает тип возвращаемого значения (последний передаваемый тип) и 0-16 аргументов

            // public delegate int Func()
            Func<int> func = Method2;
            // public delegate int Func(string value)
            Func<string, int> func1 = MethodFunc;
            func();


            //** Проверка на NULL **//
            if (func1 != null)
            {
                func1("Bob");
            }

            // или

            func1?.Invoke("Bob");


            Console.WriteLine(new string('-', 60));

            #endregion


            //******************************************************************************************************//


            Person person = new Person()
            {
                Name = "Петр"
            };

            // Подписываемся на событие
            person.GoToSleep += Person_GoToSleep;
            person.GoToSleep += Person_GoToSleep1;

            person.DoWork += Person_DoWork;

            person.TakeTime(DateTime.Parse("26.02.2020 15:19:22"));
            person.TakeTime(DateTime.Parse("27.02.2020 3:19:22"));


            //******************************************************************************************************//


            Console.WriteLine(new string('-', 60));


            var sum1 = Sum(5, 4, Calc1);
            Console.WriteLine(sum1);
            var sum2 = Sum(5, 4, Calc2);
            Console.WriteLine(sum2);

            Func<int, int, int> add = (x, y) => x + y;
            var result = add(5, 4);
            Console.WriteLine(result );


            //******************************************************************************************************//


            Console.ReadKey();
        }

        private static void Person_DoWork(object sender, EventArgs e)
        {
            if (sender is Person)
                Console.WriteLine($"{((Person)sender).Name} пошел работать!");
            else
                Console.WriteLine("Sender don't Person!!!");
        }
         
        private static void Person_GoToSleep()
        {
            Console.WriteLine("Человек пошел спать...");
        }

        private static void Person_GoToSleep1()
        {
            Console.WriteLine("Человек пошел спать...опапа...");
        }


        // Передача в метод другого метода с помощью делегата "Func"
        public static int Sum(int a, int b, Func<int, int, int> calc)
        {

            return calc(a, b);
        }

        public static int Calc1(int a, int b)
        {
            return a + b;
        }

        public static int Calc2(int a, int b)
        {
            return a * b;
        }
    }
}
