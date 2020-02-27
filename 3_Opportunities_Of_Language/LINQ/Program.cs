using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<int>();
            
            for(var i = 0; i < 10; i++)
            {
                collection.Add(i);
            }

            // LINQ: Стандартная форма записи (как запрос SQL)
            var result1 = from item in collection
                         where item < 5
                         select item;
            ShowResult(result1);


            // LINQ: Методы расширений
            var result2 = collection.Where(item => item >= 5)
                                    .Where(item => item % 2 == 0);
            ShowResult(result2);



            var products = new List<Product>();

            for(var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Apple " + i,
                    Energy = (new Random()).Next(10, 15)
                };

                products.Add(product);
            }
            ShowResult(products);
            

            var result3 = from item in products
                          where item.Energy < 100
                          select item;
            ShowResult(result3);

            var result4 = products.Where(item => item.Energy < 100);
            ShowResult(result4);


            //*** Select ***//
            // Преобразование одной коллекции в другую с помощью метода расширения Select
            var selectCollection = products.Select(item => item.Energy);
            ShowResult(selectCollection);


            //*** OrderBy и ThenBy ***//
            // Упорядочивание элементов в коллекции с помощью методов расширения OrderBy и ThenBy
            var orderbyCollection = products.OrderBy(item => item.Energy)
                                            .ThenByDescending(item => item.Name);
            ShowResult(orderbyCollection);


            //*** GroupBy ***//
            // Группировка элементов в коллекции (Dictionary) с помощью метода расширения GroupBy
            var groupbyCollection = products.GroupBy(item => item.Energy);

            foreach(var group in groupbyCollection)
            {
                Console.WriteLine($"Key: {group.Key}");
                foreach(var item in group)
                {
                    Console.WriteLine($"\tItem: {item}");
                }
            }

            //*** Reverse ***//
            // Реверс элементов в коллекции с помощью метода расширения Reverse
            var reverseCollection = products;
            reverseCollection.Reverse();
            ShowResult(reverseCollection);


            //*** All и Any ***// - bool
            //  Проверка элементов в коллекции с помощью методов расширения All и Any
            var allCollection = products.All(item => item.Energy == 10);
            Console.WriteLine("All: {0}", allCollection);
            var anyCollection = products.Any(item => item.Energy == 10);
            Console.WriteLine("Any: {0}", anyCollection);
            Console.WriteLine(new string('-', 50));
            

            //*** Contains ***// - bool
            //  Проверка вхождения элемента в коллекцию с помощью методов расширения Contains
            var containsCollection = products.Contains(products[2]);
            Console.WriteLine("Contains: {0}", containsCollection);
            Console.WriteLine(new string('-', 50));


            //*** Sum, Max и Min ***// - агрегатные методы
            //  Суммирование, нахождение максимального и минимального элементов в коллекции с помощью методов расширения Sum, Max и Min
            var sumCollection = products.Sum(item => item.Energy);
            Console.WriteLine("Sum: {0}", sumCollection);
            var minCollection = products.Min(item => item.Energy);
            Console.WriteLine("Min: {0}", minCollection);
            var maxCollection = products.Max(item => item.Energy);
            Console.WriteLine("Max: {0}", maxCollection);
            Console.WriteLine(new string('-', 50));


            //*** Aggregate ***//
            // Можно задавать произвольные агрегатные функции с помощью методов расширения Distinct
            //int aggregateCollection = products.Aggregate((x, y) => x * y);
            //ShowResult(aggregateCollection);


            //*** Distinct ***//
            // Удаление повторяющихся элементов из коллекции с помощью методов расширения Distinct
            var union = products.Union(products);
            var disctintsCollection = union.Distinct();
            ShowResult(disctintsCollection);


            //*** Intersect ***//
            // Получение пересекающихся элементов коллекций с помощью методов расширения Intersect
            var intersectCollection = union.Intersect(products);
            ShowResult(disctintsCollection);


            //*** Except ***//
            // Разность коллекций с помощью методов расширения Except
            var exceptCollection = union.Except(products);
            ShowResult(disctintsCollection);


            //*** Skip ***//
            // Пропускает заданное количество элементов коллекции с помощью методов расширения Skip
            var skipCollection = products.Skip(5);
            ShowResult(skipCollection);


            //*** Take ***//
            // Оставляет заданное количество элементов коллекции, начиная с начала, с помощью методов расширения Take
            var takeCollection = products.Take(5);
            ShowResult(takeCollection);


            //*** First, Last, Single, ElementAt ***//
            // Операции выбора элементов из коллекции
            var firstCollection = products.FirstOrDefault();
            firstCollection = products.FirstOrDefault(item => item.Energy == 10);
            var lastCollection = products.LastOrDefault();
            lastCollection = products.LastOrDefault(item => item.Energy == 10);

            // нужно чтобы этот элемент был единственный, иначе вылетит ошибка
            var singleCollection = products.SingleOrDefault(item => item.Energy == 100);
            var elementATCollection = products.ElementAt(5);
            Console.WriteLine("FirstOrDefault "  + firstCollection);
            Console.WriteLine("LastOrDefault "   + lastCollection);
            Console.WriteLine("SingleOrDefault " + singleCollection);
            Console.WriteLine("ElementAt " + elementATCollection);

            Console.WriteLine(new string('-', 50));


            Console.ReadKey();
        }
        
        static void ShowResult<T>(IEnumerable<T> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine(new string('-', 50));
        }
    }
}
