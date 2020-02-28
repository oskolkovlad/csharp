using System;
using System.Collections.Generic;

namespace Indexer_Yield_IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>()
            {
                new Car("Ford", "А001АА01"),
                new Car("Lada", "В727ЕТ77")
            };

            var parking = new Parking("Гаражное");
            foreach(var car in cars)
            {
                parking.Add(car);
                car.ToString();
            }

            Console.WriteLine($"Количество автомобилей на парковке: {parking.Count}");
            parking.GoOut("В727ЕТ77");
            Console.WriteLine($"Количество автомобилей на парковке: {parking.Count}");

            Console.WriteLine("Indexer: {0}", parking["А001АА01"]);
            //Console.WriteLine("Введите порядковый номер автомобиля:");
            //Console.WriteLine("Indexer: {0}", parking[int.Parse(Console.ReadLine())]?.ToString());
            
            parking[0] = new Car("Audi", Console.ReadLine());
            Console.WriteLine("Indexer: {0}", parking[0]);


            Console.WriteLine(new string('-', 50));


            // IEnumerable - IEnumerator - перебор коллекции
            foreach(var car in parking)
            {
                Console.WriteLine(car);
            }


            Console.WriteLine(new string('-', 50));


            // Итератор yield
            foreach (var name in parking.GetNameCars())
            {
                Console.WriteLine(name);
            }


            Console.ReadKey();
        }
    }
}
