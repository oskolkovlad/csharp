using System;


namespace OOP_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person()
            {
                firstName = "Миша",
                lastName = "Большов",
                age = 23
                //person1.money = 1000000000; - нет доступа, так как у поля модификатор доступа "private"
            }; // Инициализатор

            // 1. С помощью инициализатора можно установить значения только доступных из внешнего кода полей и свойств
            // 2. Инициализатор выполняется полне конструктора

            Person person2 = new Person()
            {
                firstName = "Света",
                lastName = "Соколова",
                age = 19
            };

            Doctor doctor1 = new Doctor()
            {
                firstName = "Роман",
                lastName = "Щеглов",
                age = 45,
                specialization = "Хирург"
            };
            

            //*** Полиморфизм ***//

            // Если говорить упрощенно, мы можем использовать свойства и методы потомков.

            // Восходящее преобразование
            Person p = doctor1; // присвоена ссылка на объект "doctor1", но доступны будут только поля из класса "Person"
            Console.WriteLine("Person name: {0}", p.firstName);

            // Нисходящее преобразование
            Doctor d = (Doctor) p; // будет также присвоена ссылка на объект "doctor1", которая была присвоена объекту "p"

            Console.WriteLine("Doctor name: {0}", d.firstName);
            Console.WriteLine("Doctor spec: {0}", d.specialization);


            person2 = doctor1;
            Console.WriteLine("\n\nPerson name: {0}", person2.firstName);

            Person person3 = new Doctor() { firstName = "LLLOOOLLL" };
            Console.WriteLine("Person name: {0}", person3.firstName);

            Person person4 = new Person() { firstName = "Lol" };
            //Doctor doctor2 = (Doctor)person4; // Ошибка
            //Console.WriteLine("Person name: {0}", doctor2.firstName);

            //Doctor doctor3 = new Person() { firstName = "Lul" }; // Ошибка

            Doctor doctor2 = person4 as Doctor;
            if (doctor2 == null)
            {
                Console.WriteLine("\nFail!");
            }
            else
            {
                Console.WriteLine("\nDoctor name: {0}", doctor2.firstName);
            }

            if (person4 is Doctor)
                doctor2 = (Doctor)person4;
            else
                Console.WriteLine("\nFail!");


            Console.ReadKey();
        }
    }
}
