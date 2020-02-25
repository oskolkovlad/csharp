using static System.Console;
using lib = MyLib;


namespace CreateLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            lib.Person person = new lib.Person("Петров", "Петр");

            for (var i = 0; i < 10; i++)
            {
                WriteLine(person.Walk());
            }


            ReadKey();
        }
    }
}
