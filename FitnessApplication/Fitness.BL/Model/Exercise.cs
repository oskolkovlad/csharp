using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Упражнения.
    /// </summary>
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Конструктор по умолчанию (требование Entity Framework).
        /// </summary>
        public Exercise() { }

        /// <summary>
        /// Конструктор создания упражнений.
        /// </summary>
        /// <param name="activity"> Вид активности. </param>
        /// <param name="user"> Пользователь. </param>
        /// <param name="start"> Время начала упражнения. </param>
        /// <param name="finish"> Время завершения упражнения. </param>
        public Exercise(Activity activity, User user, DateTime start, DateTime finish)
        {
            // TODO: checker

            Activity = activity;
            User = user;
            Start = start;
            Finish = finish;
        }


        /// <summary>
        /// Идентификатор таблицы упражнений.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор таблицы пользователей.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор таблицы видов активностей.
        /// </summary>
        public int ActivityId { get; set; }
        
        /// <summary>
        /// Вид активности.
        /// </summary>
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }


        /// <summary>
        /// Время начала упражнения.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Время завершения упражнения.
        /// </summary>
        public DateTime Finish { get; set; }
    }
}
