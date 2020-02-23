using System;
using System.Collections.Generic;


namespace Array_List_Enum
{
    enum Fuel
    {
        A_76,
        A_92,
        A_95,
        Disel,
        Gas
    };

    class Program
    {
        static void Main(string[] args)
        {
            //*** Массив (Array) ***// - // Статический массив

            Console.WriteLine("Array:\n");

            int[] arrayOne = new int[5]; // Одномерный массив - вектор
            arrayOne[0] = 1;
            arrayOne[4] = 5;

            Console.WriteLine($"1: {arrayOne[0]};\t5: {arrayOne[4]}");

            int[] arrayTwo = { 1, 2, 3 };
            Console.WriteLine($"1: {arrayTwo[0]};\t2: {arrayTwo[0]};\t3: {arrayTwo[2]}");

            int[,] arrayTwice = new int[3, 3]; // Двухмерный массив - матрица, таблица

            arrayTwice[0, 0] = 1;
            Console.WriteLine($"arrayTwice[0, 0]: {arrayTwice[0, 0]}");

            int len = arrayTwo.Length;


            // Создаем массив массивов и записываем в него значения.
            string[][] masmas = new string[4][];
            masmas[0] = new string[] { "Item11", "Item12" };
            masmas[1] = new string[] { "Item21", "Item22", "Item23", "Item24" };
            masmas[2] = new string[] { "Item31", "Item32", "Item33" };
            masmas[3] = new string[] { "Item41", "Item42" };

            Console.WriteLine(new string('-', 50));


            //*****************************************************************************//


            //*** Список (List) ***// - // Динамический массив

            Console.WriteLine("List:\n");

            List<int> listOne = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            Console.WriteLine($"listOne:\t{listOne[0]},\t{listOne[1]},\t{listOne[2]},\t{listOne[3]},\t{listOne[4]}");


            List<int> listTwo = new List<int>();
            listTwo.Add(1);
            listTwo.Add(2);
            listTwo.Add(3);

            Console.WriteLine($"listTwo:\t{listTwo[0]},\t{listTwo[1]},\t{listTwo[2]}");

            Console.WriteLine($"Count of listTwo:\t{listTwo.Count}");

            Console.WriteLine(new string('-', 50));


            //*****************************************************************************//


            //*** Перечисления (Enum) ***//

            Console.WriteLine("Enum:\n");

            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\n", Fuel.A_76, Fuel.A_92, Fuel.A_95, Fuel.Disel, Fuel.Gas);


            //*****************************************************************************//

            int[] masSort = new int[7];
            int length = masSort.Length;
            int tmp = 0;

            for (int i = 0; i < length; i++)
            {
                masSort[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            foreach (int m in masSort)
            {
                Console.Write($"{m}\t");
            }
            Console.WriteLine();

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (masSort[i] > masSort[j])
                    {
                        tmp = masSort[i];
                        masSort[i] = masSort[j];
                        masSort[j] = tmp;
                    }
                }  
            }

            Console.WriteLine();
            foreach (int m in masSort)
            {
                Console.Write($"{m}\t");
            }
            Console.WriteLine(new string('-', 50));


            //*****************************************************************************//


            int[,,] mas = { { { 1, 2 },{ 3, 4 } },
                { { 4, 5 }, { 6, 7 } },
                { { 7, 8 }, { 9, 10 } },
                { { 10, 11 }, { 12, 13 } }
              };
            
            int ii = mas.GetUpperBound(0) + 1;
            int jj = mas.GetUpperBound(1) + 1;
            int kk = mas.GetUpperBound(2) + 1;

            Console.Write("{");
            for (int i = 0; i < ii; i++)
            {
                Console.Write("{");

                for (int j = 0; j < jj; j++)
                {
                    Console.Write("{");

                    for (int k = 0; k < kk; k++)
                    {
                        Console.Write("{0}", mas[i, j, k]);

                        if (k < kk - 1)
                        {
                            Console.Write(", ");
                        }
                    }

                    Console.Write("}");
                    
                    if (j < jj - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write("}");

                if (i < ii - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.Write("}");


            //*****************************************************************************//


            Console.ReadKey();
        }
    }
}
