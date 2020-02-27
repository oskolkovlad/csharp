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


            // public static int Sum(int a, int b, Func<int, int, int> calc) => calc(a, b);
            // public static int Calc1(int a, int b) => a + b;
            // public static int Calc2(int a, int b) => a * b;

            var sum1 = Sum(5, 4, Calc1);
            Console.WriteLine(sum1);
            var sum2 = Sum(5, 4, Calc2);
            Console.WriteLine(sum2);

            Func<int, int, int> add = (x, y) => x + y;
            var result = add(5, 4);
            Console.WriteLine(result );


            //******************************************************************************************************//

            
            Console.WriteLine(new string('-', 60));


            //*** ПРАКТИЧЕСКОЕ ПРИМЕНЕНИЕ DELEGATE ***//

            Acount account = new Acount(200.0);
            account.RegistratorHandler(new Acount.MessageHandler(ShowMesage));
            account.Withdraw(150.0);
            account.Withdraw(100.0);
            account.Withdraw(50.0);
            account.Put(10000000.0);


            //******************************************************************************************************//


            Console.WriteLine(new string('-', 60));


            //*** Анонимные методы и лямбды ***//


            // Если анонимный метод использует параметры, то они должны соответствовать параметрам делегата.
            Action actAction = delegate
            {
                Console.WriteLine("Анонимный метод.");
            };
            actAction();
            // Анонимный метод не может существовать сам по себе, он используется для инициализации экземпляра делегата.

            // Если анонимный метод использует параметры, то они должны соответствовать параметрам делегата.
            Func<int, int, int> actFunc = delegate(int a, int b)
            {
                return a * b;
            };
            Console.WriteLine("actFunc: {0}", actFunc(32, 98));


            // Если для анонимного метода не требуется параметров, то скобки с параметрами опускаются.
            // При этом даже если делегат принимает несколько параметров, то в анонимном методе можно вовсе опустить параметры.
            // При этом параметры анонимного метода не могут быть опущены, если один или несколько параметров определены с модификатором out.
            Func<int, int, int> actFunc1 = delegate
            {
                Console.WriteLine("Может даже без параметров, хотя делегат имеет параметры");
                return 0;
            };
            actFunc1(2, 5); // но при этом параметры все равно нужно указать

            Func<int, int> actFunc2 = delegate (int i)
            {
                return ++i;
            };
            Console.WriteLine($"Anononim Method: {LambdaFunc(5, actFunc2)}");


            Console.WriteLine(new string('-', 60));


            //*** Лямбды ***//


            // Лямбда-выражения представляют упрощенную запись анонимных методов. Лямбда-выражения позволяют создать емкие
            // лаконичные методы, которые могут возвращать некоторое значение и которые можно передать в качестве
            // параметров в другие методы.

            // В лямбдах не нужно указывать тип параметров.
            // Однако, нам обязательно нужно указывать тип, если делегат, которому должно соответствовать лямбда-выражение,
            // имеет параметры с модификаторами ref и out
            Func<int, int, int> lambda = (x, y) => x * y;
            // Здесь код (x, y) => x * y; представляет лямбда-выражение, где x и y - это параметры, а x * y - выражение.
            Console.WriteLine("actFunc: {0}", lambda(5, 5));

            // При этом надо учитывать, что каждый параметр в лямбда-выражении неявно преобразуется в соответствующий
            // параметр делегата, поэтому типы параметров должны быть одинаковыми. Кроме того, количество параметров
            //должно быть таким же, как и у делегата. И возвращаемое значение лямбда-выражений должно быть тем же, что и у делегата.

            Action lambda1 = () => Console.WriteLine("Лямбда без параметров...");
            lambda1.Invoke();

            Func<int, int> lambda2 = x => ++x;
            Console.WriteLine($"Lambda Func: {LambdaFunc(2, lambda2)}");


            Console.WriteLine(new string('-', 60));


            //******************************************************************************************************//


            Console.ReadKey();
        }

        public static int LambdaFunc(int a, Func<int, int> lambda) => lambda(a);

        public static void ShowMesage(string message) => Console.WriteLine(message);

        private static void Person_DoWork(object sender, EventArgs e)
        {
            if (sender is Person)
                Console.WriteLine($"{((Person)sender).Name} пошел работать!");
            else
                Console.WriteLine("Sender don't Person!!!");
        }
         
        private static void Person_GoToSleep() => Console.WriteLine("Человек пошел спать...");
        private static void Person_GoToSleep1() => Console.WriteLine("Человек пошел спать...опапа...");
        


        // Передача в метод другого метода с помощью делегата "Func"
        public static int Sum(int a, int b, Func<int, int, int> calc) => calc(a, b);
        public static int Calc1(int a, int b) => a + b;
        public static int Calc2(int a, int b) => a * b;
    }
}
