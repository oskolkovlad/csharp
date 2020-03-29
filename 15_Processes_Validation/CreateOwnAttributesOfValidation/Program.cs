using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreateOwnAttributesOfValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User { Id = "", Name = "Tom", Age = -22 };
            Validate(user1);
            Console.WriteLine();
            User user2 = new User { Id = "d3io", Name = "Alice", Age = 33 };
            Validate(user2);

            Console.ReadKey();
        }

        private static void Validate(User user)
        {
            ValidationContext context = new ValidationContext(user);
            var errors = new List<ValidationResult>();

            if(!Validator.TryValidateObject(user, context, errors, true))
            {
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
                Console.WriteLine("Пользователь прошел валидацию...");
        }
    }

    [UserValidation]
    public class User
    {
        [Required(ErrorMessage = "Id не может быть пустым...")]
        public string Id { get; set; }
        [Required]
        [UserNameValidation]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }


    public class UserNameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value != null)
            {
                var name = value as string;
                if (!name.StartsWith("T"))
                {
                    return true;
                }
                else
                {
                    ErrorMessage = "Имя не должно начинаться с буквы 'T'...";
                }
            }

            return false;
        }
    }

    public class UserValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is User user)
            {
                if (user.Name != "Alice" && user.Age != 66)
                {
                    return true;
                }
                else
                {
                    ErrorMessage = "Имя не должно быть Alice и возраст одновременно не должен быть равен 33";
                }
            }

            return false;
        }
    }
}
