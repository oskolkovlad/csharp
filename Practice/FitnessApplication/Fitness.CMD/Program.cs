using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Linq;
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
            var exerciseController = new ExerciseController(userController.CurrentUser);

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

            while (true)
            {

            Console.WriteLine(resourceManager.GetString("DoAction", culture));
            Console.WriteLine(resourceManager.GetString("KeyE", culture));
            Console.WriteLine("A - ввести упражнение");
            Console.WriteLine("Q - выйти из приложения");

            var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        Console.WriteLine();
                        var enterEating = EnterEating();
                        eatingController.Add(enterEating.Food, enterEating.Weight);

                        foreach (var f in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{f.Key}: {f.Value}");
                        }
                        Console.WriteLine();
                        break;

                    case ConsoleKey.A:
                        Console.WriteLine();
                        var enterExercise = EnterExercise();
                        exerciseController.Add(enterExercise.Activity, enterExercise.Start, enterExercise.Finish);

                        foreach (var exe in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{exe.Activity}: {exe.Start.ToShortTimeString()} - {exe.Finish.ToShortTimeString()}");
                        }
                        Console.WriteLine();
                        break;
                    case ConsoleKey.Q:
                        return; // Environment.Exit(0);
                }
            }
        }

        private static (Activity Activity, DateTime Start, DateTime Finish) EnterExercise()
        {
            Console.Write("Введите название активности: ");
            var activityName = Console.ReadLine();
            ParseDouble("расход калорий в минуту", out double calories);
            var activity = new Activity(activityName, calories);

            ParseDataTime("время начала упражнения", out DateTime start);
            ParseDataTime("время завершения упражнения", out DateTime finish);

            return (activity, start, finish);
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
            Console.Write($"Введите {name}: ");
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
