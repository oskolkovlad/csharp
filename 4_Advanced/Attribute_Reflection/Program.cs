using System;
using System.Linq;

namespace Attribute_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Атрибуты - в основном используются для сериализации

            Photo photo = new Photo("Green_Field.png")
            {
                Path = @"C:\Green_Field.png"
            };

            // Получение атрибутов (применение для всего класса)
            var type = typeof(Photo);
            var attributes = type.GetCustomAttributes(false);
            foreach (var attr in attributes)
            {
                Console.WriteLine(attr);
            }


            Console.WriteLine(new string('-', 60));


            //***************************************************************************************************//

            // Применение для свойства класса
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(false);

                if (attrs.Any(attr => attr.GetType() == typeof(GeoAttribute)))
                {
                    Console.WriteLine(prop);
                }

  /*              foreach (var attr in attrs)
                {
                    Console.WriteLine(attr);
                }*/
            }


            Console.WriteLine(new string('-', 60));


            //***************************************************************************************************//




              

            //***************************************************************************************************//


            Console.ReadKey();
        }
    }
}
