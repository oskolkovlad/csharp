using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    class LinkedQueue<T> : IEnumerable<T>
    {

        Item<T> head;
        Item<T> tail;

        public LinkedQueue()
        {
            Clear();
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Enqueue(T data)
        {
            var item = new Item<T>(data);

            if (head is null)
            {
                head = item;
            }
            else
            {
                tail.Next = item;
            }

            tail = item;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            var item = head.Data;
            head = head.Next;
            Count--;

            return item;
        }

        public T PeekFirst
        {

            get
            {
                if (IsEmpty)
                {
                    throw new NullReferenceException("Очередь пуста!");
                }

                return head.Data;
            }
        }

        public T PeekLast
        {
            get
            {
                if (IsEmpty)
                {
                    throw new NullReferenceException("Очередь пуста!");
                }

                return tail.Data;
            }
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

        public override string ToString() => $"В очереди следующее количество элементов: {Count}";
    }
}
