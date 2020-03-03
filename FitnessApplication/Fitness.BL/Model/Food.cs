using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Продукт.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Конструктор создания нового продукта.
        /// </summary>
        /// <param name="name"> Название продукта. </param>
        public Food(string name)
            : this(name, 0, 0, 0, 0)
        {
            Name = name;
        }

        /// <summary>
        /// Конструктор создания нового продукта.
        /// </summary>
        /// <param name="name"> Название продукта. </param>
        /// <param name="proteins"> Белки. </param>
        /// <param name="fats"> Жиры. </param>
        /// <param name="carbohydrates"> Углеводы. </param>
        /// <param name="calories"> Калории. </param>
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя продукта не может быть пустым или Null.");
            }
            if (proteins < 0)
            {
                throw new ArgumentException("Количество белка не может быть меньше 0.", nameof(proteins));
            }
            if (fats < 0)
            {
                throw new ArgumentException("Количество жиров не может быть меньше 0.", nameof(fats));
            }
            if (carbohydrates < 0)
            {
                throw new ArgumentException("Количество углеводов не может быть меньше 0.", nameof(carbohydrates));
            }
            if (calories < 0)
            {
                throw new ArgumentException("Количество калорий не может быть меньше 0.", nameof(calories));
            }
            #endregion

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        #region Свойство
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; }
        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
