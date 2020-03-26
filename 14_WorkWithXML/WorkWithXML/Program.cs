using System;
using System.Collections.Generic;
using System.Xml;

namespace WorkWithXML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();


            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"Q:\Projects\Learn\1_csharp\14_WorkWithXML\WorkWithXML\users.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach(XmlNode node in xRoot)
            {
                var user = new User();

                if (node.Attributes.Count != 0)
                {
                    XmlNode attribute = node.Attributes.GetNamedItem("name");
                    if(attribute != null)
                    {
                        Console.WriteLine(attribute.Value);
                        user.Name = attribute.Value;
                    }
                }

                foreach(XmlNode child in node.ChildNodes)
                {
                    if(child.Name == "company")
                    {
                        Console.WriteLine($"Компания: {child.InnerText}");
                        user.Company = child.InnerText;
                    }
                    if (child.Name == "age")
                    {
                        Console.WriteLine($"Возраст: {child.InnerText}");
                        user.Age = int.Parse(child.InnerText);
                    }
                }
                Console.WriteLine();

                users.Add(user);
            }

            foreach (var user in users)
            {
                Console.WriteLine($"Пользователь {user.Name} работает в компании {user.Company} в возрасте {user.Age} лет.");
            }


            Console.ReadKey();
        }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
