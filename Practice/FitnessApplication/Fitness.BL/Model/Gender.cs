using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Конструктор по умолчанию (требование Entity Framework).
        /// </summary>
        public Gender() { }

        /// <summary>
        /// Конструктор создания пола.
        /// </summary>
        /// <param name="name"> Имя пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя пола не может быть пустым или Null.");
            }

            Name = name;
        }

        public int Id { get; set; }

        public virtual ICollection<User> Users { get; set; }


        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
