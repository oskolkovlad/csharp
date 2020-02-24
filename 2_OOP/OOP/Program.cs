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

            Person p = doctor1;
            Console.WriteLine("Person name: {0}", p.firstName);

            Doctor d = (Doctor) p;

            Console.WriteLine("Doctor name: {0}", d.firstName);
            Console.WriteLine("Doctor spec: {0}", d.specialization);


            Console.ReadKey();
        }
    }
}
