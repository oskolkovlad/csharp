using System;

namespace Patrial_LocalMethod_PatternMatching_Deconstrucor
{
    class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Я работаю");
        }
    }

    class Manager : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Все еще работаю");
        }

        public bool IsVacation { get; set; }
    }
}
