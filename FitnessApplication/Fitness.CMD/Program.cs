using Fitness.BL.Controller;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доброго времени суток! Вас приветствует FitnessApplication.");
            
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения:");
            var birthDay = DateTime.Parse(Console.ReadLine()); // TODO: переписать в TryParse

            Console.WriteLine("Введите вес:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост:");
            var height = double.Parse(Console.ReadLine());


            UserController userController = new UserController(name, gender, birthDay, weight, height);
            userController.Save();


            Console.ReadKey();
        }
    }
}
