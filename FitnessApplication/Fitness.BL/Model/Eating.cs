using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Конструктор создания приема пищи.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "Пользователя не может быть равен Null.");
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Список продуктов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Добавление продуктов и их веса в список.
        /// </summary>
        /// <param name="food"> Продукт. </param>
        /// <param name="weight"> Вес продукта. </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if(product == null)
            {
                Foods[food] = weight;
            }
            else
            {
                Foods[food] += weight;
            }
        }
    }
}
