using System;
using System.IO;

namespace _DriveInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var drive in DriveInfo.GetDrives())
            {
                Console.WriteLine("Название диска: " + drive.Name);
                Console.WriteLine("Тип диска: " + drive.DriveType);

                if (drive.IsReady)
                {
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel ?? "Метка отсутствует"}");
                    Console.WriteLine("Общий объем диска: " + (drive.TotalSize / Math.Pow(1024, 3)).ToString("f2"));
                    Console.WriteLine("Объем свободного пространства: " + (drive.TotalFreeSpace / Math.Pow(1024, 3)).ToString("f2"));
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
