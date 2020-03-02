using System;

namespace TypeObject
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = new object();

            // Boxing -перенос значимых типов в кучу (ресурсоемкая операция)
            int i = 777;
            obj = i;

            // Unboxing - обратный процесс (ресурсоемкая операция)
            int j = (int)obj;


            //***************************************************************************//


            int a = 5;
            int b = 5;
            // Значимые типы сравниваются по значению
            Console.WriteLine(a.Equals(b)); // True
            Console.WriteLine();
            object obj1 = a;
            object obj2 = b;
            // Понимает что это упакованные значимые типы, поэтому результат: True
            Console.WriteLine(obj1.Equals(obj2)); // True
            Console.WriteLine();

            Point p1 = new Point() { X = 10 };
            Point p2 = new Point() { X = 10 };
            // Ссылочные типы сравниваются по участку памяти (адреса)
            Console.WriteLine(p1.Equals(p2)); // False
            Console.WriteLine( new string('-', 50));


            //***************************************************************************//
        

            // GetHashCode
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
            Console.WriteLine();
            Console.WriteLine(obj1.GetHashCode());
            Console.WriteLine(obj2.GetHashCode());
            Console.WriteLine();
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());
            Console.WriteLine(new string('-', 50));

            // GetType
            Console.WriteLine(b.GetType());
            Console.WriteLine(obj1.GetType());
            Console.WriteLine(p1.GetType());
            Console.WriteLine();
            // typeof - возвращает полный тип
            Console.WriteLine(typeof(int));
            Console.WriteLine(typeof(Point));
            Console.WriteLine(typeof(object));
            Console.WriteLine();
            // nameof
            Console.WriteLine(nameof(a));
            Console.WriteLine(nameof(obj1));
            Console.WriteLine(nameof(p1));
            Console.WriteLine(new string('-', 50));


            //***************************************************************************//

            // Equals и ReferenceEquals
            Console.WriteLine(Object.Equals(5, 5));
            Console.WriteLine(Object.ReferenceEquals(5, 5));
            Console.WriteLine();
            Console.WriteLine(Object.Equals(p1, p1));
            Console.WriteLine(Object.ReferenceEquals(p1, p1));
            Console.WriteLine();
            Console.WriteLine(Object.Equals(p1, p2));
            Console.WriteLine(Object.ReferenceEquals(p1, p2));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // MemberwiseClone
            Point p3 = new Point() { X = 1, my = new MyClass(10) };
            Point p4 = new Point() { X = 13, my = new MyClass(130) };

            p3 = p4.Clone();

            Console.WriteLine(p3.X);
            Console.WriteLine(p3.my.Y);
            p3.my.Y = 0;
            Console.WriteLine(p3.my.Y);
            Console.WriteLine(p4.my.Y);
            Console.WriteLine();
            Console.WriteLine();


            // Глубокое копирование
            Point p5 = new Point() { X = 1, my = new MyClass(10) };
            Point p6 = new Point() { X = 13, my = new MyClass(130) };

            p5 = p6.DeepClone();
            Console.WriteLine(p5.X);
            Console.WriteLine(p5.my.Y);
            p5.my.Y = 0;
            Console.WriteLine(p5.my.Y);
            Console.WriteLine(p6.my.Y);


            //***************************************************************************//


            Console.ReadKey();
        }
    }
}
