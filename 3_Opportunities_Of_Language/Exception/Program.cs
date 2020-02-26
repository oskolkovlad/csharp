using System;

// С точки зрения производительности использование блоков try..catch более накладно, чем применение условных конструкций.
// Поэтому по возможности вместо try..catch лучше использовать условные конструкции на проверку исключительных ситуаций.

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 5;
            int b = 2000000000;
            int c = 2000000000;


            // Проверка на тип введенного числа (целое или нет)
            Console.WriteLine("Введите целое число:");
            while (true)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    Console.WriteLine("FINE! Введенное число: {0}\n", result);
                    break;
                }
                else
                {
                    Console.WriteLine("FAIL!!! Введите целое число...");
                }
            }

            // В данной блок помещаем код, в котором необходимо отлавливать ошибки
            try
            {
                // Свое исключение
                throw new MyException();


                var ex1 = a / 0; // System.DivideByZeroException: "Attempted to divide by zero."
                Console.WriteLine($"Divide By Zero Exception:\t{ex1}");


                // Если исключение не отлавливается, необходимо поместить в "checked()".
                // Ключевое слово "checked" используется для явного включения проверки переполнения
                // при выполнении арифметических операций и преобразований с данными целого типа.
                int ex2 = checked(b * c);
                Console.WriteLine($"Arithmetic operation overflow:\t{ex2}"); // Arithmetic operation resulted in an overflow.


                // Выбрасывания исключения самостоятельно с помощью "throw"
                throw new DivideByZeroException("Выброс исключения деления на ноль...");
            }
            // Свое исключение
            catch (MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Обработка конкретного исключения "DivideByZeroException" | фильтр исключений с помощью "when " 
            catch (DivideByZeroException ex) when (a == 5)
            {
                Console.WriteLine(ex.Message + "| a = 5");
            }
            // Обработка конкретного исключения "DivideByZeroException"
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Обработка остальных исключительных ситуаций
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Данный блок выполняется в любом случае
            finally
            {
                Console.WriteLine("Отлавливаем исключения с помощью конструкции \"try-catch\"");
            }


            //*****************************************************************************************//


            Console.ReadKey();
        }
    }
}
