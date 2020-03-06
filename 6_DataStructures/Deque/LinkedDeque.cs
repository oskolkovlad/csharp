using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Deque
{
    class LinkedDeque<T> : IEnumerable<T>
    {
        Item<T> head;
        Item<T> tail;

        public LinkedDeque()
        {
            Clear();
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void AddFirst(T data)
        {
            Item<T> item = new Item<T>(data);

            if (head is null)
            {
                tail = item;
            }
            else
            {
                item.Next = head;
                head.Previous = item;
            }

            head = item;
            Count++;
        }

        public void AddLast(T data)
        {
            Item<T> item = new Item<T>(data);

            if (tail is null)
            {
                head = item;
            }
            else
            {
                tail.Next = item;
                item.Previous = tail;
            }

            tail = item;
            Count++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            var item = head.Data;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

            Count--;
            return item;
        }

        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            var item = tail.Data;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            Count--;
            return item;
        }

        public T First()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            return head.Data;
        }

        public T Last()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            return tail.Data;
        }

        public bool Contains(T data)
        {
            var current = head;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = default;
        }

        public override string ToString() => $"В Deque следующее количество элементов: {Count}";

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}
