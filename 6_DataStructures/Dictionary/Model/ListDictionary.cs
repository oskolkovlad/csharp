using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class ListDictionary<TKey, TValue> : IEnumerable
    {
        public ListDictionary()
        {
            map = new List<Item<TKey, TValue>>();
            keys = new List<TKey>();
        }

        private List<Item<TKey, TValue>> map;
        private List<TKey> keys;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(TKey key, TValue value)
        {
            if (!keys.Contains(key))
            {
                Item<TKey, TValue> item = new Item<TKey, TValue>(key, value);
                map.Add(item);
                keys.Add(key);

                Count++;
            }
        }

        public TValue Search(TKey key)
        {
            if (keys.Contains(key))
            {
                return map.Single(k => k.Key.Equals(key)).Vlaue;
            }

            return default;
        }

        public void Remove(TKey key)
        {
            if (keys.Contains(key))
            {
                map.Remove(map.Single(k => k.Key.Equals(key)));
                keys.Remove(key);

                Count--;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return map.GetEnumerator();
        }
    }
}
