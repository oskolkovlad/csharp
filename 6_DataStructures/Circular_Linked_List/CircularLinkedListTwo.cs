using System;
using System.Collections.Generic;
using System.Text;

namespace Circular_Linked_List
{
    class CircularLinkedListTwo<T>
    {
        public CircularLinkedListTwo()
        {
            Clear();
        }

        ItemTwo<T> head;
        ItemTwo<T> tail;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(T data)
        {

        }

        public void AddFirst(T data)
        {

        }

       /* public bool Remove(T data)
        {

        }

        public bool Contains(T data)
        {

        }*/

        public void Clear()
        {
            head = null;
            tail = null;
            Count = default;
        }

        public override string ToString()
        {
            return $"В двухсвязном кольцевом списке кол-во элементов равно {Count}";
        }


    }
}
