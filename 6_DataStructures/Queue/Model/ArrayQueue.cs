using System;
using System.Linq;

namespace Queue
{
    class ArrayQueue<T>
    {
        private T[] queue;

        private const int MAX_LENGTH = 5;

        public ArrayQueue(int length = MAX_LENGTH)
        {
            queue = new T[length];
        }

        public T Head => queue[Count > 0 ? Count - 1 : 0];
        public T Tail => queue[0];

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Enqueue(T data)
        {
            if (Count == queue.Length)
            {
                var result = new T[Count + 1];
                result[0] = data;

                for (var i = 1; i < Count + 1; i++)
                {
                    result[i] = queue[i - 1];
                }

                queue = result;
            }
            else
            {
                queue[queue.Length - 1 - Count] = data;
            }
            
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            var poped = queue[--Count];
            var result = new T[Count];

            for (var i = 0; i < Count; i++)
            {
                result[i] = queue[i];
            }

            queue = result;      
            return poped;
        }

        public T PeekFirst()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            return queue[^1];
        }

        public T PeekLast()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Очередь пуста!");
            }

            return queue[queue.Length - Count];
        }

        public bool Contains(T data)
        {
            foreach(var q in queue)
            {
                if(q.Equals(data))
                {
                    return true;
                }
            }

            // OR
            //queue.FirstOrDefault(q => q.Equals(data));

            return false;
        }

        public override string ToString() => $"В очереди следующее количество элементов: {Count}";
    }
}
