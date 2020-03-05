using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Circular_Linked_List
{
    class CircularLinkedListTwo<T> : IEnumerable<T>
    {
        public CircularLinkedListTwo()
        {
            Clear();
        }

        ItemTwo<T> head;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(T data)
        {
            ItemTwo<T> item = new ItemTwo<T>(data);

            if(head is null)
            {
                head = item;
                head.Next = head;
                head.Previous = head;

            }
            else
            {
                head.Previous.Next = item;
                item.Previous = head.Previous;
                item.Next = head;
                head.Previous = item;
            }

            Count++;
        }

        public bool Remove(T data)
        {
            ItemTwo<T> current = head;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (Count == 1)
                    {
                        head = null;
                    }
                    else
                    {
                        if (current == head)
                        {
                            head = head.Next;
                        }

                        current.Next.Previous = current.Previous;
                        current.Previous.Next = current.Next;
                    }

                    Count--;
                    return true;
                }

                current = current.Next;
            }
            while (current != head);

            return false;
        }

        public bool Contains(T data)
        {
            ItemTwo<T> current = head;

            do
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }
            while (current != head);

            return false;
        }

        public void Clear()
        {
            head = null;
            Count = default;
        }

        public override string ToString()
        {
            return $"В двухсвязном кольцевом списке кол-во элементов равно {Count}";
        }

        public IEnumerator<T> GetEnumerator()
        {
            ItemTwo<T> current = head;

            do
            {
                yield return current.Data;
                current = current.Next;
            }
            while (current != head);
        }

        public IEnumerable<T> BackGetEnumerator()
        {
            ItemTwo<T> current = head.Previous;

            do
            {
                yield return current.Data;
                current = current.Previous;
            }
            while (current != head.Previous);
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}
