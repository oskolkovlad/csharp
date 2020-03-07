using System;
using System.Collections;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var badHT = new BadHashTable<int>(100);

            badHT.Add(5);
            badHT.Add(18);
            badHT.Add(777);
            badHT.Add(644);

            Console.WriteLine(badHT.Search(777)); // Перетерлось значением 644 - false
            Console.WriteLine(badHT.Search(644)); // True
            Console.WriteLine(badHT.Search(77)); // False

            Console.WriteLine(new string('=', 50));


            //*******************************************************************************//


            var ht = new MiddleHashTable<int, string>(100);

            ht.Add(5, "Hello");
            ht.Add(18, "my");
            ht.Add(777, "dear");
            ht.Add(644, "world");
            ht.Add(64, "!");

            Console.WriteLine(ht.Search(777, "dear"));
            Console.WriteLine(ht.Search(644, "world"));
            Console.WriteLine(ht.Search(64, "!"));
            Console.WriteLine(ht.Search(6, "lol"));
            Console.WriteLine(ht.Search(5, "Вася"));

            Console.WriteLine(new string('=', 50));


            //*******************************************************************************//


            var hashTable = new HashTable<string>(100);

            hashTable.Add("Hello");
            hashTable.Add("my");
            hashTable.Add("dear");
            hashTable.Add("world");
            hashTable.Add("!");

            Console.WriteLine(hashTable.Search("dear"));
            Console.WriteLine(hashTable.Search("world"));
            Console.WriteLine(hashTable.Search("!"));
            Console.WriteLine(hashTable.Search("lol"));
            Console.WriteLine(hashTable.Search("Вася"));

            Console.WriteLine(new string('=', 50));


            //*******************************************************************************//


            var hashTableP = new HashTable<Person>(100);
            var per1 = new Person("Michael", 45);
            var per2 = new Person("Tom", 23);
            var per3 = new Person("Tom", 44);

            hashTableP.Add(per2);
            hashTableP.Add(new Person("John", 21));
            hashTableP.Add(per1);
            hashTableP.Add(new Person("Tom", 75));
            hashTableP.Add(new Person("Alex", 3));

            Console.WriteLine(hashTableP.Search(per1));
            Console.WriteLine(hashTableP.Search(per2));
            Console.WriteLine(hashTableP.Search(per3));

            Console.WriteLine(new string('=', 50));


            //*******************************************************************************//


            Hashtable htCol = new Hashtable();
            htCol.Add(5, "Hello");
            htCol.Add(18, "my");
            htCol.Add(777, "dear");
            htCol.Add(644, "world");
            htCol.Add(64, "!");

            Console.WriteLine(htCol[18]);
            Console.WriteLine(htCol[777]);
            Console.WriteLine(htCol[17]);
            Console.WriteLine();

            foreach(var k in htCol.Keys)
            {
                Console.WriteLine($"Key - Value: {k} - {htCol[k]}");
            }
            Console.WriteLine();


            //*******************************************************************************//


            Console.ReadKey();
        }
    }
}
