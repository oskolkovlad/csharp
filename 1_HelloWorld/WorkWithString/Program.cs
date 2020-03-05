using System;
using System.Text;
using System.Text.RegularExpressions;

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


            #region StringBuilder


            // Кроме метода Append класс StringBuilder предлагает еще ряд методов для операций над строками:

            // - Insert: вставляет подстроку в объект StringBuilder, начиная с определенного индекса
            // - Remove: удаляет определенное количество символов, начиная с определенного индекса
            // - Replace: заменяет все вхождения определенного символа или подстроки на другой символ или подстроку
            // - AppendFormat: добавляет подстроку в конец объекта StringBuilder

            StringBuilder sb = new StringBuilder(20);
            sb.Append("hello world you oh");
            Console.WriteLine(sb);
            sb.Append(" my God!");
            Console.WriteLine(sb);
            sb.Insert(11, "!");
            Console.WriteLine(sb);
            sb.Replace("you", "yeah");
            Console.WriteLine(sb);
            sb.Remove(12, sb.Length - 12);
            Console.WriteLine(sb);

            Console.WriteLine(new string('-', 50));

            #endregion


            #region Регулярные выражения



            string reg1 = "шла саша по шоссе и сосала сушку саша вот такая саша молодец";

            // Параметр RegexOptions:

            // - Compiled: при установке этого значения регулярное выражение компилируется в сборку, что
            // обеспечивает более быстрое выполнение
            // - CultureInvariant: при установке этого значения будут игнорироваться региональные различия
            // - IgnoreCase: при установке этого значения будет игнорироваться регистр
            // - IgnorePatternWhitespace: удаляет из строки пробелы и разрешает комментарии, начинающиеся со знака #
            // - Multiline: указывает, что текст надо рассматривать в многострочном режиме.
            // При таком режиме символы "^" и "$" совпадают, соответственно, с началом и концом любой строки,
            // а не с началом и концом всего текста
            // - RightToLeft: приписывает читать строку справа налево
            // - Singleline: устанавливает однострочный режим, а весь текст рассматривается как одна строка

            Regex regex1 = new Regex(@"\w*са\w*", RegexOptions.IgnoreCase);
            MatchCollection matches1 = regex1.Matches(reg1);

            foreach(var m in matches1)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine(new string('-', 50));


            // Синтаксис регулярных выражений:

            //   ^: соответствие должно начинаться в начале строки(например, выражение @"^пр\w*" соответствует
            // слову "привет" в строке "привет мир")
            //  $: конец строки(например, выражение @"\w*ир$" соответствует слову "мир" в строке
            // "привет мир", так как часть "ир" находится в самом конце)
            //  .: знак точки определяет любой одиночный символ(например, выражение "м.р" соответствует слову "мир" или "мор")
            //  *: предыдущий символ повторяется 0 и более раз
            //  +: предыдущий символ повторяется 1 и более раз
            //  ?: предыдущий символ повторяется 0 или 1 раз
            //  \s: соответствует любому пробельному символу
            //  \S: соответствует любому символу, не являющемуся пробелом
            //  \w: соответствует любому алфавитно - цифровому символу
            //  \W: соответствует любому не алфавитно-цифровому символу
            //  \d: соответствует любой десятичной цифре
            //  \D: соответствует любому символу, не являющемуся десятичной цифрой


            string reg2 = "+7 (989) 143-23-34";
            string reg3 = "456-435-2318";

            var pattern1 = (@"\S[0-9]\s\([0-9]{3}\)\s[0-9]{3}-[0-9]{2}-[0-9]{2}");
            var pattern2 = (@"[0-9]{3}-[0-9]{3}-[0-9]{4}");
            
            if (Regex.IsMatch(reg3, pattern2, RegexOptions.IgnoreCase))
            {
                Console.WriteLine(reg3);
            }
            if (Regex.IsMatch(reg2, pattern1, RegexOptions.IgnoreCase))
            {
                Console.WriteLine(reg2);
            }

            Console.WriteLine(new string('-', 50));

            Regex regex3 = new Regex(@"\w*са\w*");
            var ress = regex3.Replace(reg1, "па");
            Console.WriteLine(ress);

            #endregion


            Console.ReadKey();
        }
    }
}
