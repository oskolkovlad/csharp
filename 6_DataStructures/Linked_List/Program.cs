using System;

namespace Linked_List_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Связный список(Linked List) представляет набор связанных узлов, каждый из которых хранит собственно
            // данные и ссылку на следующий узел. В реальной жизни связный список можно представить в виде поезда,
            // каждый вагон которого может содержать некоторый груз или пассажиров и при этом может быть связан с другим вагоном.

            var list = new LinkedList<int>();
            list.Add(4);
            list.Add(5);
            list.Add(1);
            list.AppendFirst(10);
            Console.WriteLine(list);

            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var flag = list.Remove(1);
            Console.WriteLine(flag);
            Console.WriteLine(list);

            Console.WriteLine();
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            list.InsertAfter(4, 777);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine(list.IsEmpty);
            list.RemoveAll();
            Console.WriteLine(list);

            Console.WriteLine(list.IsEmpty);


            Console.ReadKey();
        }
    }
}
