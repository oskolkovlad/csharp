using System;

namespace UnsafeCode
{
    class Program
    {
        static void Main(string[] args)
        {


            #region Safe code

            int i = 10;
            int j = 15;
            ref int iRef = ref i; // Переменная-ссылка на другую переменную

            Console.WriteLine(i);
            Console.WriteLine(iRef);
            Console.WriteLine();

            iRef += 100;
            Console.WriteLine(i);
            Console.WriteLine(iRef);
            Console.WriteLine();

            iRef = ref j;
            Console.WriteLine(i);
            Console.WriteLine(iRef);
            Console.WriteLine();

            int a1 = 5;
            int a2 = 15;
            Calc(5, ref a2, true);
            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine();

            a1 = 5;
            a2 = 15;
            ref int a1Ref = ref a1;
            ref int a2Ref = ref a2;
            Calc(a1, ref a1Ref);
            Console.WriteLine(a1);
            Console.WriteLine(a1Ref);

            Console.WriteLine(new string('-', 50));

            #endregion



            //***********************************************************************************************//


            // Unsafe code

            unsafe
            {
                int num = 30;
                int* ptrNum = &num; // указатель // * - разыменование; & - адрес

                Console.WriteLine(num);
                Console.WriteLine(*ptrNum);


                Console.WriteLine();


                *ptrNum = 35;
                Console.WriteLine(num);
                Console.WriteLine(*ptrNum);

                Console.WriteLine();

                int a = 5; 
                int b = 7;

                Calc(a, &b);
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine();

                int* ptrNum1 = ptrNum + 4;
                *ptrNum1 = 444;
                Console.WriteLine(*ptrNum1);
                Console.WriteLine(*ptrNum);
                Console.WriteLine();


                // Указатель на указатель
                int** prtPtrNum = &ptrNum;
                Console.WriteLine((long)prtPtrNum);
                Console.WriteLine((long)*prtPtrNum);
                Console.WriteLine(**prtPtrNum);


            }
            

            //***********************************************************************************************//


            Console.ReadKey();
        }

        static unsafe void Calc(int num, int* ptrNum)
        {
            num = 500;
            *ptrNum = 700;
        }

        static void Calc(int num, ref int ptrNum, bool t)
        {
            num = 500;
            ptrNum = 700;
        }

        static ref int Calc(int num, ref int ptrNum)
        {
            num = 500;
            ptrNum = 700;

            return ref ptrNum;
        }
    }
}
