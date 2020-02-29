using System;

namespace Interfaces
{
    class BMWSeven : ICar, ICloneable
    {
        public int Speed { get; set; } = 110;
        public ClassOfCar Class { get; set; }

        public void Beep()
        {
            Console.WriteLine("Бап, Бап...");
        }

        // Глубокое копирование
        public object Clone()
        {
            var _class = new ClassOfCar() { Name = this.Class.Name };
            return new BMWSeven() { Speed = this.Speed, Class = _class };
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

    class ClassOfCar
    {
        public string Name { get; set; }
    }
}
