using System;
using System.Diagnostics;

namespace Processes
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"{process.Id} | {process.ProcessName}");
            }
            Console.WriteLine();

            Process vs2019 = Process.GetProcessesByName("devenv")[0];
            Console.WriteLine($"{vs2019.Id} | {vs2019.ProcessName}");
            Console.WriteLine();


            //*******************************************************************************************//


            // Свойство Threads представляет коллекцию потоков процесса - объект ProcessThreadCollection,
            // каждый поток в которой является объектом ProcessThread.

            foreach (ProcessThread pthread in vs2019.Threads)
            {
                Console.WriteLine($"{pthread.Id} | {pthread.StartTime}");
            }
            Console.WriteLine();


            //*******************************************************************************************//


            // Одно приложение может использовать набор различных сторонних библиотек и модулей.
            // Для их получения класс Prosess имеет свойство Modules, которое представляет объект ProcessModuleCollection. 

            foreach (ProcessModule module in vs2019.Modules)
            {
                Console.WriteLine($"{module.ModuleName} | {module.ModuleMemorySize}");
            }


            //*******************************************************************************************//


            string progPath = @"C:\Program Files\Notepad++\notepad++.exe";
            string filePath = @"Q:\Projects\Learn\1_csharp\15_Processes_Validation\Processes\text.txt";
            //Process.Start(progPath, filePath);

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = progPath;
            processInfo.Arguments = filePath;
            Process.Start(processInfo);


            //*******************************************************************************************//


            Console.ReadKey();
        }
    }
}
