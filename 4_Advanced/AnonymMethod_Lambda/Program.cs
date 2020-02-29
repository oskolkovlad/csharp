using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymMethod_Lambda
{
    class Program
    {
        public delegate int MyHandler(int i);

        static void Main(string[] args)
        {
            // Анонимные методы
            Action<int, int> act1 = delegate (int a, int b)
            {
                Console.WriteLine(a + b);
            };

            Action<int, int> act2 = delegate
            {
                Console.WriteLine("Анонимный метод, который не содержит параметров, хотя делегат их имеет...");
            };

            Func<int, int, int> func1 = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine($"func1: {func1(4, 6)}");

            MyHandler myHandler = delegate (int i)
            {
                return ++i;
            };
            myHandler += Method;
            Console.WriteLine($"myHandler: {myHandler(99)}");


            Console.WriteLine(new string('-', 60));


            //********************************************************************************************//


            // Лямбды
            Func<int, int, int> func2 = (a, b) => a + b;
            Console.WriteLine($"func2: {func2(4, 6)}");

            MyHandler myHandler1 = i => //++i;
            {
                var res = ++i;
                Console.WriteLine($"myHandler1: {res}");
                return res;
            };
            myHandler1 += Method;
            myHandler1(99);


            Console.WriteLine(new string('-', 60));


            //********************************************************************************************//


            Lesson lesson = new Lesson("Программирование");
            lesson.StartLesson += (sender, date) =>
            {
                Console.WriteLine(sender);
                Console.WriteLine(date);
            };
            lesson.Start();


            Console.WriteLine(new string('-', 60));


            //********************************************************************************************//


            var list = new List<int>()
            {
                1, 2, 3, 4, 5
            };

            Console.WriteLine(list.Aggregate((x, y) => x + y));

            var res1 = Agr(list, Method);
            var res2 = Agr(list, (x) => x * x);
            var res3 = Agr(list, delegate(int x) { return x * x * x; });

            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine(res3);


            //********************************************************************************************//


            Console.ReadKey();
        }

        static int Agr(List<int> list, MyHandler handler)
        {
            var result = 0;
            
            foreach(var item in list)
            {
                result += handler(item);
            }

            return result;
        }

        static int Method(int i)
        {
            Console.WriteLine("Method: {0}", ++i);
            return i++;
        }
    }
}
