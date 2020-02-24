using System;

namespace Class_Property_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person person1 = new Person("Маша", "Распутина");

            person.SetName("Рома");
            Console.WriteLine("Person name: {0}\n", person.GetName());

            person._Name = "Степа";
            Console.WriteLine("Person name: {0}\n", person._Name);

            Console.WriteLine("Person name: {0}", person.Name = "Дима");
            Console.WriteLine("Person second name: {0}", person.SecondName = "Пупкин");
            Console.WriteLine("Person full name: {0}\n", person.FullName);

            Console.WriteLine("Person name: {0}", person1.Name);
            Console.WriteLine("Person second name: {0}", person1.SecondName);
            Console.WriteLine("Person full name: {0}\n", person1.FullName);


            Console.ReadKey();
        }
    }
}
