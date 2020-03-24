using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialize_BinaryFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "binary.dat";
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Person person = new Person("Tom", 23);

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, person);
                Console.WriteLine("Serialized object person...");
            }

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var p = binaryFormatter.Deserialize(fs) as Person;
                Console.WriteLine("Deserialized object person...");
                Console.WriteLine($"{p.Name} | {p.Age} | {p.isPerson}");
            }


            Console.ReadKey();
        }
    }

    // При наследовании подобного класса, следует учитывать, что атрибут Serializable автоматически не наследуется.
    // И если мы хотим, чтобы производный класс также мог бы быть сериализован, то опять же мы применяем к нему атрибут.

    [Serializable]
    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        // Если мы не хотим, чтобы какое-то поле класса сериализовалось, то мы его помечаем атрибутом NonSerialized.
        [NonSerialized]
        public bool isPerson = true;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
