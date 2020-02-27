using System.Data.Entity;

namespace SQL_Entity_Framework
{
    // Класса подключения и работы с Entity Framework

    // Модели:
    // - DB First;
    // - Code First;
    // - Model First.
    class MyDBContext :DbContext
    {
        // Подключение к БД с помощью строки подключения
        // Строка подключения задается и формируется в файле App.config <connectionStrings>
        public MyDBContext()
            : base("DBConnectionString") { }

        // Указываем наборы таблиц БД
        public DbSet<Group> Groups { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
