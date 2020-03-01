using System;
using System.Collections;

namespace ArrayListCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList представляет коллекцию объектов. И если надо сохранить вместе
            // разнотипные объекты - строки, числа и т.д., то данный класс как раз для этого подходит.

            ArrayList arrayList = new ArrayList() { 1, 2.34, "lol" };
            arrayList.Add(DateTime.Now);
            arrayList.AddRange(new int[] { 1, 2, 3, 4 });

            foreach(var a in arrayList)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();

            arrayList.RemoveAt(0);
            arrayList.Reverse();

            Console.WriteLine(arrayList[5]);

            Console.WriteLine();

            for(var i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }

            Console.ReadKey();
        }
    }
}
