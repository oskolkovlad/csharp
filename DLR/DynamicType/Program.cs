using System;

namespace DynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ключевым моментом использования DLR в C# является применение типов dynamic. Это ключевое слово позволяет опустить проверку
            // типов во время компиляции. Кроме того, объекты, объявленные как dynamic, могут в течение работы программы менять свой тип. 
            
            // Несмотря на то, что переменная x меняет тип своего значения несколько раз, данный код будет нормально работать. В этом использование
            // типов dynamic отличается от применения ключевого слова var. Для переменной, объявленной с помощью ключевого слова var,
            // тип выводится во время компиляции и затем во время выполнения больше не меняется.
            
            dynamic x;
            x = 23;
            x += 2;
            Console.WriteLine(x);
            
            x = "Hello, I am dynamic type...";
            Console.WriteLine(x);
            
            x = new Person()
            {
                Name = "Tom",
                Age = 25
            };
            Console.WriteLine(x);
            Console.WriteLine();
            
            dynamic person1 = new Person()
            {
                Name = "Tom",
                Age = 25
            };
            Console.WriteLine(person1);
            Console.WriteLine(person1.GetSalary(32, "int"));
            Console.WriteLine();
            
            dynamic person2 = new Person()
            {
                Name = "Alex",
                Age = 45
            };
            Console.WriteLine(person2);
            Console.WriteLine(person1.GetSalary("пятьдесят тычесяч триста один", "string"));
            
            
            Console.ReadKey();
        }
        
        class Person
        {
            public string Name {get;set;}
            public int Age { get; set; }

            public dynamic GetSalary(dynamic value, string format)
            {
                switch (format)
                {
                    case "int":
                        return value;
                        break;
                    case "string":
                        return "Зарплата = " + value + " рублей";
                        break;
                    default:
                        return 0.0;
                }
            }
 
            public override string ToString()
            {
                return Name + ", " + Age.ToString();
            }
        }
    }
}