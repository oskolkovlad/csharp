using System.Collections.Generic;

namespace HashTable
{
    class MiddleHashTable<TKey, TValue>
    {
        public MiddleHashTable(int size)
        {
            items = new List<TValue>[size];
        }

        private List<TValue>[] items;


        public void Add(TKey key, TValue value)
        {
            var k = GetHash(key);
            if (items[k] is null)
                items[k] = new List<TValue>() { value };
            else
                items[k].Add(value);

        }

        public bool Search(TKey key, TValue value)
        {
            var k = GetHash(key);
            return items[k]?.Contains(value) ?? false;
        }

        private int GetHash(TKey key)
        {
            return int.Parse(key.ToString().Substring(0, 1));
        }
    }
}
