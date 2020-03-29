using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationBase
{
    class Program
    {
        static void Main(string[] args)
        {
            //User user = new User();

            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            int age = int.Parse(Console.ReadLine());

            /*if (!string.IsNullOrEmpty(name) && name.Length > 1)
                user.Name = name;
            else
                Console.WriteLine("некорректное имя");

            if (age >= 1 && age <= 100)
                user.Age = age;
            else
                Console.WriteLine("некорректный год");*/



            //*************************************************************//


            User user = new User { Name = name, Age = age };

            // Здесь предполагается, что имя должно иметь больше 1 символа, а возраст должен быть в диапазоне от 1 до 100.
            // Однако в классе может быть гораздо больше свойств, для которых надо осуществлять проверки.
            // А это привет к тому, что увеличится значительно код программы за счет проверок.
            //К тому же задача валидации данных довольно часто встречается в приложениях.
            //Поэтому фреймворк .NET предлагает гораздо более удобный функционал в виде атрибутов из пространства
            // имен System.ComponentModel.DataAnnotations.

            ValidationContext context = new ValidationContext(user);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var res in results)
                {
                    Console.WriteLine(res.ErrorMessage);
                }
            }

            // Вначале мы создаем контекст валидации - объект ValidationContext. В качестве первого параметра в
            // конструктор этого класса передается валидируемый объект, то есть в данном случае объект User.

            // Собственно валидацию производит класс Validator и его метод TryValidateObject().
            // В этот метод передается валидируемый объект(в данном случае объект user), контекст валидации, список объектов
            // ValidationResult и булевый параметр, указывающий, надо ли валидировать все свойства.



            Console.ReadKey();
        }

        public class User
        {
            [Required]
            public string Id { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string Name { get; set; }

            [Required]
            [Range(1, 100)]
            public int Age { get; set; }
        }
    }
}
