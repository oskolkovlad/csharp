using System;
using System.Xml;

namespace ModifyXMLFile
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"Q:\Projects\Learn\1_csharp\14_WorkWithXML\WorkWithXML\users.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlElement user = xDoc.CreateElement("user");
            XmlAttribute name = xDoc.CreateAttribute("name");
            XmlElement company = xDoc.CreateElement("company");
            XmlElement age = xDoc.CreateElement("age");

            XmlText nameText = xDoc.CreateTextNode("Tim");
            XmlText companyText = xDoc.CreateTextNode("Apple");
            XmlText ageText = xDoc.CreateTextNode("45");


            name.AppendChild(nameText);
            company.AppendChild(companyText);
            age.AppendChild(ageText);
            user.Attributes.Append(name);
            user.AppendChild(company);
            user.AppendChild(age);
            xRoot.AppendChild(user);
            xDoc.Save(@"Q:\Projects\Learn\1_csharp\14_WorkWithXML\WorkWithXML\users.xml");

            // Удаление узлов
            var node = xRoot.LastChild;
            xRoot.RemoveChild(node);
            xDoc.Save(@"Q:\Projects\Learn\1_csharp\14_WorkWithXML\WorkWithXML\users.xml");


            Console.ReadKey();
        }
    }
}
