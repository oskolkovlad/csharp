using System;

namespace WorkWithString
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Операции со строками

            // Инициализация
            string text = "Text";
            string text1 = new string(new char[] { 'T', 'e', 'x', 't' });
            string text2 = new string('a', 6);

            Console.WriteLine(text);
            Console.WriteLine(text1);
            Console.WriteLine(text2);

            Console.WriteLine();


            // Конкатенация строк
            string s1 = "Hello";
            string s2 = "World";
            Console.WriteLine(string.Concat(s1, s2));
            Console.WriteLine(s1 + " " + s2);

            Console.WriteLine();


            // Сравнение строк
            int res = string.Compare(s1, s2);
            if(res < 0)
            {
                Console.WriteLine("Выше первая строка");
            }
            else if(res > 0)
            {
                Console.WriteLine("Выше вторая строка");
            }
            else
                Console.WriteLine("Строки равны!");
            Console.WriteLine();


            // Поиск в строке
            Console.WriteLine(s1.IndexOf("el"));
            Console.WriteLine(s1.IndexOf("l"));
            Console.WriteLine(s1.LastIndexOf("l"));
            Console.WriteLine(s2.StartsWith("Wo"));
            Console.WriteLine(s2.EndsWith("dd"));
            Console.WriteLine();


            // Разделение строк
            string str = "Hello, my friend. How are you?";
            string[] strSplit = str.Split(new char[] { ' ', '.', ',', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var s in strSplit)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();


            // Обрезка строки
            string strSub = str.Substring(18, str.Length - 18);
            Console.WriteLine(strSub);
            string strTrim = str.Trim(' ', 'H', '?', 'u', 'o');
            Console.WriteLine(strTrim);

            Console.WriteLine();


            // Замена
            string strReplace = str.Replace("friend", "devel");
            Console.WriteLine(strReplace);
            Console.WriteLine();


            // Смена регистра
            Console.WriteLine(text.ToLower());
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();

            #endregion

            #region Интерполяция и форматирование строк

            // Форматирование строк

            // - C / c - Задает формат денежной единицы, указывает количество десятичных разрядов после запятой
            // - D / d - Целочисленный формат, указывает минимальное количество цифр
            // - E / e - Экспоненциальное представление числа, указывает количество десятичных разрядов после запятой
            // - F / f - Формат дробных чисел с фиксированной точкой, указывает количество десятичных разрядов после запятой
            // - G / g - Задает более короткий из двух форматов: F или E
            // - N / n - Также задает формат дробных чисел с фиксированной точкой, определяет количество разрядов после запятой
            // - P / p - Задает отображения знака процентов рядом с число, указывает количество десятичных разрядов после запятой
            // - X / x - Шестнадцатеричный формат числа

            // Валюта
            double num = 23.4;
            Console.WriteLine("{0:C}", num);
            Console.WriteLine("{0:C2}", num);
            Console.WriteLine();

            // Целые числа
            int num1 = 43;
            Console.WriteLine("{0:d}", num1);
            Console.WriteLine("{0:d2}", num1);
            Console.WriteLine("{0:d4}", num1);
            Console.WriteLine();

            // Дробные числа
            Console.WriteLine("{0:f}", num1);
            double num2 = 324.54;
            Console.WriteLine("{0:f}", num2);
            Console.WriteLine("{0:f2}", num2);
            Console.WriteLine("{0:f4}", num2);
            Console.WriteLine();

            // Проценты
            double num3 = 0.1243;
            Console.WriteLine("{0:p}", num3);
            Console.WriteLine("{0:p2}", num3);
            Console.WriteLine("{0:p3}", num3);
            Console.WriteLine("{0:p4}", num3);

            // Настраиваимые форматы
            long tel = 79873256495;
            Console.WriteLine("{0:+# (###) ###-##-##}", tel);
            Console.WriteLine();

            // Метод ToString
            Console.WriteLine(tel.ToString("+# (###) ###-##-##"));
            Console.WriteLine(num3.ToString("p3"));
            Console.WriteLine();



            // Интерполяция
            Console.WriteLine($"{tel:+# (###) ###-##-##}");
            Console.WriteLine($"{tel, -5}; telephone"); // должны добавляться 5 пробелов до переменной
            Console.WriteLine($"{tel, 5}; telephone");  // должны добавляться 5 пробелов после переменной
            Console.WriteLine();

            #endregion



            Console.ReadKey();
        }
    }
}
