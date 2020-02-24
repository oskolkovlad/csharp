using System;

namespace Operator_Overload
{
    public class Apple : Product
    {
        public Apple(string name, int calories, double volume) : base(name, calories, volume) { }

        public static Apple Add(Apple apple1, Apple apple2)
        {
            var calories = (int) Math.Round((apple1.Сalories + apple2.Сalories) / 2.0);
            var volume = apple1.Volume + apple2.Volume;

            Apple apple = new Apple("Яблоко", calories, volume);

            return apple;
        }

        public static Apple operator + (Apple apple1, Apple apple2)
        {
            var calories = (int)Math.Round((apple1.Сalories + apple2.Сalories) / 2.0);
            var volume = apple1.Volume + apple2.Volume;

            Apple apple = new Apple("Яблоко", calories, volume);

            return apple;
        }

        public static bool operator == (Apple apple1, Apple apple2)
        {
            return apple1.Name.Equals(apple2.Name);
        }

        public static bool operator != (Apple apple1, Apple apple2)
        {
            return apple1.Name.Equals(apple2.Name);
        }
    }
}
