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
        /// Конструктор по умолчанию (требование Entity Framework).
        /// </summary>
        public Eating() { }

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
        /// Идентификатор таблицы приемов пищи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор таблицы пользователей (FK).
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Список продуктов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }


        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; set; }


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
