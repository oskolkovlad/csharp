using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Circular_Linked_List
{
    class CircularLinkedListOne<T> : IEnumerable<T>
    {
        public CircularLinkedListOne()
        {
            Clear();
        }

        ItemOne<T> head;
        ItemOne<T> tail;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(T data)
        {
            ItemOne<T> item = new ItemOne<T>(data);

            if (head is null)
            {
                head = item;
                tail = item;
                tail.Next = head;
            }
            else
            {
                item.Next = head;
                tail.Next = item;
                tail = item;
            }

            Count++;
        }

        public void AddFirst(T data)
        {
            ItemOne<T> item = new ItemOne<T>(data);

            if (head is null)
            {
                head = item;
                tail = item;
                tail.Next = item;
            }
            else
            {
                item.Next = head;
                tail.Next = item;
                head = item;
            }

            Count++;
        }

        public bool Remove(T data)
        {
            ItemOne<T> current = head;
            ItemOne<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current == tail)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        if (Count == 1)
                        {
                            head = null;
                            tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = head;
                        }
                    }

                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            while (current != head);

            return false;
        }

        public bool Contains(T data)
        {
            ItemOne<T> current = head;

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
            tail = null;
            Count = default;
        }

        public override string ToString()
        {
            return $"В двухсвязном кольцевом списке кол-во элементов равно {Count}";
        }

        public IEnumerator<T> GetEnumerator()
        {
            ItemOne<T> current = head;

            do
            {
                yield return current.Data;
                current = current.Next;
            }
            while (current != head);
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}
