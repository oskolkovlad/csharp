using System;

namespace Unsafe_Code
{
    //Метод, использующий указатели:
    //unsafe private static void PointerMethod()
    //{ }

    //Также с помощью unsafe можно объявлять структуры:
    //unsafe struct State
    //{ }

    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int* x;
                int y = 20;

                x = &y;
                Console.WriteLine(*x);

                y += 30;
                Console.WriteLine(*x);

                *x -= 45;
                Console.WriteLine($"{y} | {*x}");


                // Так как значение адреса - это целое число, а на 32-разрядных системах диапазон адресов 0 до 4 000 000 000,
                // то для получения адреса используется преобразование в тип uint, long или ulong. Соответственно на
                // 64-разрядных системах диапазон доступных адресов гораздо больше, поэтому в данном случае лучше использовать
                // ulong, чтобы избежать ошибки переполнения.

                // получим адрес переменной y
                ulong addr = (ulong)x;
                Console.WriteLine("Адрес переменной y: {0}", addr);


                int** z = &x;
                **z += 5;
                Console.WriteLine($"{*x} | {**z} | {y}");
            }
    
            Console.ReadKey();
        }
    }
}
