using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Вид активности.
    /// </summary>
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Конструктор создания вида активности.
        /// </summary>
        /// <param name="name"> Название вида активности. </param>
        /// <param name="caloriesPerMinute"> Калории, сжигаемые за минуту. </param>
        public Activity(string name, double caloriesPerMinute)
        {
            // TODO: checker

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        /// <summary>
        /// Название вида активности.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Калории, сжигаемые за минуту.
        /// </summary>
        public double CaloriesPerMinute { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
