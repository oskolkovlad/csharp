using System;

namespace Interfaces
{
    class BMWSeven : ICar
    {
        public int Speed { get; set; } = 110;

        public void Beep()
        {
            Console.WriteLine("Бап, Бап...");
        }

        // Последовательное наследование
        public void Create()
        {
            throw new NotImplementedException();
        }

        public int Move(int distance, int speed)
        {
            return distance / speed;
        }
    }
}
