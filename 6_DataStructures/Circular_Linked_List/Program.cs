using System;

namespace Circular_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // Односвязный кольцевой список

            CircularLinkedListOne<int> list1 = new CircularLinkedListOne<int>();

            list1.Add(34);
            list1.Add(4);
            list1.Add(3);
            list1.Add(354);
            list1.Add(23);
            list1.AddFirst(777);

            Console.WriteLine(list1);
            foreach(var l in list1)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine();
            Console.WriteLine(list1.Contains(354));
            Console.WriteLine(list1.Contains(35));
            Console.WriteLine();

            Console.WriteLine(list1.Remove(354));
            Console.WriteLine(list1.Remove(23));
            Console.WriteLine(list1.Remove(777));
            Console.WriteLine(list1.Remove(777));
            Console.WriteLine();

            Console.WriteLine(list1);
            foreach (var l in list1)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine(new string('-', 50));


            //********************************************************************************************//


            // Двухсвязный кольцевой список

            CircularLinkedListTwo<int> list2 = new CircularLinkedListTwo<int>();

            list2.Add(34);
            list2.Add(4);
            list2.Add(3);
            list2.Add(354);
            list2.Add(23);
            list2.Add(777);

            Console.WriteLine(list2);
            foreach (var l in list2)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine();
            Console.WriteLine(list2.Contains(354));
            Console.WriteLine(list2.Contains(35));
            Console.WriteLine();

            Console.WriteLine(list2.Remove(354));
            Console.WriteLine();

            foreach (var l in list2)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();

            Console.WriteLine(list2.Remove(34));
            Console.WriteLine();

            foreach (var l in list2)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();

            Console.WriteLine(list2.Remove(777));
            Console.WriteLine();

            foreach (var l in list2)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();

            Console.WriteLine(list2.Remove(777));
            Console.WriteLine();

            Console.WriteLine(list2);
            foreach (var l in list2)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();

            foreach (var l in list2.BackGetEnumerator())
            {
                Console.WriteLine(l);
            }
            
            Console.WriteLine(new string('-', 50));

            Console.ReadKey();
        }
    }
}
