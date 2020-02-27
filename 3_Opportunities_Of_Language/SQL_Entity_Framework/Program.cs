using System;
using System.Collections.Generic;
using System.Linq;

namespace SQL_Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите имя музыкальной группы:");

            // Экземпляр БД, подключение
            using (var context = new MyDBContext()) {
                var group = new Group()
                {
                    Name = "Metallica",
                    Year = 1980
                };

                var group1 = new Group()
                {
                    Name = "Linkin Park"
                };

                // Добавляем в промежуточное БД хранилище
                context.Groups.Add(group);
                context.Groups.Add(group1);
                // Сохраняем в БД
                context.SaveChanges();

                var songs = new List<Song>
                {
                    new Song{Name = "In The End", GroupId = group1.Id },
                    new Song{Name = "Raise", GroupId = group.Id }
                };

                context.Songs.AddRange(songs);
                context.SaveChanges();

                // Включение миграций (выполнять при создании проекта): enable-migrations
                // Миграция: add-migration AddGroupType (имя миграции)
                // Обновление БД: update-database

                // Обновление данных - UPDATE
                //var s = context.Groups.Single(x => x.Id == group.Id);
                //s.Name = "jjklasf";
                //context.SaveChanges();


                Console.WriteLine($"id: {group.Id}; Name: {group.Name}; Year: {group.Year}");
                Console.WriteLine($"id: {group1.Id}; Name: {group1.Name}; Year: {group1.Year}\n");

                foreach(Song song in songs)
                {
                    Console.WriteLine($"Song name: {song.Name}; Group name: {song.Group?.Name}");
                }


                Console.ReadKey();
            }
        }
    }
}
