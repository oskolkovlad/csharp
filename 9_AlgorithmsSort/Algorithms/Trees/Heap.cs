using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Trees
{
    public class Heap<T> : IEnumerable<T>
        where T : IComparable
    {
        private List<T> heap;

        public Heap()
        {
            heap = new List<T>();
        }

        public Heap(List<T> items)
        {
            heap = new List<T>();
            heap.AddRange(items);

            for (var i = 0; i < Count; i++)
            {
                Sort(i);
            }
        }


        public T Data { get; private set; }
        public int Count => heap.Count;
        public bool IsEmpty => Count == 0;


        public T PeekMaxNode()
        {
            if (!IsEmpty)
            {
                return heap[0];
            }

            return default;
        }

        public void Add(T data)
        {
            heap.Add(data);

            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && heap[parentIndex].CompareTo(heap[currentIndex]) == -1)
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        private int GetParentIndex(int currentIndex) => (currentIndex - 1) / 2;

        private void Swap(int currentIndex, int parentIndex)
        {
            var item = heap[currentIndex];
            heap[currentIndex] = heap[parentIndex];
            heap[parentIndex] = item;
        }


        public T PopMaxNode()
        {
            if (!IsEmpty)
            {
                var result = heap[0];
                heap[0] = heap[Count - 1];
                heap.RemoveAt(Count - 1);
                Sort(0);

                return result;
            }

            return default;
        }

        private void Sort(int currentIndex)
        {
            int maxIndex;
            int leftIndex;
            int rightIndex;

            while (currentIndex < Count)
            {
                IndexesForRootLeftRight(currentIndex, out maxIndex, out leftIndex, out rightIndex);

                if (leftIndex < Count && heap[leftIndex].CompareTo(heap[maxIndex]) == 1)
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < Count && heap[rightIndex].CompareTo(heap[maxIndex]) == 1)
                {
                    maxIndex = rightIndex;
                }

                if (maxIndex == currentIndex)
                {
                    break;
                }

                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }

        private void IndexesForRootLeftRight(int currentIndex, out int rootIndex, out int leftIndex, out int rightIndex)
        {
            rootIndex = currentIndex;
            leftIndex = currentIndex * 2 + 1;
            rightIndex = currentIndex * 2 + 2;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = new List<T>(heap);

            while (!IsEmpty)
            {
                yield return PopMaxNode();
            }

            heap = current;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
