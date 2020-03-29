using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace DynamicLoad_and_Unload
{
    class Program
    {
        static void Main(string[] args)
        {
            // В .NET Framework можно было создавать вторичные домены и загружать в них различные сборки.
            // В .NET Core можно использовать только один домен. А для загрузки и выполнения сборок применяется класс
            // AssemblyLoadContext из пространства имен System.Runtime.Loader, который представляет контекст загрузки и выгрузки сборок.

            Console.Write("Введите число для вычисления факториала: ");
            LoadAssembly(int.Parse(Console.ReadLine()));

            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(ass.GetName().Name);
            }



            Console.ReadKey();
        }

        static void LoadAssembly(int number)
        {
            var context = new CustomAssemblyLoadContext();
            // установка обработчика выгрузки
            context.Unloading += Context_Unloading;
            // получаем путь к сборке MyApp
            var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "MyApp.dll");
            // загружаем сборку
            Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);
            // получаем тип Program из сборки MyApp.dll
            var type = assembly.GetType("MyApp.Program");
            // получаем его метод Factorial
            var greetMethod = type.GetMethod("Factorial");

            // вызываем метод
            var instance = Activator.CreateInstance(type);
            int result = (int)greetMethod.Invoke(instance, new object[] { number });
            // выводим результат метода на консоль
            Console.WriteLine($"Факториал числа {number} равен {result}");
            Console.WriteLine();

            // смотрим, какие сборки у нас загружены
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);
            Console.WriteLine();

            // выгружаем контекст
            context.Unload();
        }

        private static void Context_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine("Сборка выгружена...\n");
        }
    }

    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true) { }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }
    }
}
