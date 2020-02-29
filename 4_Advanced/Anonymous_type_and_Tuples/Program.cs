using System;

namespace Anonymous_type_and_Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Анонимные типы
            var product = new { Name = "Apple", Energy = 100};
            Console.WriteLine($" Anonymous type:\tName: {product.Name}; Energy: {product.Energy}");

            var eat = new Eat() { Name = "Meat" };

            var product1 = new
            {
                eat.Name,
                Energy = 200
            };
            Console.WriteLine($" Anonymous type:\tName: {product1.Name}; Energy: {product1.Energy}");


            Console.WriteLine(new string('-', 60));


            //**************************************************************************************************//


            // Кортежи

            // Просто Tuple только для чтения как и анонимные типы (ссылочный тип)
            Tuple<string, int> tuple1 = new Tuple<string, int>("Bob", 25);
            Console.WriteLine($"Tuple (readonly):\tItem1: {tuple1.Item1}; Item2: {tuple1.Item2}");
            
            
            // ValueTuple - значимый тип, можно и читать, и перезаписывать
            // в основном используется для возвращения из функций нескольких значений
            (string, int) tuple2 = ("Tom", 19);
            Console.WriteLine($"Tuple:\tItem1: {tuple2.Item1}; Item2: {tuple2.Item2}") ;
            var tuple3 = (name: "Mot", age: 23);
            Console.WriteLine($"Tuple:\tname: {tuple3.name}; age: {tuple3.age}");
            string name; int age;
            (name, age) = ("Alex", 54);
            Console.WriteLine($"Tuple:\tname: {name}; age: {age}");


            Console.WriteLine(new string('-', 60));


            //**************************************************************************************************//


            var result = GetData();
            Console.WriteLine($"Result:\tNumber: {result.Number}; Name: {result.Name}; Flag: {result.Flag}");



            //**************************************************************************************************//


            Console.ReadKey();
        }

        static (int Number, string Name, bool Flag) GetData()
        {
            var number = 7832; // метод получения данных
            var name = Guid.NewGuid().ToString();  // метод получения данных
            bool b = number > 500; // проверка условия

            return (number, name, b);
        }
    }
}
