using System;

namespace TypeObject
{
    class Point
    {
        public int X { get; set; }
        public MyClass my { get; set; }


        // Переопределяем метод, чтобы он сравнивал по значению
        // Этот метод не должен выкидывать ошибку
        /*public override bool Equals(object obj)
        {
            if(obj == null) return false;

            if(obj is Point point)
            {
                return X == point.X;
            }
            else
            {
                return false;
            }
        }*/

        // Удобный вывод объекта
        public override string ToString()
        {
            return X.ToString();
        }

        public override int GetHashCode()
        {
            return X;
        }

        // GetType() - нельзя переопределить, но можно скрыть через new
        public new Type GetType()
        {
            return base.GetType();
        }

        // Неглубокое клонирование
        public Point Clone()
        {
            return MemberwiseClone() as Point;
        }

        // Глубокое копирование
        public Point DeepClone()
        {
            var result = MemberwiseClone() as Point;
            result.my = new MyClass(my.Y);
            return result;
        }
    }

    class MyClass
    {
        public int Y { get; set; }
        public MyClass() { }

        public MyClass(int y)
        {
            Y = y;
        }
    }
}
