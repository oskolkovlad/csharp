using System;

namespace Linked_List_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Двусвязные списки также представляют последовательность связанных узлов,
            // однако теперь каждый узел хранит ссылку на следующий и на предыдущий элементы.

            LinkedList<int> list = new LinkedList<int>();
            list.Add(3);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            list.Add(45);
            list.Add(89);

            Console.WriteLine(list);
            Console.WriteLine();

            foreach(var i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine(list.Remove(89));
            Console.WriteLine(list);
            Console.WriteLine();

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            foreach (var i in list.BackGetEnumerator())
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
