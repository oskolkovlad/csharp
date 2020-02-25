using System;

namespace Interfaces
{
    class LadaSeven : ICar, IDisposable
    {
        public int Speed { get; set; } = 70;

        public void Beep()
        {
            Console.WriteLine("Бип, Бип!!!");
        }

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
