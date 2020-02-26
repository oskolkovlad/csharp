using System;

namespace Abstract_Shadowing
{
    class Program
    {
        static void Main(string[] args)
        {
            Person per = new Person("Bob");
            Doctor doc = new Doctor("Tom", "Хирург");

            per.Display();
            doc.Display();

            Person tom = new Doctor("Tom", "Педиатр");
            Console.WriteLine();
            tom.Display();  // Tom

            // Так происходит потому что класс Doctor никак не переопределяет метод Display, унаследованный
            // от базового класса, а фактически определяет новый метод.


            //****************************************************************************************************//


            Rectangle rect = new Rectangle(24, 74);
            rect.Display();


            //****************************************************************************************************//


            Console.ReadKey();
        }
    }
}
