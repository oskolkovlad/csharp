using System.Collections.Generic;

namespace Algorithms
{
    public class Base<T>
    {
        protected Base()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        protected void Swap(int indexA, int indexB)
        {
            if(indexA >= 0 && indexA < Items.Count && indexB >= 0 && indexB < Items.Count)
            {
                var tempVar = Items[indexA];
                Items[indexA] = Items[indexB];
                Items[indexB] = tempVar;
            }
        }

        public virtual void Sort()
        {
            Items.Sort();
        }
    }
}
