using System;

namespace HashTable
{
    class HashTable<T>
    {
        private Item<T>[] items;

        public HashTable(int size)
        {
            items = new Item<T>[size];
        }


        public void Add(T item)
        {
            var key = GetHash(item);

            if (items[key] is null)
            {
                items[key] = new Item<T>(key);
            }

            items[key].Node.Add(item);
        }

        public bool Search(T item)
        {
            var key = GetHash(item);
            return items[key]?.Node.Contains(item) ?? false;
        }

        private int GetHash(T item)
        {
            return Math.Abs(item.GetHashCode() % items.Length);
        }
    }
}
