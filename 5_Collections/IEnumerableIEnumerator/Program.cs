using System;
using System.Collections;

namespace IEnumerableIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            IEnumerator enumerator = numbers.GetEnumerator(); // получаем IEnumerator

            while (enumerator.MoveNext()) // пока не будет возвращено false
            {
                int num = (int)enumerator.Current; // берем элемент на текущей позиции
                Console.WriteLine(num);
            }
            enumerator.Reset(); // сбрасываем указатель в начало массива


            Console.WriteLine();


            Week week = new Week();
            foreach(var day in week)
            {
                Console.WriteLine(day);
            }



            Console.ReadKey();
        }
    }

    class Week //: IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                        "Friday", "Saturday", "Sunday" };

/*        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }*/

        public IEnumerator GetEnumerator()
        {
            return new WeekEnumerator(days);
        }
    }

    class WeekEnumerator : IEnumerator
    {
        public int position = -1;
        string[] days;

        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new InvalidOperationException();

                return days[position];
            }
        }

        public bool MoveNext()
        {
            if(position < days.Length - 1)
            {
                position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
