using System;

namespace Delegate_Event
{
    class DelegateMethods
    {
        public static void Method1()
        {
            Console.WriteLine("Method1");
        }

        public static int Method2()
        {
            Console.WriteLine("Method2");
            return 0;
        }

        public static void Method3(int i)
        {
            Console.WriteLine("Method3");
        }

        public static void Method4()
        {
            Console.WriteLine("Method4");
        }

        public static int MethodValue(int i)
        {
            Console.WriteLine("MethodValue:\t{0}", i);
            return i;
        }

        public static bool MethodPredicate(int i)
        {
            Console.WriteLine("MethodPredicate:\t{0}", i);
            return true;
        }

        public static int MethodFunc(string i)
        {
            Console.WriteLine("MethodFunc:\t{0}", i);
            return 0;
        }
    }
}
