using System;

namespace Span_IndexRange
{
    class Program
    {
        static void Main(string[] args)
        {
            // Тип Span представляет непрерывную область памяти.
            // Цель данного типа - повысить производительность и эффективность использования памяти.
            // Span позволяет избежать дополнительных выделений памяти при операции с наборами данных.
            // Поскольку Span является структурой, то объект этого типа располагаетс в стеке, а не в хипе.

            string[] people = new string[] { "Tom", "John", "Michael", "Kaily", "Jerry" };
            Span<string> span = new Span<string>(people); // мы получаем доступ непосредственно к объекту и можем его изменять.


            // Как структура, определенная с модификатором ref, Span имеет ряд ограничений:
            // - она не может быть присвоена переменной типа Object, dynamic или переменной типа интерфейса.
            // - Она не может быть полем в объекте ссылочного типа (а только внутри ref-структур).
            // - Она не может использоваться в пределах операций await или yield.


            var boys = new string[3]; // выделяем память для первой декады
            var girls = new string[3]; // выделяем память для второй декады

            Array.Copy(people, 0, boys, 0, 3); // копируем данные в первый массив
            Array.Copy(people, 3, girls, 0, 2); // копируем данные во второй массив

            foreach (var boy in boys)
            {
                Console.WriteLine(boy);
            }
            Console.WriteLine();

            foreach (var g in girls)
            {
                Console.WriteLine(g);
            }
            Console.WriteLine();

            var boysSpan = span.Slice(0, 3); // нет выделения памяти под данные
            var girlsSpan = span.Slice(3, 2); // нет выделения памяти под данные

            foreach (var boy in boysSpan)
            {
                Console.WriteLine(boy);
            }
            Console.WriteLine();

            foreach (var g in girlsSpan)
            {
                Console.WriteLine(g);
            }
            Console.WriteLine();

            //Методы Span:
            // - void Fill(T value): заполняет все элементы Span значением value
            // - T[] ToArray(): преобразует Span в массив
            // - Span<T> Slice(int start, int length): выделяет из Span length элементов начиная с индекса start в виде другого Span
            // - void CopyTo(Span<T> destination): копирует элементы текущего Span в другой Span
            // - bool TryCopyTo(Span<T> destination): копирует элементы текущего Span в другой Span, но при этом также возвращает значение bool,
            // которое указывает, удачно ли прошла операция копирования


            // ReadOnlySpan

            string str = "Hello my perfect world!";
            var strSub = str.Substring(17, 5); // есть выделение памяти под символы
            ReadOnlySpan<char> roSpan = str.AsSpan(17, 5); // нет выделения памяти под символы

            Console.WriteLine(strSub);
            
            foreach(var c in roSpan)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));


            //****************************************************************************************************//

            Index a = 1;
            Index b = ^1;

            Range ab = a..b; // по a-го индекса включая по b-й индекс не включая

            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(array[0]);
            Console.WriteLine(array[b]);
            Console.WriteLine();
            Console.WriteLine(array[a]);
            Console.WriteLine(array[^2]);
            Console.WriteLine();
            Console.WriteLine(array[0..2]);
            Console.WriteLine(array[^2]);

            var arr1 = array[ab];
            var arr2 = array[0..^1];
            var arr3 = array[0..];
            var arr4 = array[..^1];
            var arr5 = array[^2..^1];
            var arr6 = array[ab];
            var arr7 = array[ab];

            Span<int> span1 = arr3;


            Console.ReadKey();
        }
    }
}
