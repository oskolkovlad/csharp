using System;
using System.IO;
using System.Threading.Tasks;

namespace WW_StreamWriter_StreamReader
{
    class Program
    {
        async static Task Main(string[] args)
        {
            string writePath = @"C:\SomeDir\hta2.txt";
            string text = "Привет мир!\nПока мир...";

            // Запись в файл
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync("Дозапись");
                    await sw.WriteAsync("4,5");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // Сначала считаем текст полностью из ранее записанного файла
            try
            {
                using (StreamReader sr = new StreamReader(writePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                // асинхронное чтение
                using (StreamReader sr = new StreamReader(writePath))
                {
                    Console.WriteLine(await sr.ReadToEndAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            // Считаем текст из файла построчно
            string path = @"C:\SomeDir\hta.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            // асинхронное чтение
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                }
            }


            Console.ReadKey();
        }
    }
}
