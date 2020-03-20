using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace DLR_Python
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запуск команд и файлов
            ScriptEngine engine = Python.CreateEngine();
            engine.Execute("print 'hello, world...'");
            engine.ExecuteFile(@"Q:\Projects\Learn\1_csharp\11_DLR\DLR_Python\hello.py");

            ScriptScope scope = engine.CreateScope();
            Console.WriteLine();


            //**********************************************************************************************************//


            // Передача и получение переменных с помощью Scope
            var yArg = 22;
            scope.SetVariable("y", yArg);
            engine.ExecuteFile(@"Q:\Projects\Learn\1_csharp\11_DLR\DLR_Python\script.py", scope);
            dynamic xArg = scope.GetVariable("x");
            dynamic zArg = scope.GetVariable("z");
            Console.WriteLine($"Сумма {xArg} и {yArg} равна {zArg}");
            Console.WriteLine();


            //**********************************************************************************************************//


            // Вызов функций из IronPython
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());

            ScriptEngine engineFunc = Python.CreateEngine();
            ScriptScope scopeFunc = engineFunc.CreateScope();

            engineFunc.ExecuteFile(@"Q:\Projects\Learn\1_csharp\11_DLR\DLR_Python\factorial.py", scopeFunc);
            dynamic function = scopeFunc.GetVariable("factorial");

            // вызываем функцию и получаем результат
            dynamic result = function(number);
            Console.WriteLine(result);


            //**********************************************************************************************************//


            Console.ReadKey();
        }
    }
}
