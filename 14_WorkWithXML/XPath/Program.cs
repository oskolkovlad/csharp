using System;
using System.Xml;

namespace XPath
{
    class Program
    {
        // XPath представляет язык запросов в XML.Он позволяет выбирать элементы, соответствующие определенному селектору.

        // Рассмотрим некоторые наиболее распространенные селекторы:

        // . - выбор текущего узла
        // .. - выбор родительского узла
        // * - выбор всех дочерних узлов текущего узла
        // user - выбор всех узлов с определенным именем, в данном случае с именем "user"
        // @name - выбор атрибута текущего узла, после знака @ указывается название атрибута (в данном случае "name")
        // @+ - выбор всех атрибутов текущего узла
        // element[3] - выбор определенного дочернего узла по индексу, в данном случае третьего узла
        // //user - выбор в документе всех узлов с именем "user"
        // user[@name = 'Bill Gates'] - выбор элементов с определенным значением атрибута.
        // В данном случае выбираются все элементы "user" с атрибутом name='Bill Gates'
        // user[company = 'Microsoft'] - выбор элементов с определенным значением вложенного элемента.
        // В данном случае выбираются все элементы "user", у которых дочерний элемент "company" имеет значение 'Microsoft'
        // //user/company - выбор в документе всех узлов с именем "company", которые находятся в элементах "user"


        // Действие запросов XPath основано на применении двух методов класса XmlElement:

        // - SelectSingleNode() : выбор единственного узла из выборки.Если выборка по запрос
        // содержит несколько узлов, то выбирается первый
        // - SelectNodes(): выборка по запросу коллекции узлов в виде объекта XmlNodeList

        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"Q:\Projects\Learn\1_csharp\14_WorkWithXML\WorkWithXML\users.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNodeList nodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in nodes)
            {
                Console.WriteLine(n.OuterXml);
            }

            nodes = xRoot.SelectNodes("user");
            foreach (XmlNode n in nodes)
            {
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            }

            XmlNode node = xRoot.SelectSingleNode("user[@name='Bill Gates']");
            if (node != null)
            {
                Console.WriteLine(node.OuterXml);
            }
            
            node = xRoot.SelectSingleNode("user[company='Microsoft']");
            if (node != null)
            {
                Console.WriteLine(node.OuterXml);
            }

            nodes = xRoot.SelectNodes("//user/company");
            foreach (XmlNode n in nodes)
            {
                Console.WriteLine(n.InnerText);
            }


            Console.ReadKey();
        }
    }
}
