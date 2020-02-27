namespace SQL_Entity_Framework
{
    class Song
    {
        // Модель песни
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }

        // Отношение между таблицами
        public virtual Group Group { get; set; }
    }
}
