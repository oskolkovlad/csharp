using System;
using System.IO;
using System.Threading.Tasks;

namespace WW_FileStream
{
    class Program
    {
        async static Task Main(string[] args)
        {
            // Класс FileStream представляет возможности по считыванию из файла и записи в файл.
            // Он позволяет работать как с текстовыми файлами, так и с бинарными.

            // Перечисление FileMode. Данное перечисление указывает на режим доступа к файлу и может принимать следующие значения:

            // - Append: если файл существует, то текст добавляется в конец файл. Если файла нет, то он создается.Файл открывается только для записи.
            // - Create: создается новый файл.Если такой файл уже существует, то он перезаписывается
            // - CreateNew: создается новый файл.Если такой файл уже существует, то он приложение выбрасывает ошибку
            // - Open: открывает файл. Если файл не существует, выбрасывается исключение
            // - OpenOrCreate: если файл существует, он открывается, если нет - создается новый
            // - Truncate: если файл существует, то он перезаписывается.Файл открывается только для записи.

            // Или можно с помощью File:
            //FileStream File.Open(string file, FileMode mode);
            //FileStream File.OpenRead(string file);
            //FileStream File.OpenWrite(string file);


            string path = ".";
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
            }

            string text = "Hello world";
            // запись в файл
            using (var fs = new FileStream($"{path}/text.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                var bytes = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                await fs.WriteAsync(bytes, 0, bytes.Length);
                Console.WriteLine("Текст записан в файл...");
            }

            // чтение из файла
            using (/*var fs = File.OpenRead($"{path}/text.txt")*/var fs = new FileStream($"{path}/text.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                var bytes = new byte[fs.Length];
                // считываем данные
                await fs.ReadAsync(bytes, 0, bytes.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(bytes);
                Console.WriteLine($"Текст из файла: {textFromFile}");


                // С помощью метода Seek() мы можем управлять положением курсора потока, начиная с которого производится считывание или запись в файл.
                // Этот метод принимает два параметра: offset (смещение) и позиция в файле. Позиция в файле описывается тремя значениями:
                // - SeekOrigin.Begin: начало файла
                // - SeekOrigin.End: конец файла
                // - SeekOrigin.Current: текущая позиция в файле

                string replacedText = "house";
                fs.Seek(-5, SeekOrigin.End);
                byte[] newArray = System.Text.Encoding.Default.GetBytes(replacedText);
                await fs.WriteAsync(newArray, 0, newArray.Length);
                Console.WriteLine("Текст записан в файл...");


                fs.Seek(0, SeekOrigin.Begin);
                // преобразуем строку в байты
                var newBytes = new byte[fs.Length];
                // считываем данные
                await fs.ReadAsync(newBytes, 0, newBytes.Length);
                // декодируем байты в строку
                string newTextFromFile = System.Text.Encoding.Default.GetString(newBytes);
                Console.WriteLine($"Текст из файла: {newTextFromFile}");
            }


            Console.ReadKey();
        }
    }
}
