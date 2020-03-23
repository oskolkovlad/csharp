using System;

namespace Stackalloc_FixedPointer
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                Person person;
                person.Age = 23;
                person.Height = 178;
                Person* p = &person;

                // разыменовывание указателя
                (*p).Age = 55;
                Console.WriteLine(p->Age);
                p->Height = 140;
                Console.WriteLine((*p).Height);
                Console.WriteLine();


                //*******************************************************************************//


                // С помощью ключевого слова stackalloc можно выделить память под массив в стеке.
                // Смысл выделения памяти в стеке в повышении быстродействия кода.

                const int SIZE = 5;
                // выделяем память в стеке под семь объектов int
                int* factorial = stackalloc int[SIZE];
                int* pp = factorial;

                // присваиваем первой ячейке значение 1 и увеличиваем указатель на 1
                *(pp++) = 1;

                for (int i = 2; i <= SIZE; i++, pp++)
                {
                    // считаем факториал числа
                    *pp = pp[-1] * i;
                }

                for (int i = 1; i <= SIZE; i++)
                {
                    Console.WriteLine(factorial[i - 1]);
                }
                Console.WriteLine();


                //*******************************************************************************//


                // Однако кроме структур в C# есть еще и классы, которые в отличие от типов значений, помещают все
                // связанные значения в куче. И в работу данных классов может в любой момент вмешаться сборщик мусора,
                // периодически очищающий кучу. Чтобы фиксировать на все время работы указатели на объекты классов используется оператор fixed.

                Animal animal = new Animal() { age = 10 };
                fixed(int* a = &animal.age)
                {
                    if (*a != 20)
                        *a = 5;
                }
                // После завершения блока fixed закрепление с переменных снимается, и они могут быть подвержены сборке мусора.

                Console.WriteLine(animal.age);
            }

            unsafe
            {
                int[] nums = { 0, 1, 2, 3, 7, 88 };
                string str = "Привет мир";
                fixed (int* p = nums)
                {
                    int third = *(p + 2);     // получим третий элемент
                    Console.WriteLine(third); // 2
                }
                fixed (char* p = str)
                {
                    char forth = *(p + 3);    // получим четвертый элемент
                    Console.WriteLine(forth); // в
                }
            }


            Console.ReadKey();
        }
    }

    public struct Person
    {
        public int Age;
        public int Height;
    }

    public class Animal
    {
        public int age;
    }
}
