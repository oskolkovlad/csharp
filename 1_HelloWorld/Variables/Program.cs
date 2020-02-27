using System;


namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            int     integerType1    =   5;                  // -2147483648 ... 2147483647
            short   integerType12   =   32000;              // -32768 ... 32767
            long    integerType2    =   100000001;          // -9223372036854775808 ... 9223372036854775807
            byte    integerType3    =   128;                // 0 ... 255

            sbyte   integerType4    =   -100;               // -128 ... 127
            uint    integerType5    =   659;                // 0 ... 4294967295
            ushort  integerType51   =   60000;              // 0 ... 65535
            ulong   integerType6    =   15469577777;        // 0 ... 18446744073709551615

            double  realType1       =   25.348;             // -12.34, -1.1, 0, 1, 53.6123123
            decimal realType2       =   25.34M;             // -123.2M, -1, 0, 1.10M
            float   realType3       =   25.34F;             // -1.1F, 0, 1.001F

            bool    booleanType     =   true;               // true, false

            char    charType        =   'v';                // ‘a’, ‘b’, ‘1’, ‘+’, ‘\t’, ‘_’
            string  strType         =   "Just a string... Sun Moon Day Night."; // “hello”, “a”, “11”, “+++”, “”

            var     integerType_var =   255;
            dynamic str             =   "Dynamic type";

            // integerType_var = "scsc"; - error
            integerType_var = 35;

            //str.eveverve(); - error
            integerType_var = str.Length;

            Console.WriteLine($"Var: {integerType_var.GetType()}");
            Console.WriteLine(new string('-', 120));


            ///*****///


            realType1 = 10 / 4;
            Console.WriteLine($"Double (int):\t\t{realType1}");

            realType1 = 10.0 / 4.0;
            Console.WriteLine($"Double (double):\t{realType1}");

            realType1 = 10.0 % 4;
            Console.WriteLine($"Double (%):\t\t{realType1}");

            Console.WriteLine(new string('-', 120));


            ///*****///


            Console.Write("Int: {0}", integerType1);
            
            // Присвоение переменной значения
            integerType1 = 15; 
            Console.Write(new string(' ', 3));
            Console.Write("=: {0}", integerType1);
            
            Console.Write(new string(' ', 3));
            // В консоли будет значение 15, но после вывода значение станет равным 16
            // То есть сначала выполняется вывод переменной, а после инкрементация  (постфиксная форма)
            Console.Write("_++: {0}", integerType1++); 

            Console.Write(new string(' ', 3));
            // В консоли будет значение 17, так как используется уже инкрементированное значение переменной (префиксная форма)
            Console.Write("++_: {0}", ++integerType1);

            Console.Write(new string(' ', 3));
            // В консоли будет значение 17, так как используется уже инкрементированное значение переменной
            Console.Write("Type: {0}", integerType1.GetType());

            Console.Write(new string(' ', 3));
            // В консоли будет значение 17, так как используется уже инкрементированное значение переменной
            Console.Write("To String: {0}", integerType1.ToString());

            int a = 10;
            Console.Write(new string(' ', 3));
            // В консоли будет значение 17, так как используется уже инкрементированное значение переменной
            Console.Write("Equals: {0}", integerType1.Equals(a));

            Console.Write(new string(' ', 3));
            // В консоли будет значение 17, так как используется уже инкрементированное значение переменной
            Console.Write("Compare To: {0}", integerType1.CompareTo(a));

            a = 17;
            Console.Write(new string(' ', 3));
            // В консоли будет значение 17, так как используется уже инкрементированное значение переменной
            Console.WriteLine("Compare To: {0}", integerType1.CompareTo(a));

            Console.WriteLine(new string('-', 120));


            ///*****///

            Console.WriteLine("String: {0}", strType);

            // Длина строки
            Console.WriteLine("Length: " + strType.Length);

            // Подстрока
            Console.WriteLine("Substring: {0}", strType.Substring(5, strType.Length - 5));

            // Проверка на содержание подстроки
            Console.WriteLine("Contains: " + strType.Contains("Just"));

            strType += " ***";
            // Удаляет заданные вхождения набора знаков
            Console.WriteLine("Trim: {0}", strType.Trim('*', ' '));

            string[] splitStr = strType.Split(' ', '.');
            Console.Write("Split: ");
            // Разбивает строку на подстроки в зависимости от указанных символов
            foreach (string s in splitStr)
            {
                Console.Write(s);
                Console.Write(new string(' ', 5));
            }

            // Замена старого значения на новое
            Console.WriteLine($"\nReplace: {strType.Replace("Day", "PayDay")}"); // Используется интерполяция

            Console.WriteLine(new string('-', 120));


            ///*****///

            integerType1 = 2 & 5; // 010 & 101 (0*0 1*0 0*1 = 000)
            Console.WriteLine($"&: {integerType1}");

            integerType1 = 4 | 5; // 100 & 101 (1+1 0+0 0+1 = 101)
            Console.WriteLine($"|: {integerType1}");

            integerType1 = 45; // 0101101
            int key = 102;     // 1100110
            int encrypt = integerType1 ^ key; // 1001011 - 75
            Console.WriteLine($"encrypt (^): {encrypt}");
            Console.WriteLine($"decrypt (^): {encrypt ^ key}");

            Console.WriteLine($"~: {~10}");

            Console.WriteLine($">>: {16 >> 1}"); // 8

            Console.WriteLine($"<<: {4 << 1}");  // 8


            ///*****///


            string st = "1";
            //int i = st;                // error
            //int i = (int) st;          // error

            // Явное преобразование переменных
            int i = Convert.ToInt32(st); // no error
            i = int.Parse(st);           // no error

            // Неявное преобразование переменных
            string stt = "string " + i;



            // Неявное приведение
            byte bt = 45;
            int l = bt;

            int j = 5;
            double d = j;       // no error
            //int k = d;        // error

            // Кастинг - явное приведение
            int k = (int) d;    // no error


            ///*****///


            Console.ReadKey();
        }
    }
}
