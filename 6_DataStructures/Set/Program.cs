using System;
using System.Collections.Generic;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            // - HashSet<T> содержит неповторяющюся коллекцию элементов.
            // - HashSet<T> содержит элементы неупорядоченно (без сортировки). 
            // - HashSet<T> позволяет быстро определить, есть такой элемент или нет (быстро потому что,
            // использует индекс, который вычисляется из хэш-кода элемента). 
            // - HashSet < T > -имеет методы Add, Remove, Contains, но поскольку он использует хэш-реализацию,
            // эти операции занимают 1 действие (методы Contains и Remove в List < T > занимает n - действий.)
            
            // HashSet<T> имеет методы:
            //  - UnionWith(объединение элементов с другим HashSet<T>)
            //  - IntersectWith(пересечение элементов с другим HashSet<T>)
            //  - ExceptWith(разность элементов с другим HashSet<T>)
            //  - SymmetricExceptWith (симетрическая разность элементов с другим HashSet<T>)


            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            set1.Add(1);
            set1.Add(4);
            set1.Add(5);
            set1.Add(3);
            set1.Add(777);
            //set1.Add(777);

            set2.Add(1);
            set2.Add(45);
            set2.Add(23);
            set2.Add(3);
            set2.Add(777);

            Console.Write("set1: ");
            foreach(var s in set1)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("set2: ");
            foreach (var s in set2)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            
            


            set1.UnionWith(set2);
            Console.Write("Union: ");
            foreach (var s in set1)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            set1 = new HashSet<int>() { 1, 4, 5, 3, 777};
            set1.IntersectWith(set2);
            Console.Write("Intersect: ");
            foreach (var s in set1)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            set1 = new HashSet<int>() { 1, 4, 5, 3, 777 };
            set1.ExceptWith(set2);
            Console.Write("Except 1 - 2: ");
            foreach (var s in set1)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            set1 = new HashSet<int>() { 1, 4, 5, 3, 777 };
            set2.ExceptWith(set1);
            Console.Write("Except 2 - 1: ");
            foreach (var s in set2)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            set1.SymmetricExceptWith(set2);
            set2 = new HashSet<int>() { 1, 45, 23, 3, 777 };
            Console.Write("Sym Dif: ");
            foreach (var s in set1)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();



            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();


            //****************************************************************************//


            // Каждый элемент множества (Set) уникален.
            // Они могут быть неупорядоченными.

            // - Объединения (Union).
            // - Пересечение (intersection).
            // - Разность - (difference).
            // - Симметричная разность - (symmetric difference).
            // - Подмножество - (subset).

            ListSet<int> listSet = new ListSet<int>();
            ListSet<int> listSet1 = new ListSet<int>();
            ListSet<int> listSet2 = new ListSet<int>();

            listSet.Add(1);
            listSet.Add(4);
            listSet.Add(5);
            listSet.Add(3);
            listSet.Add(777);
            //listSet.Add(777);

            listSet1.Add(1);
            listSet1.Add(45);
            listSet1.Add(23);
            listSet1.Add(3);
            listSet1.Add(777);

            listSet2.Add(3);
            listSet2.Add(777);

            Console.WriteLine(listSet);
            Console.WriteLine(listSet.Contains(777));
            Console.WriteLine(listSet.Contains(777777));
            Console.WriteLine();

            foreach(var s in listSet)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            listSet.Remove(5);
            listSet.Remove(1);
            //listSet.Remove(45);
            Console.WriteLine();

            Console.WriteLine(listSet);

            Console.Write("listSet: ");
            foreach (var s in listSet)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("listSet1: ");
            foreach (var s in listSet1)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("listSet2: ");
            foreach (var s in listSet2)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();


            Console.WriteLine(new string('+', 50));
            Console.WriteLine();

            var diff = listSet.Difference(listSet1);
            var union = listSet.Union(listSet1);
            var intersect = listSet.Intersection(listSet1);
            var sub = listSet1.SubSet(listSet2);
            var sDiff = listSet.SymmetricDifference(listSet1);
            Console.WriteLine();


            Console.Write("Union: ");
            foreach (var s in union)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("Intersection: ");
            foreach (var s in intersect)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("Difference: ");
            foreach (var s in diff)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("Symmetric Difference: ");
            foreach (var s in sDiff)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.WriteLine("SubSet: {0}", sub);
            Console.WriteLine();

            Console.Write("listSet: ");
            foreach (var s in listSet)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("listSet1: ");
            foreach (var s in listSet1)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();


            //****************************************************************************//


            Console.ReadKey();
        }
    }
}
