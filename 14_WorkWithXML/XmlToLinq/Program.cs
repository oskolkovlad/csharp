using System;
using System.Linq;
using System.Xml.Linq;

namespace XmlToLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            /*XDocument xdoc = new XDocument();
            // создаем первый элемент
            XElement iphone6 = new XElement("phone");
            // создаем атрибут
            XAttribute iphoneNameAttr = new XAttribute("name", "iPhone 6");
            XElement iphoneCompanyElem = new XElement("company", "Apple");
            XElement iphonePriceElem = new XElement("price", "40000");
            // добавляем атрибут и элементы в первый элемент
            iphone6.Add(iphoneNameAttr);
            iphone6.Add(iphoneCompanyElem);
            iphone6.Add(iphonePriceElem);

            // создаем второй элемент
            XElement galaxys5 = new XElement("phone");
            XAttribute galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
            XElement galaxysCompanyElem = new XElement("company", "Samsung");
            XElement galaxysPriceElem = new XElement("price", "33000");
            galaxys5.Add(galaxysNameAttr);
            galaxys5.Add(galaxysCompanyElem);
            galaxys5.Add(galaxysPriceElem);
            // создаем корневой элемент
            XElement phones = new XElement("phones");
            // добавляем в корневой элемент
            phones.Add(iphone6);
            phones.Add(galaxys5);
            // добавляем корневой элемент в документ
            xdoc.Add(phones);
            //сохраняем документ
            xdoc.Save("phones.xml");*/

            // Создание XML документа с помощью LINQ to XML
            XDocument xdoc = new XDocument(new XElement("phones",
                new XElement("phone",
                    new XAttribute("name", "iPhone 6"),
                    new XElement("company", "Apple"),
                    new XElement("price", "40000")),
                new XElement("phone",
                    new XAttribute("name", "Galaxy S5"),
                    new XElement("company", "Samsung"),
                    new XElement("price", "33000"))
                ));

            //xdoc.Save("phones.xml");


            //************************************************************************//


            // Выборка элементов
            xdoc = XDocument.Load("phones.xml");

            foreach (XElement element in xdoc.Element("phones").Elements("phone"))
            {
                XAttribute name = element.Attribute("name");
                XElement company = element.Element("company");
                XElement price = element.Element("price");

                if(name != null && company != null && price != null)
                {
                    Console.WriteLine(name.Value);
                    Console.WriteLine(company.Value);
                    Console.WriteLine(price.Value);
                    Console.WriteLine();
                }
            }

            var items = from element in xdoc.Element("phones").Elements("phone")
                        where element.Element("company").Value == "Samsung"
                        select new Phone
                        {
                            Name = element.Attribute("name").Value,
                            Price = element.Element("price").Value
                        };

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Price}");
            Console.WriteLine();


            //************************************************************************//


            XElement root = xdoc.Element("phones");

            foreach (XElement xe in root.Elements("phone").ToList())
            {
                // изменяем название и цену
                if (xe.Attribute("name").Value == "Samsung Galaxy S5")
                {
                    xe.Attribute("name").Value = "Samsung Galaxy Note 4";
                    xe.Element("price").Value = "31000";
                }
                //если iphone - удаляем его
                else if (xe.Attribute("name").Value == "iPhone 6")
                {
                    xe.Remove();
                }
            }
            // добавляем новый элемент
            root.Add(new XElement("phone",
                        new XAttribute("name", "Nokia Lumia 930"),
                        new XElement("company", "Nokia"),
                        new XElement("price", "19500")));
            xdoc.Save("pnones1.xml");
            // выводим xml-документ на консоль
            Console.WriteLine(xdoc);


            //************************************************************************//


            Console.ReadKey();
        }

        class Phone
        {
            public string Name { get; set; }
            public string Price { get; set; }
        }
    }
}
