using System;


namespace OOP_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person();

            person1.firstName = "Миша";
            person1.lastName = "Большов";
            person1.age = 23;
            //person1.money = 1000000000; - нет доступа, так как у поля модификатор доступа "private"

            person2.firstName = "Света";
            person2.lastName = "Соколова";
            person2.age = 19;

            Doctor doctor1 = new Doctor();
            doctor1.firstName = "Роман";
            doctor1.lastName = "Щеглов";
            doctor1.age = 45;
            doctor1.specialization = "Хирург";


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
