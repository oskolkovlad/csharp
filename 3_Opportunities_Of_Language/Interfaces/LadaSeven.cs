using System;

namespace Interfaces
{
    class LadaSeven : ICar, IDisposable, ICloneable
    {
        public int Speed { get; set; } = 70;

        public void Beep()
        {
            Console.WriteLine("Бип, Бип!!!");
        }

        // Поверхностное копирование (неглубокое)
        public object Clone() => new LadaSeven() { Speed = this.Speed };
        // Сокращенная форма поверхностного копирования
        //public object IClone() => this.MemberwiseClone();


        // Последовательное наследование
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException(); // ошибка о том, что метод не реализован
        }

        public int Move(int distance, int speed)
        {
            return distance / speed;
        }
    }
}
