using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер приема пищи.
    /// </summary>
    public class EatingController : BaseController
    {

        /// <summary>
        /// Конструктор создания контроллера приема пищи.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Пользователя не может быть равен Null.");
            Foods = GetFoodsData();
            Eating = GetEatingData();
        }


        #region Поля и свойства
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Названия файла с продуктами.
        /// </summary>
        private const string FOODS_FILE_NAME = "foods.dat";

        /// <summary>
        /// Название файла с приемами пищи.
        /// </summary>
        private const string EATING_FILE_NAME = "eatings.dat";

        /// <summary>
        /// Список продуктов.
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Список приема пищи.
        /// </summary>
        public Eating Eating { get; }
        #endregion

        /// <summary>
        /// Сохранение данных о продуктах и приеме пищи.
        /// </summary>
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }

        /// <summary>
        /// Получение данных о продуктах.
        /// </summary>
        /// <returns> Список продуктов. </returns>
        private List<Food> GetFoodsData() => Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();

        /// <summary>
        /// Получение данных о приеме пищи.
        /// </summary>
        /// <returns> Данные приема пищи. </returns>
        private Eating GetEatingData() => Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if(product is null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);

                Save();
            }
            else
            {
                Eating.Add(food, weight);
                Save();
            }
        }
    }
}
 