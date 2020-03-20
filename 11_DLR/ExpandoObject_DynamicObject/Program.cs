using System;
using System.Collections.Generic;

namespace ExpandoObject_DynamicObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // ExpandoObject
            dynamic expandoObject = new System.Dynamic.ExpandoObject();
            expandoObject.Name = "Tom";
            expandoObject.Age = 43;
            expandoObject.Languages = new List<string>()
            {
                "english", "russian"
            };
            Console.WriteLine($"{expandoObject.Name} - {expandoObject.Age}");
            foreach (var language in expandoObject.Languages)
            {
                Console.WriteLine(language);
            }

            expandoObject.IncAge = (Action<int>) (x => expandoObject.Age += x);

            expandoObject.IncAge(2);
            Console.WriteLine($"{expandoObject.Name} - {expandoObject.Age}");
            Console.WriteLine();
            
            
            //***********************************************************************************//
            
            
            // DynamicObject
            dynamic dynamicObject = new PersonObject();
            dynamicObject.Name = "Alex";
            dynamicObject.Age = 19;
            Func<int, int> Inc = delegate(int i) {
                dynamicObject.Age += i;
                return dynamicObject.Age;
            };
            dynamicObject.IncAge = Inc;
            
            Console.WriteLine($"{dynamicObject.Name} - {dynamicObject.Age}");
            dynamicObject.IncAge(6);
            Console.WriteLine($"{dynamicObject.Name} - {dynamicObject.Age}");


            //***********************************************************************************//

            
            Console.ReadKey();
        }
    }
}