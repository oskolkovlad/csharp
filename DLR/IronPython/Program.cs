using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace IronPython
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.Execute("print 'hello, world...'");
            engine.ExecuteFile("hello.py");
            
            ScriptScope scope = engine.CreateScope();
            
            
            Console.ReadKey();
        }
    }
}