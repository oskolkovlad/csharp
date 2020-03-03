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
        /// Вид активности.
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Время начала упражнения.
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Время завершения упражнения.
        /// </summary>
        public DateTime Finish { get; }
    }
}
