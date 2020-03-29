using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AttributesOfValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User { Name = "", Age = -6 };

            ValidationContext context = new ValidationContext(user);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var res in results)
                {
                    Console.WriteLine(res.ErrorMessage);
                }
            }

            Console.ReadKey();
        }
    }

    public class User
    {
        [Required(ErrorMessage = "Идентификатор пользователя не установлен")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Не указано имя пользователя", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

       
        // - Phone: данный атрибут автоматически валидирует значение свойства, является ли оно телефонным номером.
        // Фактически это встроенная альтренатива использованию регулярного выражения, как было показано выше
        // - EmailAddress: определяет, является ли значение свойства электронным адресом
        // - CreditCard: определяет, является ли значение свойства номером кредитной карты
        // * Url: определяет, является ли значение свойства гиперссылкой
    }

    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$", ErrorMessage = "Номер телефона должен иметь формат +xxxx-xxx-xxxx")]
        public string Phone { get; set; }
    }
}
