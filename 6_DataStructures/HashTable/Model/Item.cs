using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class Item<T>
    {
        public Item(int key)
        {
            Key = key;
            Node = new List<T>();
        }

        public int Key { get; private set; }
        public List<T> Node { get; set; }
    }
}
