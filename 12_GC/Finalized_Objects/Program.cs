using System;

namespace Finalized_Objects
{
    // Общие рекомендации по использованию Finalize и Dispose:

    // - Деструктор следует реализовывать только у тех объектов, которым он действительно необходим,
    // так как метод Finalize оказывает сильное влияние на производительность

    // - После вызова метода Dispose необходимо блокировать у объекта вызов метода Finalize с помощью GC.SuppressFinalize

    // - При создании производных классов от базовых, которые реализуют интерфейс IDisposable, следует
    // также вызывать метод Dispose базового класса:

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Деструктор:\t Старт");
            TestPerson();
            GC.Collect();
            Console.WriteLine("Деструктор:\t Финиш");


            Console.WriteLine();


            Console.WriteLine("IDisposable:\t Старт");
            TestAnimal();
            GC.Collect();
            Console.WriteLine("IDisposable:\t Финиш");


            Console.WriteLine();


            Console.WriteLine("Деструктор и IDisposable:\t Старт");
            TestAnimal();
            GC.Collect();
            Console.WriteLine("Деструктор и IDisposable:\t Финиш");



            Console.ReadKey();
        }

        static void TestPerson()
        {
            Person person = new Person("Tom");
        }

        static void TestAnimal()
        {
            Animal animal = null;

            // Можно просто вызывать: animal.Dispose();
            // Но конструкцию try...finally предпочтительнее использовать при вызове метода Dispose, так как
            // она гарантирует, что даже в случае возникновения исключения произойдет освобождение ресурсов в методе Dispose.
            try
            {
                animal = new Animal("Panda");
            }
            finally
            {
                if(animal != null)
                {
                    animal.Dispose();
                }
            }
        }

        static void TestPlant()
        {
            Plant plant = null;

            try
            {
                plant = new Plant("Rose");
            }
            finally
            {
                if (plant != null)
                {
                    plant.Dispose();
                }
            }
        }


        class Person
        {
            public Person(string name)
            {
                Name = name;
            }

            public string Name { get; }

            // Деструктор в отличие от конструктора не может иметь модификаторов доступа. В данном случае в деструкторе
            // в целях демонстрации просто вызывается звуковой сигнал и выводится строка на консоль, но в реальных
            // программах в деструктор вкладывается логика освобождения неуправляемых ресурсов.

            // Однако на деле при очистке сборщик мусора вызывает не деструктор, а метод Finalize класса Person.
            ~Person()
            {
                Console.Beep();
                Console.WriteLine("Disposed...");
            }
        }

        class Animal : IDisposable
        {
            public Animal(string name)
            {
                Name = name;
            }

            public string Name { get; }

            public void Dispose()
            {
                Console.Beep();
                Console.WriteLine("Disposed...");
            }
        }

        class Plant : IDisposable
        {
            public Plant(string name)
            {
                Name = name;
            }

            public string Name { get; set; }

            private bool dispose = false;

            ~Plant()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                // вызов в методе Dispose метода GC.SuppressFinalize(this). GC.SuppressFinalize не позволяет
                // системе выполнить метод Finalize для данного объекта.
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!dispose)
                {
                    if (disposing)
                    {
                        // Освобождаем управляемые ресурсы
                    }

                    Console.Beep();
                    Console.WriteLine("Disposed...");

                    dispose = true;
                }
            }
        }
    }
}
