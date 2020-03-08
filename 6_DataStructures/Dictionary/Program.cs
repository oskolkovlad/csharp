using System;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary<int, string> listMap = new ListDictionary<int, string>();

            listMap.Add(1, "Tom");
            listMap.Add(13, "Alex");
            listMap.Add(4, "Sam");
            listMap.Add(7, "Jerry");
            listMap.Add(34, "Michael");
            listMap.Add(13, "John");

            foreach(var l in listMap)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();

            Console.WriteLine(listMap.Search(1) ?? "Не найдено!");
            Console.WriteLine(listMap.Search(45) ?? "Не найдено!");
            Console.WriteLine(listMap.Search(13) ?? "Не найдено!");
            Console.WriteLine(listMap.Search(34) ?? "Не найдено!");

            Console.WriteLine();

            listMap.Remove(7);
            listMap.Remove(15);
            listMap.Remove(13);
            listMap.Remove(4);

            foreach (var l in listMap)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine(new string('=', 50));


            //*************************************************************************//


            DictionaryMap<int, string> dict = new DictionaryMap<int, string>();

            dict.Add(1, "Tom");
            dict.Add(13, "Alex");
            dict.Add(4, "Sam");
            dict.Add(7, "Jerry");
            dict.Add(34, "Michael");
            dict.Add(13, "John");
            dict.Add(101, "John");

            foreach (var d in dict)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine();

            Console.WriteLine(dict.Search(1) ?? "Не найдено!");
            Console.WriteLine(dict.Search(45) ?? "Не найдено!");
            Console.WriteLine(dict.Search(13) ?? "Не найдено!");
            Console.WriteLine(dict.Search(34) ?? "Не найдено!");
            Console.WriteLine(dict.Search(101) ?? "Не найдено!");

            Console.WriteLine();

            dict.Remove(7);
            dict.Remove(15);
            dict.Remove(13);
            dict.Remove(1);
            dict.Remove(101);

            foreach (var l in dict)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine(new string('=', 50));




            //*************************************************************************//


            Console.ReadKey();
        }
    }
}
