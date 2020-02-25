using System;
using System.Collections.Generic;
using System.Text;

namespace OperationCastOverload
{
    class Counter
    {
        public int Seconds { get; set; }


        // explicit (если преобразование явное, то есть нужна операция приведения типов) или implicit (если преобразование неявное)
        public static explicit operator int(Counter counter)
        {
            return counter.Seconds;
        }

        public static implicit operator Counter(int time)
        {
            return new Counter() { Seconds = time };
        }


        public static implicit operator Timer(Counter counter)
        {
            var hours = counter.Seconds / 3600;
            var min   = (counter.Seconds % 3600) / 60;
            var sec   = counter.Seconds % 60;
            // 3745 / 3600 = 1 h
            // (3745 % 3600) * 60 = 145 / 60 = 2 min
            // 3745 % 60 = 25 sec

            return new Timer() { Seconds = sec, Minutes = min, Hours = hours };
        }

        public static explicit operator Counter(Timer timer)
        {
            return new Counter() { Seconds = timer.Seconds + timer.Minutes * 60 + timer.Hours * 3600 };
        }
    }

    class Timer
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
    }
}
