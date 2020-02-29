using System;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<ICar>()
            {
                new LadaSeven(),
                new BMWSeven()
            };

            foreach(var car in cars)
            {
                car.Beep();
                Console.WriteLine("Move: {0} h\n", car.Move(167, car.Speed));

                //((LadaSeven)car).Dispose();
            }

            Cyborg cyborg = new Cyborg();
            Console.WriteLine("Move like person: {0} h", ((IPerson)cyborg).Move(167, ((IPerson)cyborg).Speed));
            Console.WriteLine("Move like car: {0} h\n", ((ICar)cyborg).Move(167, ((ICar)cyborg).Speed));


            //********************************************************************************************************//


            LadaSeven ls1 = new LadaSeven() { Speed = 100 };
            LadaSeven ls2 = new LadaSeven() { Speed = 10 };
            ls1 = ls2; // ls1 и ls2 ссылаются на один и тот же объект, изменения одного способствует и изменению другого объекта
            Console.WriteLine(ls1.Speed);
            Console.WriteLine(ls2.Speed);

            Console.WriteLine(new string('-', 60));

            // Поверхностное (неглубокое копирование)
            LadaSeven ls3 = new LadaSeven() { Speed = 100 };
            LadaSeven ls4 = new LadaSeven() { Speed = 30 };
            Console.WriteLine(ls3.Speed);
            ls3 = (LadaSeven)ls4.Clone();
            Console.WriteLine(ls3.Speed);

            Console.WriteLine(new string('-', 60));

            // Глубокое копирование
            var bmw1 = new BMWSeven() { Speed = 100, Class = new ClassOfCar() { Name = "S" } };
            var bmw2 = new BMWSeven() { Speed = 200, Class = new ClassOfCar() { Name = "L" } };
            Console.WriteLine($"Speed: {bmw1.Speed}; Class: {bmw1.Class.Name}");
            bmw1 = (BMWSeven)bmw2.Clone();
            Console.WriteLine($"Speed: {bmw1.Speed}; Class: {bmw1.Class.Name}");

            Console.WriteLine(new string('-', 60));


            //********************************************************************************************************//

            
            // IComparable
            Person p1 = new Person { Name = "Bill", Age = 34 };
            Person p2 = new Person { Name = "Tom", Age = 23 };
            Person p3 = new Person { Name = "Alice", Age = 21 };

            Person[] people = new Person[] { p1, p2, p3 };
            Array.Sort(people);
            foreach (var p in people)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(new string('-', 60));

            // IComparer
            Person p4 = new Person { Name = "Bill", Age = 34 };
            Person p5 = new Person { Name = "Tom", Age = 23 };
            Person p6 = new Person { Name = "Alice", Age = 21 };

            Person[] people1 = new Person[] { p4, p5, p6 };
            Array.Sort(people1, new PeopleComparer());
            foreach (var p in people1)
            {
                Console.WriteLine(p);
            }


            //********************************************************************************************************//


            Console.ReadKey();
        }


        class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public int CompareTo(Person p)
            {
                return this.Name.CompareTo(p.Name);
            }

            public override string ToString()
            {
                return $"Name: {Name}; Age: {Age}";
            }
        }

        // Имеет приоритет над IComparable
        // Можно задать несколько классов с различными вариантами сортировки
        class PeopleComparer : IComparer<Person>
        {
            public int Compare(Person p1, Person p2)
            {
                if (p1.Name.Length > p2.Name.Length)
                    return 1;
                else if (p1.Name.Length < p2.Name.Length)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
