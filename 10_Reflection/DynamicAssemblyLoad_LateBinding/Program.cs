using System;
using System.Reflection;

namespace DynamicAssemblyLoad_LateBinding
{
    class Program
    {
        static void Main(string[] args)
        {

            // Чтобы динамически загрузить сборку в приложение, надо использовать статические методы Assembly.LoadFrom() или Assembly.Load().

            Assembly assembly = Assembly.LoadFrom(@"Q:\Projects\Learn\1_csharp\10_Reflection\Type_Class\bin\Debug\netcoreapp3.1\Type_Class.dll");
            var types = assembly.GetTypes();

            // Вывод классов сборки
            foreach(var type in types)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine();

            // Метод Load() действует аналогично, только в качестве его параметра передается дружественное имя сборки,
            // которое нередко совпадает с именем приложения: Assembly asm = Assembly.Load("MyApp");


            //*******************************************************************************************************************************************//


            // С помощью динамической загрузки мы можем реализовать технологию позднего связывания. Позднее связывание позволяет 
            // создавать экземпляры некоторого типа, а также использовать его во время выполнения приложения.

            // Использование позднего связывания менее безопасно в том плане, что при жестком кодировании всех типов (ранее связывание)
            // на этапе компиляции мы можем отследить многие ошибки. В то же время позднее связывание позволяет создавать расширяемые
            // приложения, когда дополнительный функционал программы неизвестен, и его могут разработать и подключить сторонние разработчики.
            try
            {
                Type typeClass = assembly.GetType("Type_Class.User", true, true);
                object user = Activator.CreateInstance(typeClass, "Tom", 23);

                MethodInfo method = typeClass.GetMethod("Payment");

                object result = method.Invoke(user, new object[] { 23, 32 });

                Console.WriteLine(result.ToString());
                Console.WriteLine();


                // Вызовем метод Main той сборки
                Type main = assembly.GetType("Type_Class.Program", true, true);
                object mainObject = Activator.CreateInstance(main);
                MethodInfo mainMethod = main.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Static);
                mainMethod.Invoke(mainObject, new object[] { new string[] { } });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            //*******************************************************************************************************************************************//


            Console.ReadKey();
        }
    }
}
