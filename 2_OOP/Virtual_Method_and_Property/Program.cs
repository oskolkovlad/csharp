using System;


namespace Virtual_Method_and_Property
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Bill");
            p1.Display(); // вызов метода Display из класса Person

            Employee p2 = new Employee("Tom", "Microsoft");
            p2.Display(); // вызов метода Display из класса Employee


            LongCredit credit = new LongCredit { Sum = 6000 };
            credit.Sum = 490;
            Console.WriteLine(credit.Sum);


            Console.ReadKey();
        }
    }
}
