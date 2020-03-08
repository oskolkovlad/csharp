using System;
using System.Collections;
using System.Linq;

namespace Dictionary
{
    class DictionaryMap<TKey, TValue> : IEnumerable
    {
        private int size = 100;

        public DictionaryMap()
        {
            Map  = new Item<TKey, TValue>[size];
            Keys = new TKey[size];
        }

        private Item<TKey, TValue>[] Map;
        private TKey[] Keys;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(TKey key, TValue value)
        {
            var hash = GetHash(key);

            if (Keys.Contains(key))
                return;

            if (Map[hash] is null)
            {
                Map[hash]  = new Item<TKey, TValue>(key, value);
                Keys[hash] = key;
            }
            else
            {
                var flag = false;

                for (var i = hash + 1; i < size; i++)
                {
                    if (Map[i] is null)
                    {
                        Map[i] = new Item<TKey, TValue>(key, value);
                        Keys[i] = key;
                        flag = true;
                        break;
                     }

                    if (Map[i].Key.Equals(key))
                        return;
                }

                if (!flag)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (Map[i] is null)
                        {
                            Map[i] = new Item<TKey, TValue>(key, value);
                            Keys[i] = key;
                            flag = true;
                            break;
                        }

                        if (Map[i].Key.Equals(key))
                            return;
                    }
                }

                if (!flag)
                {
                    // Либо расширение массива
                    throw new Exception("Словарь заполнен!");
                }
            }

            Count++;
        }

        public void Remove(TKey key)
        {
            var hash = GetHash(key);

            if (Keys.Contains(key))
            {
                if (Map[hash] != null && Map[hash].Key.Equals(key))
                {
                    Map[hash] = null;
                }
                else
                {
                    for (var i = hash  + 1; i < size; i++)
                    {
                        if (Map[i].Key.Equals(key))
                        {
                            Map[i] = null;
                            return;
                        }
                    }

                    for (var i = 0; i < hash; i++)
                    {
                        if (Map[i].Key.Equals(key))
                        {
                            Map[i] = null;
                            return;
                        }
                    }
                }

                Count--;
            }
            //else
            //    throw new Exception("Элемента по данному ключу не найдено!");
        }

        public TValue Search(TKey key)
        {
            var hash = GetHash(key);

            if (Keys.Contains(key))
            {
                if (Map[hash].Key.Equals(key))
                {
                    return Map[hash].Vlaue;
                }
                else
                {
                    for (var i = hash + 1; i < size; i++)
                    {
                        if (Map[i].Key.Equals(key))
                        {
                            return Map[i].Vlaue;
                        }
                    }

                    for (var i = 0; i < hash; i++)
                    {
                        if (Map[i].Key.Equals(key))
                        {
                            return Map[i].Vlaue;
                        }
                    }

                }
            }

            return default; // throw new Exception("Элемента по данному ключу не найдено!");
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var m in Map)
            {
                if(m != null)
                {
                    yield return m;
                }
            }
        }
    }
}
