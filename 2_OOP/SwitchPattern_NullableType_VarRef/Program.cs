using System;

namespace SwitchPattern_NullableType_VarRef
{
    class Program
    {
        static void Main(string[] args)
        {
            // SWITCH Pattern - Возвращение значения (return)
            Console.WriteLine(DoOperation((new Random()).Next(1, 3), 4, 6));


            Console.WriteLine();


            // SWITCH Pattern - Паттерн свойств
            Switch sw1 = new Switch() { Name = "Tom", Status = "User", Language = "English" };
            Switch sw2 = new Switch() { Name = "Dom", Status = "Admin", Language = "French" };
            Switch sw3 = new Switch() { Name = "Bob", Status = "User", Language = "German" };

            Console.WriteLine(DoHello(sw1));
            Console.WriteLine(DoHello(sw2));
            Console.WriteLine(DoHello(sw3));


            Console.WriteLine();


            // SWITCH Pattern - Паттерн кортежей
            Console.WriteLine(DoHelloTuple("english", "morning", "user"));
            Console.WriteLine(DoHelloTuple("german", "morning", "user"));
            Console.WriteLine(DoHelloTuple("french", "morning", "admin"));
            Console.WriteLine(DoHelloTuple("russian", "morning", "user"));


            Console.WriteLine();


            // SWITCH Pattern - Позиционный паттерн
            Console.WriteLine(DoHelloPosition(sw1));
            Console.WriteLine(DoHelloPosition(sw2));
            Console.WriteLine(DoHelloPosition(sw3));


            Console.WriteLine();


            //*****************************************************************************************************//


            // Nullable type

            int? i = 7;
            if(i.HasValue)
                Console.WriteLine(i.Value);
            else
                Console.WriteLine("i is equal to null");

            i = null;
            if (i.HasValue)
                Console.WriteLine(i.Value);
            else
                Console.WriteLine("i is equal to null");

            Console.WriteLine(i.GetValueOrDefault(10));


            int? a = 4;
            int? b = a;

            int? c = 4;
            int d = (int)c;

            long? e = 4;
            int? f = (int?)e;

            int? g = 4;
            long? h = g;

            int j = 4;
            int? k = j;


            Console.WriteLine();


            //*****************************************************************************************************//

            // ref variables

            // Для определения локальной переменной-ссылки (ref local) перед ее типом ставится ключевое слово ref.
            int x = 5;
            ref int xRef = ref x;
            xRef = 10;
            Console.WriteLine(x);
            int y = 15;
            xRef = ref y;
            xRef = 100;
            Console.WriteLine(x + " " + y);


            Console.WriteLine();


            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            ref int numberRef = ref Find(4, numbers); // ищем число 4 в массиве
            numberRef = 9; // заменяем 4 на 9
            Console.WriteLine(numbers[3]); // 9


            //*****************************************************************************************************//


            Console.ReadKey();
        }

        // SWITCH Pattern - Возвращение значения (return)
        // Данное упрощение касается лишь таких конструкций switch, которые возвращают значения с помощью оператора return.
        static int DoOperation(int op, int a, int b) => op switch
        {
            1 => a + b,
            2 => a - b,
            3 => a * b,
            _ => throw new ArgumentException("Недопустимый код операции!")
        };

        // SWITCH Pattern - Паттерн свойств
        static string DoHello(Switch sw) => sw switch
        {
            { Language: "English" } => "Hello!",
            { Language: "French", Status: "Admin", Name: var name } => $"Hallo, {name}!",
            { Language: "German" } => "Guten morgen!",
            null => "null...",
            { } => "WTF?!?!"
        };

        // SWITCH Pattern - Паттерн кортежей
        static string DoHelloTuple(string lang, string dayrime, string status) => (lang, dayrime, status) switch
        {
            ( "english", "morning", _ ) => "Good morning!",
            ( _, _, "admin" ) => "Hello, la admin!",
            ( "german", _, _ ) => "Guten morgen!",
            _ => "WTF?!?!"
        };

        // SWITCH Pattern - Позиционный паттерн
        static string DoHelloPosition(Switch sw) => sw switch
        {
            (_, _, "English") => "Good morning!",
            (var name, "Admin",_ ) => $"Hello, la admin {name}!",
            (_, _, "German") => "Guten morgen!",
            null => "null...",
            _ => "WTF?!?!"
        };


        // VarRef
        static ref int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; // возвращаем ссылку на адрес, а не само значение
                }
            }
            throw new IndexOutOfRangeException("число не найдено");
        }
    }
}
