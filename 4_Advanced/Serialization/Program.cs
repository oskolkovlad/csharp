using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<Group>();
            for (var i = 0; i < 10; i++)
            {
                groups.Add(new Group(i, "Группа " + i));
            }

            var students = new List<Student>();
            for (var i = 0; i < 300; i++)
            {
                students.Add(new Student(Guid.NewGuid().ToString().Substring(0, 6), (new Random().Next(18, 25)))
                {
                    Group = groups[i % 9]
                });
            }


            //*****************************************************************************************************//


            // Бинарная сериализация
            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("./groups.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, groups);
            }

            // Десериализация
            using (var file = new FileStream("./groups.bin", FileMode.OpenOrCreate))
            {
                var newGroups = binFormatter.Deserialize(file) as List<Group>;
                if(newGroups != null)
                {
                    foreach(var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.WriteLine();


            //*****************************************************************************************************//


            // SOAP - сериализация
            var soapFormatter = new SoapFormatter();
            using (var file = new FileStream("./groups.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(file, groups);
            }

            // Десериализация
            using (var file = new FileStream("./groups.soap", FileMode.OpenOrCreate))
            {
                var newGroups = soapFormatter.Deserialize(file) as List<Group>;
                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
            

            Console.WriteLine();


            //*****************************************************************************************************//


            // XML - сериализация (НЕ СЕРИАЛИЗУЕТ PRIVATE ПОЛЯ!!!)
            var xmlFormatter = new XmlSerializer(typeof(List<Group>));
            using (var file = new FileStream("./groups.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, groups);
            }

            // Десериализация
            using (var file = new FileStream("./groups.xml", FileMode.OpenOrCreate))
            {
                var newGroups = xmlFormatter.Deserialize(file) as List<Group>;
                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.WriteLine();


            //*****************************************************************************************************//


            // JSON - сериализация
            var jsonFotmatter = new DataContractJsonSerializer(typeof(List<Student>));
            using (var file = new FileStream("./groups.json", FileMode.Create))
            {
                jsonFotmatter.WriteObject(file, students);
            }

            // Десериализация
            using (var file = new FileStream("./groups.json", FileMode.OpenOrCreate))
            {
                var newStudents = jsonFotmatter.ReadObject(file) as List<Student>;
                if (newStudents != null)
                {
                    foreach (var student in newStudents)
                    {
                        Console.WriteLine(student);
                    }
                }
            }


            //*****************************************************************************************************//


            Console.ReadKey();
        }
    }
}
