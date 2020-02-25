using System;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<ICar>()
            {
                new LadaSeven(),
                new BMWSeven()
            };

            foreach(var car in cars)
            {
                car.Beep();
                Console.WriteLine("Move: {0} h\n", car.Move(167, car.Speed));

                //((LadaSeven)car).Dispose();
            }

            Cyborg cyborg = new Cyborg();
            Console.WriteLine("Move like person: {0} h", ((IPerson)cyborg).Move(167, ((IPerson)cyborg).Speed));
            Console.WriteLine("Move like car: {0} h\n", ((ICar)cyborg).Move(167, ((ICar)cyborg).Speed));


            Console.ReadKey();
        }
    }
}
