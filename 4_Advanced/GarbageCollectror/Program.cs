using System;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //GC.Collect(2);

            Console.WriteLine(GC.GetTotalMemory(false));

            for(var i = 0; i < 10000; i++)
            {
                var obj = (object)i;
                int j = (int)obj;
            }

            Console.WriteLine(GC.GetTotalMemory(false));
            GC.Collect();
            Console.WriteLine(GC.GetTotalMemory(false));

            using(var c = new MyClass())
            {
                //c.Dispose();
            }


            Console.ReadKey();
        }

        class MyClass : IDisposable
        {
            public MyClass() { }

            // Деструктор
            ~MyClass() { }

            public void Dispose()
            {
                GC.Collect();
            }
        }
    }
}
