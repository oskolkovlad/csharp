using System;
using System.IO;

namespace File_FileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получение информации о файле
            string path = @"C:\apache\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }


            // Удаление файла
            string path1 = @"C:\apache\hta.txt";
            FileInfo fileInf1 = new FileInfo(path1);
            if (fileInf1.Exists)
            {
                fileInf1.Delete();
                // альтернатива с помощью класса File
                // File.Delete(path1);
            }


            // Перемещение файла
            string path2 = @"C:\apache\hta.txt";
            string newPath2 = @"C:\SomeDir\hta.txt";
            FileInfo fileInf2 = new FileInfo(path2);
            if (fileInf2.Exists)
            {
                fileInf2.MoveTo(newPath2);
                // альтернатива с помощью класса File
                // File.Move(path2, newPath2);
            }


            // Копирование файла
            string path3 = @"C:\apache\hta.txt";
            string newPath3 = @"C:\SomeDir\hta.txt";
            FileInfo fileInf3 = new FileInfo(path);
            if (fileInf3.Exists)
            {
                fileInf3.CopyTo(newPath3, true);
                // альтернатива с помощью класса File
                // File.Copy(path3, newPath3, true);
            }



            Console.ReadKey();
        }
    }
}
