using System;


namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            SayHello();
            SayHello("Vlad");

            int a = 10;

            Console.WriteLine("\nSum (return):\t\t{0}", Sum(10, 35));
            Console.WriteLine("Sum (default):\t\t{0}", SumAndMult(10, 35));
            Console.WriteLine("Sum (default):\t\t{0}", SumAndMult(10, 35, 5));
            Console.WriteLine("Sum (default):\t\t{0}", SumAndMult(10, 35, 5, 3));
            Console.WriteLine("Sum (name_param):\t{0}", SumAndMult(d: 3, c: 5, a: 10, b: 35));

            Console.WriteLine("\nSum (ref return):\ta before = {0}, Sum = {1}, a after = {2}", a, Sum(ref a, 35), a);
            SumMult(a, 35, out int resSum, out int resMult);
            Console.WriteLine("SumMult (out):\t\tSum = {0}, Mult = {1}", resSum, resMult);
            SumMult(in a, 35, out resSum, out resMult);
            Console.WriteLine("SumMult (in out):\t\tSum = {0}, Mult = {1}\n", resSum, resMult);

            int[] digits = new int[] { 1, 2, 3, 4, 5 };

            Addition(digits);
            Addition(1, 2, 3, 4, 5);
            AdditionMas(digits);
            AdditionA(4, 28, out int c, 1, 2, 3, 4, 5);
            Console.WriteLine($"c = {c}");
            AdditionA(4, 28, out c, digits);
            Console.WriteLine($"c = {c}");

            Console.WriteLine("\nFactorial:\t{0}", Factorial(6));
            Console.WriteLine("Fibonachi:\t{0}", Fibonachi(6));


            Console.ReadKey();
        }

        static void SayHello()
        {
            Console.WriteLine("Hello, my proger!");
        }

        static void SayHello(string name)
        {
            Console.WriteLine("Hello, my proger {0}!", name);
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Sum(ref int a, int b)
        {
            a++;
            return a + b;
        }

        static void SumMult(int a, int b, out int c, out int d)
        {
            c = a + b;
            d = a * b;
        }

        static void SumMult(in int a, int b, out int c, out int d)
        {
            // a++; - ошибка, так как в параметрах указано ключевое слово "in"
            b++;
            c = a + b;
            d = a * b;
        }

        static int SumAndMult(int a, int b, int c = 9, int d = 18)
        {
            return (a + b) * (c + d);
        }

        static void Addition(params int[] digits)
        {
            int result = 0;
            foreach(int i in digits)
            {
                result += i;
            }
            Console.WriteLine("Addition (params): {0}", result);
        }

        static void AdditionA(int a, int b, out int c, params int[] digits)
        {
            int result = 0;

            foreach (int i in digits)
            {
                result += i;
            }
            
            c = a * b + b;

            Console.WriteLine("Result of addition = {0}, c = {1}", result, c);
        }

        static void AdditionMas(int[] digits)
        {
            int result = 0;
            foreach (int i in digits)
            {
                result += i;
            }
            Console.WriteLine("Addition (mas): {0}", result);
        }

        static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        }
        // Factorial(6) = 6  * Factorial(5) = 6 * 5 Factorial(4) = 6 * 5 * 4 * Factorial(3) = 6 * 5 * 4 * 3 * Factorial(2) =
        // 6 * 5 * 4 * 3 * 2 * Factorial(1) = 6 * 5 * 4 * 3 * 2 * 1 = 720

        static int Fibonachi(int n)
        {
            if (n == 0 | n == 1)
                return n;
            else
                return Fibonachi(n - 2) + Fibonachi(n - 1);
        }
        // Fibonachi(5) = Fibonachi(n - 2 = 3) + Fibonachi(n - 1 = 4) = 
        // Fibonachi(n - 2 = 1) + Fibonachi(n - 1 = 2) + Fibonachi(n - 2 = 2) + Fibonachi(n - 1 = 3) =
        // 1 + Fibonachi(n - 2 = 0) + Fibonachi(n - 1 = 1) + Fibonachi(n - 2 = 0) + Fibonachi(n - 1 = 1) + Fibonachi(n - 2 = 1) + Fibonachi(n - 1 = 2) =
        // 4 + Fibonachi(n - 2 = 0) + Fibonachi(n - 1 = 1) = 4 + 0 + 1 = 5
    }
}
