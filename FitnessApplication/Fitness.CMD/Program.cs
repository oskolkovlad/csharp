using Fitness.BL.Controller;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доброго времени суток! Вас приветствует FitnessApplication.\n");
            
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var genderName = Console.ReadLine();

                ParseDataTime("дату рождения", out DateTime birthDay);
                ParseDouble("вес", out double weight);
                ParseDouble("рост", out double height);

                userController.SetNewUserData(genderName, birthDay, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);


            Console.ReadKey();
        }

        private static void ParseDouble(string name, out double result)
        {
            Console.Write($"Введите {name}: ");;

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат. Попробуйте еще раз.");
                }
            }
        }

        private static void ParseDataTime(string name, out DateTime result)
        {
            Console.Write($"Введите {name} (ДД.ММ.ГГГГ): ");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат. Попробуйте еще раз.");
                }
            }
        }
    }
}
