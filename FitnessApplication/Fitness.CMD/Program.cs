using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("InputUserName", culture));
            var name = Console.ReadLine();

            UserController userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("InputGender", culture));
                var genderName = Console.ReadLine();

                ParseDataTime(resourceManager.GetString("Birthday", culture), out DateTime birthDay);
                ParseDouble(resourceManager.GetString("UserWeight", culture), out double weight);
                ParseDouble(resourceManager.GetString("Height", culture), out double height);

                userController.SetNewUserData(genderName, birthDay, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine(resourceManager.GetString("DoAction", culture));
            Console.WriteLine(resourceManager.GetString("KeyE", culture));
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

        /// <summary>
        /// Ввод данных о продукте.
        /// </summary>
        /// <returns> Продукт, вес продукта. </returns>
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

        /// <summary>
        /// Парсер строки в число с плавающей точкой.
        /// </summary>
        /// <param name="name"> Название поля. </param>
        /// <param name="result"> Число с плавающей точкой. </param>
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

        /// <summary>
        /// Парсер строки в дату.
        /// </summary>
        /// <param name="name"> Название поля. </param>
        /// <param name="result"> Дата. </param>
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
