using System;
using System.Collections.Generic;
using System.Linq;

namespace Queue
{
    class ListQueue<T>
    {
        private List<T> queue;

        public ListQueue()
        {
            queue = new List<T>();
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Enqueue(T data)
        {
            queue.Add(data);
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            var item = queue.First();
            queue.RemoveAt(0);
            Count--;

            return item;
        }

        public T PeekFirst()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            return queue.First();
        }

        public T PeekLast()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            return queue.Last();
        }

        public bool Contains(T data) => queue.Contains(data);


        public override string ToString() => $"В очереди следующее количество элементов: {Count}";
    }
}
