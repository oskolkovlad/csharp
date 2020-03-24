using System;
using System.IO;
using System.IO.Compression;

namespace GZipStream_DeflateStream_ZipFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "text1.txt";
            string compressedFile = "text1.gz";
            string targetFile = "text2.txt";

            Compress(sourceFile, compressedFile);
            Decompress(compressedFile, targetFile);


            //***************************************************************************//


            string pathFolder = @"Q:\Projects\Learn\1_csharp\13_WorkWithFilesDirectories\GZipStream_DeflateStream_ZipFile\ZipFile\";
            string targetPath = @"Q:\Projects\Learn\1_csharp\13_WorkWithFilesDirectories\GZipStream_DeflateStream_ZipFile\ZipFile.zip";
            string newPathFolder = @"Q:\Projects\Learn\1_csharp\13_WorkWithFilesDirectories\GZipStream_DeflateStream_ZipFile\";

            ZipFile.CreateFromDirectory(pathFolder, targetPath);
            Console.WriteLine($"Папка {pathFolder} архивирована в файл {targetPath}");

            ZipFile.ExtractToDirectory(targetPath, newPathFolder);
            Console.WriteLine($"Файл {targetPath} распакован в папку {newPathFolder}");


            //***************************************************************************//


            Console.ReadKey();
        }

        private static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (var sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (var targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (var gzip = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(gzip);
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                        sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

        private static void Decompress(string compressedFile, string targetFile)
        {
            using (var sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                using (var targetStream = File.Create(targetFile))
                {
                    using (var gzip = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }
    }
}
