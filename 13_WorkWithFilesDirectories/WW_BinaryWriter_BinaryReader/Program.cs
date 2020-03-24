using System;
using System.IO;

namespace WW_BinaryWriter_BinaryReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Tom", 23, true);
            Person person2 = new Person("Alex", 3, false);
            var persons = new Person[] { person1, person2 };

            string path = "./text.dat";

            try
            {
                using (var bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (var p in persons)
                    {
                        bw.Write(p.Name);
                        bw.Write(p.Age);
                        bw.Write(p.IsPerson);
                    }
                }

                using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        var name = br.ReadString();
                        var age = br.ReadInt32();
                        var isPerson = br.ReadBoolean();

                        var person = new Person(name, age, isPerson);
                        Console.WriteLine($"{person.Name} | {person.Age} | {person.IsPerson}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }

    public struct Person
    {
        public string Name;
        public int Age;
        public bool IsPerson;

        public Person(string name, int age, bool isPerson)
        {
            Name = name;
            Age = age;
            IsPerson = isPerson;
        }
    }
}
