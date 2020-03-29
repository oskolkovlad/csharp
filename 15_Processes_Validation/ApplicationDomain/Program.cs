using System;
using System.Reflection;

namespace ApplicationDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            // При запуске приложения, написанного на C#, операционная система создает процесс,
            // а среда CLR создает внутри этого процесса логический контейнер, который называется
            // доменом приложения и внутри которого работает запущенное приложение.

            // Для управления домена платформа .NET предоставляет класс AppDomain.

            AppDomain appDomain = AppDomain.CurrentDomain;
            Console.WriteLine(appDomain.Id);
            Console.WriteLine(appDomain.FriendlyName);
            Console.WriteLine(appDomain.BaseDirectory);
            Console.WriteLine();

            foreach (Assembly assem in appDomain.GetAssemblies())
            {
                Console.WriteLine(assem.GetName().Name);
            }


            Console.ReadKey();
        }
    }
}
