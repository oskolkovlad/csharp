using System.Collections.Generic;

namespace SQL_Entity_Framework
{
    class Group
    {
        // Модель для группы
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }

        // Отношение между таблицами
        public virtual ICollection<Song> Songs { get; set; }
    }
}
