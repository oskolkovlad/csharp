using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Конструктор получения данных пользователя.
        /// </summary>
        /// <returns> Пользователь. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                
                // TODO: Пользователь null
            }
        }

        /// <summary>
        /// Конструктор создания нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: Проверка

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Сохранение данных пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
