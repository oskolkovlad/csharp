using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Indexer_Yield_IEnumerable
{
    class Parking : IEnumerable<Car>
    {
        List<Car> _cars = new List<Car>();
        const int MAX_CARS = 100;

        internal string Name { get; }

        public Parking(string name)
        {
            Name = name;
        }

        internal int Count => _cars.Count;

        internal int Add(Car car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car), "The example of class Car is Null!");

            if (_cars.Count < MAX_CARS)
            {
                _cars.Add(car);
                return _cars.IndexOf(car); // _cars.Count - 1;
            }
            else
                return -1;         
        }

        internal void GoOut(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number), "Number is Null or Empty!");
            }

            var car = _cars?.First(car => car.Number == number);
            _cars?.Remove(car);
        }

       /* public IEnumerator<int> GetNumbers(int max)
        {
            var current = 0;

            for(var i = 0; i < max; i++)
            {
                current += i;
                yield return current;
            }
        }*/

        public IEnumerable GetNameCars()
        {
            foreach(var car in _cars)
            {
                yield return car.Name;
            }
        }


        public IEnumerator<Car> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        // Индексатор: public тип this[тип индекс]{ get; set; }
        internal Car this[string number] => _cars?.First(car => car.Number == number);

        internal Car this[int position]
        {
            get
            {
                if (position < Count)
                {
                    return _cars[position];
                }
                return null;
            }
            set
            {
                if (position < Count)
                {
                    _cars[position] = value;
                }
            }
        }

        //public Car this[string number]
        //{
        //    get
        //    {
        //        Car car = null;

        //        foreach(var c in _cars)
        //        {
        //            if (c?.Number == number)
        //            {
        //                car = c;
        //                break;
        //            }
        //        }

        //        return car; ;
        //    }
        //}
    }

    class ParkingEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
