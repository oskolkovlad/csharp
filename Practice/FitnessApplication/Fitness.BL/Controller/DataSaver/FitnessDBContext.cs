using Fitness.BL.Model;
using System.Data.Entity;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контекст БД Фитнес приложения.
    /// </summary>
    public class FitnessDBContext : DbContext
    {
        /// <summary>
        /// Конструктор создания контекста БД
        /// </summary>
        public FitnessDBContext()
            : base("DBConnectionString") { }


        /// <summary>
        /// Таблица видов активностей.
        /// </summary>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Таблица упражнений.
        /// </summary>
        public DbSet<Exercise> Exercises { get; set; }

        /// <summary>
        /// Таблица продуктов.
        /// </summary>
        public DbSet<Food> Foods { get; set; }

        /// <summary>
        /// Таблица приемов пищи.
        /// </summary>
        public DbSet<Eating> Eatings { get; set; }

        /// <summary>
        /// Таблица пола.
        /// </summary>
        public DbSet<Gender> Genders { get; set; }

        /// <summary>
        /// Таблица пользователей.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}