using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    public class Base<T>
        where T : IComparable
    {
        public event EventHandler<Tuple<T, T>> CompareEvent;
        public event EventHandler<Tuple<T, T>> SwapEvent;

        protected Base()
        {
            Items = new List<T>();
        }

        protected Base(IEnumerable<T> items)
            : this()
        {
            Items.AddRange(items);
        }

        public List<T> Items { get; set; }

        public int SwapCount { get; set; } = 0;
        public int CompareCount { get; set; } = 0;
        public bool IsSwapped { get; set; } = false;

        protected void Swap(int indexA, int indexB)
        {
            if(indexA >= 0 && indexA < Items.Count && indexB >= 0 && indexB < Items.Count)
            {
                var tempVar = Items[indexA];
                Items[indexA] = Items[indexB];
                Items[indexB] = tempVar;
            }

            SwapEvent?.Invoke(this, new Tuple<T, T>(Items[indexA], Items[indexB]));

            SwapCount++;
            IsSwapped = true;
        }

        public TimeSpan Sort()
        {
            Stopwatch timer = new Stopwatch();

            SwapCount = 0;
            CompareCount = 0;

            timer.Start();
            MakeSort();
            timer.Stop();

            return timer.Elapsed;
        }

        protected virtual void MakeSort()
        {
            Items.Sort();
        }

        protected int Compare(T a, T b)
        {
            CompareEvent?.Invoke(this, new Tuple<T, T>(a, b));
            CompareCount++;

            return a.CompareTo(b);
        }
    }
}
