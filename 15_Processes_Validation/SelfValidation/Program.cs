using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SelfValidation
{
    // Нам необязательно определять правила валидации модели в виде атрибутов.
    // Мы можем применить к классу интерфейс IValidatableObject и реализовать его метод Validate().
    // В этом случае класс будет сам себя валидировать.

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("", "Tom", -3);
            Validate(user);


            Console.ReadKey();
        }

        static void Validate(User user)
        {
            ValidationContext context = new ValidationContext(user);
            var errors = new List<ValidationResult>();

            if(!Validator.TryValidateObject(user, context, errors, true))
            {
                foreach (var e in errors)
                {
                    Console.WriteLine(e.ErrorMessage);
                }
            }
        }
    }

    public class User : IValidatableObject
    {
        public User(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; }
        public string Name { get; }
        public int Age { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!string.IsNullOrWhiteSpace(Id))
            {
                errors.Add(new ValidationResult("ID не может быть пустым или равно null..."));
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(new ValidationResult("Имя не может быть пустым или равно null..."));
            }

            if (!(Age > 0 && Age < 100))
            {
                errors.Add(new ValidationResult("Возраст не может быть отрицательным или больше 100..."));
            }

            return errors;
        }
    }


}
