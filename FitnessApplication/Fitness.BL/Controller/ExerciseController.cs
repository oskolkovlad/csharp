using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер упражнений.
    /// </summary>
    public class ExerciseController : BaseController
    {
        /// <summary>
        /// Конструктор создания контроллера упражнений.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Пользователя не может быть равен Null.");

            Exercises = GetExercisesData();
            Activities = GetActivitiesData();
        }


        /// <summary>
        /// Пользователь.
        /// </summary>
        private User user;

        /// <summary>
        /// Список упражнений.
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// Список типов активностей
        /// </summary>
        public List<Activity> Activities { get; }

        /// <summary>
        /// Название файла для данных упражнений.
        /// </summary>
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";


        /// <summary>
        /// Сохранение данных об упражнениях.
        /// </summary>
        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }

        /// <summary>
        /// Получение данных об упражнениях.
        /// </summary>
        /// <returns> Список упражнений. </returns>
        private List<Exercise> GetExercisesData()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        /// <summary>
        /// Получение данных о видах активности.
        /// </summary>
        /// <returns> Список видов активности. </returns>
        private List<Activity> GetActivitiesData()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        /// <summary>
        /// Добавление упражнения.
        /// </summary>
        /// <param name="activity"> Вид активности. </param>
        /// <param name="start"> Время начала упражнения. </param>
        /// <param name="finish"> Время завершения упражнения. </param>
        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            

            if (act is null)
            {
                Activities.Add(activity);
            }
            else
            {
                activity = act;
            }

            var exercise = new Exercise(activity, user, start, finish);
            Exercises.Add(exercise);

            Save();
        }
    }
}
