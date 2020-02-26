using System;
using System.IO;
using System.Text;

namespace Stream_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //*** Работа с файлами ***//

            // Алгоритм:
            // - открыть файл
            // - прочитать/записать
            // - грамотно закрыть

            var encoding = Encoding.UTF8;

            // в аргументе путь файла для записи ; false - для отключения перезаписи; 3-й аргумент - кодировка
            using (var sw = new StreamWriter("./out.txt", false, encoding))
            {
                sw.Write("Ohoho... ");
                sw.WriteLine("This is stream writer to File!");

                sw.Close();
            }

            using (var sr = new StreamReader("./out.txt", encoding))
            {
                string line;

                //while(!sr.EndOfStream)
                //  Console.WriteLine(sr.ReadLine());
                while((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                // Для чтения еще раз
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, SeekOrigin.Begin);

                var fileText = sr.ReadToEnd();
                Console.WriteLine(fileText);

                sr.Close();
            }


            //****************************************************************************************************//


            Console.WriteLine(new string('-', 60));

            
            while (true)
            {
                Console.WriteLine("\nВведите номер действия для совершения:\n" +
                                  "\t1. Запись фамилии и имени;\n" +
                                  "\t2. Изменение фамилии и имени;\n" +
                                  "\t3. Фамилии и имени.\n" +
                                  "\t4. Выход.\n");

                if (int.TryParse(Console.ReadLine(), out int action))
                {
                    switch(action){
                        case 1:
                            using (var sw = new StreamWriter("./test.txt", false))
                            {
                                Console.WriteLine("Введите фамилию:");
                                var sName = Console.ReadLine();
                                Console.WriteLine("Введите имя:");
                                var name = Console.ReadLine();
                                sw.WriteLine(sName);
                                sw.WriteLine(name);

                                sw.Close();
                            }
                            break;
                        case 2:
                            goto case 1;
                        case 3:
                            using(StreamReader sr = new StreamReader("./test.txt"))
                            {
                                while (!sr.EndOfStream)
                                {
                                    Console.WriteLine(sr.ReadLine());
                                }

                                sr.Close();
                            }
                            break;
                        case 4:
                            return;
                    }
                }
            }
        }
    }
}
