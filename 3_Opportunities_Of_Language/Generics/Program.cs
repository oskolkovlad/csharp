﻿using System;
using System.Collections.Generic;


// Если вместо Generic использовать тип "object":

// - Упаковка(boxing) предполагает преобразование объекта значимого типа(например, типа int) к типу object.
// При упаковке общеязыковая среда CLR обертывает значение в объект типа System.Object и сохраняет его в управляемой куче(хипе).
// Распаковка(unboxing), наоборот, предполагает преобразование объекта типа object к значимому типу. Упаковка и распаковка
// ведут к снижению производительности, так как системе надо осуществить необходимые преобразования.

// - Кроме того, существует другая проблема - проблема безопасности типов.


namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //var product1 = new Product<int, decimal>("Яблоко", 100, 100);
            //var product2 = new Product<decimal, int>("Банан", 10.1m, 1100);

            var list = new List<int>();

            // (key, value)
            // Доступ к "value" по ключу "key"
            // "key" должен быть уникальным
            var map = new Dictionary<int, string>();
            map.Add(1, "Понедельник");
            map.Add(2, "Вторник");


            //************************************************************************************//

            var apple = new Apple<int>("Apple", 100);
            var eat = new Eat<Apple<int>>();

            eat.Add(apple);


            //************************************************************************************//


            Console.ReadKey();
        }
    }
}
