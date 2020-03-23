using System;
using System.IO;

namespace Directory_DirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получение списка файлов и подкаталогов
            string dirName = "C:\\";

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }


            // Создание каталога
            string path = @"C:\SomeDir";
            string subpath = @"program\avalon";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);


            // Получение информации о каталоге
            string dirName1 = "C:\\Program Files";

            DirectoryInfo dirInfo1 = new DirectoryInfo(dirName1);

            Console.WriteLine($"Название каталога: {dirInfo1.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo1.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo1.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo1.Root}");


            // Удаление каталога
            // Если мы просто применим метод Delete к непустой папке, в которой есть какие-нибудь файлы или подкаталоги,
            // то приложение нам выбросит ошибку.Поэтому нам надо передать в метод Delete дополнительный параметр булевого типа,
            // который укажет, что папку надо удалять со всем содержимым.
            string dirName2 = @"C:\SomeFolder";

            try
            {
                DirectoryInfo dirInfo2 = new DirectoryInfo(dirName2);
                dirInfo2.Delete(true);
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // ИЛИ

            /*string dirName2 = @"C:\SomeFolder";

            Directory.Delete(dirName2, true);*/


            // Перемещение каталога
            string oldPath = @"C:\SomeFolder";
            string newPath = @"C:\SomeDir";
            DirectoryInfo dirInfo3 = new DirectoryInfo(oldPath);
            if (dirInfo3.Exists && Directory.Exists(newPath) == false)
            {
                dirInfo3.MoveTo(newPath);
            }



            Console.ReadKey();
        }
    }
}
