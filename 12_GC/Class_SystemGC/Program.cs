using System;

namespace Class_SystemGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(10, 10);

            //  возвращает объем памяти в байтах, которое занято в управляемой куче
            long memoryUsed = GC.GetTotalMemory(false);
            Console.WriteLine(memoryUsed);

            // позволяет определить номер поколения, к которому относится переданный в качестве параметра объект
            int generation = GC.GetGeneration(point);
            Console.WriteLine(generation);

            // приводит в действие механизм сборки мусора. Перегруженные версии метода позволяют указать поколение
            // объектов, вплоть до которого надо произвести сборку мусора
            GC.Collect(0, GCCollectionMode.Forced);
            // приостанавливает работу текущего потока до освобождения всех объектов, для которых производится сборка мусора
            GC.WaitForPendingFinalizers();

            memoryUsed = GC.GetTotalMemory(false);
            Console.WriteLine(memoryUsed);


            Console.ReadKey();
        }

        class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; }
            public int Y { get; }
        }
    }
}
