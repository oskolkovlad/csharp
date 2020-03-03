using Fitness.BL.Controller;
using Fitness.BL.Model;
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
            var eatingController = new EatingController(userController.CurrentUser);

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

            Console.WriteLine("Что вы хотите сделать? Нажмите нужную клавишу.");
            Console.WriteLine("Е - ввести прием пищи.");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var enterEating = EnterEating();
                eatingController.Add(enterEating.Food, enterEating.Weight);

                foreach(var f in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{f.Key}: {f.Value}");
                }
            }


            Console.ReadKey();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();

            ParseDouble("вес порции", out double weight);
            ParseDouble("количество калорий", out double calories);
            ParseDouble("количество белков", out double proteins);
            ParseDouble("количество жиров", out double fats);
            ParseDouble("количество углеводов", out double carbohydrates);

            var food = new Food(foodName, proteins, fats, carbohydrates, calories);

            return (food, weight);
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
