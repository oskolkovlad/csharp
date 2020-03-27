using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerialize
{
    // Во-первых, XmlSerializer предполагает некоторые ограничения.
    // Например, класс, подлежащий сериализации, должен иметь стандартный конструктор без параметров.
    // Также сериализации подлежат только открытые члены. Если в классе есть поля или свойства с модификатором private,
    // то при сериализации они будут игнорироваться.

    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Person person = new Person("Tom", 29);
            Console.WriteLine("Объект создан");

            // передаем в конструктор тип класса
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = File.Open("serXML.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, person);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = File.Open("serXML.xml", FileMode.Open))
            {
                Person newPerson = xmlSerializer.Deserialize(fs) as Person;

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name} | Возраст: {newPerson.Age}");
            }



            Console.ReadKey();
        }
    }

    // класс и его члены объявлены как public
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // стандартный конструктор без параметров
        public Person()
        { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
