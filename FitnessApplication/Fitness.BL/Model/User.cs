using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Конструктор создания нового пользователя.
        /// </summary>
        /// <param name="name"> Имя пользователя. </param>
        public User(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Конструктор создания нового пользователя.
        /// </summary>
        /// <param name="name"> Имя пользователя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDay"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, Gender gender, DateTime birthDay, double weight, double height)
        {
            #region Проверка свойств класса
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя пользователя не может быть пустым или Null.");
            }
            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender), "Пол пользователя не может быть Null.");
            }
            if (birthDay < DateTime.Parse("01.01.1920") || birthDay >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDay));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес пользователя не может быть равен 0.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост пользователя не может быть равен 0.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Weight = weight;
            Height = height;
        }

        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age { get => DateTime.Now.Year - BirthDay.Year; }
        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - BirthDay.Year;
        //if(BirthDay > nowDate.AddYears(-age)) age--;
        #endregion

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
