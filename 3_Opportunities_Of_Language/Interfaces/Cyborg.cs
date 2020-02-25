using System;

namespace Interfaces
{
    class Cyborg : ICar, IPerson
    {
        int ICar.Speed { get; set; } = 100;
        int IPerson.Speed { get; set; } = 5;

        // Последовательное наследование
        public void Create()
        {
            throw new NotImplementedException();
        }

        void ICar.Beep()
        {
            throw new NotImplementedException();
        }

        void IObject.Create()
        {
            throw new NotImplementedException();
        }

        int IPerson.Move(int distance, int speed)
        {
            return distance / speed;
        }

        int ICar.Move(int distance, int speed)
        {
            return distance / speed;
        }
    }
}
