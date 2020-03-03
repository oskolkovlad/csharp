using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;


namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователей.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Конструктор создания нового контроллера пользователей.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Имя пользователя не может быть пустым или Null.");
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser is null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;

                //Save();
            }
        }


        #region Поля и свойства
        /// <summary>
        /// Список пользователей.
        /// </summary>
        public List<User> Users { get; } // использование списка небезопасно

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Флаг нового пользователя.
        /// </summary>
        public bool IsNewUser { get; } = false;

        #endregion


        /// <summary>
        /// Установление данных новому пользователю.
        /// </summary>
        /// <param name="genderName"> Пол. </param>
        /// <param name="birthDay"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentNullException(nameof(genderName), "Имя пользователя не может быть пустым или Null.");
            }

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }

        /// <summary>
        /// Сохранение данных пользователей.
        /// </summary>
        private void Save()
        {
            Save(Users);
        }

        /// <summary>
        /// Получение данных пользователей.
        /// </summary>
        /// <returns> Список пользователей. </returns>
        private List<User> GetUsersData() => Load<User>() ?? new List<User>();
    }
}
