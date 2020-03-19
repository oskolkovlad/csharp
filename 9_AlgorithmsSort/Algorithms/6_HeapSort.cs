using System;
using System.Collections.Generic;

namespace Algorithms
{
    // Алгоритм

    // Основная идея - ищем максимальный элемент в неотсортированной части массива и ставим его в конец этого подмассива.
    // В поисках максимума подмассив перестраивается в так называемое сортирующее дерево (она же двоичная куча, она же пирамида),
    // в результате чего максимум сам "всплывает" в начало массива. После этого перемещаем максимум в конец подмассива.
    // Затем над оставшейся частью массива снова осуществляется процедура перестройки в сортирующее дерево с последующим
    // перемещением максимума в конец подмассива.

    // Сортирующее(неубывающее) дерево - дерево у которого любой родитель не меньше чем каждый из его потомков.
    // Если сортирующее дерево невозрастающее, то, соответственно, любой родитель не больше чем каждый из его потомков.

    // Сложность по времени:
    // - Худшая	 O(n * log n)
    // - Средняя O(n * log n)
    // - Лучшая  O(n * log n)

    // Сложность по памяти
    // - Общая O(n)
    // - Дополнительная O(1)

    public class HeapSort<T> : Base<T>
        where T : IComparable
    {
        public HeapSort() { }

        public HeapSort(IEnumerable<T> items)
            : base(items)
        {
            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }


        public int Count => Items.Count;
        public bool IsEmpty => Count == 0;


        public void Add(T item)
        {
            Items.Add(item);

            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && Compare(Items[parentIndex], Items[currentIndex]) == -1)
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        private int GetParentIndex(int currentIndex) => (currentIndex - 1) / 2;

        public T PeekMaxNode()
        {
            if (!IsEmpty)
            {
                return Items[0];
            }
            else
            {
                throw new ArgumentNullException("Куча пуста!");
            }
        }

        public T PopMaxNode()
        {
            var result = Items[0];
            Items[0] = Items[Count - 1];
            Items.RemoveAt(Count - 1);
            Sort(0);

            return result;
        }

        private void Sort(int currentIndex, int maxLength = -1)
        {
            maxLength = maxLength == -1 ? Count : maxLength;

            while (currentIndex < maxLength)
            {
                IndexesForRootLeftRight(currentIndex, out int maxIndex, out int leftIndex, out int rightIndex);

                if (leftIndex < maxLength && Compare(Items[leftIndex], Items[maxIndex]) == 1)
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < maxLength && Compare(Items[rightIndex], Items[maxIndex]) == 1)
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

        protected override void MakeSort()
        {
            for(int i = Count - 1; i >= 0; i--)
            {
                Swap(0, i);
                Sort(0, i);
            }
        }

        private void IndexesForRootLeftRight(int currentIndex, out int rootIndex, out int leftIndex, out int rightIndex)
        {
            rootIndex = currentIndex;
            leftIndex = currentIndex * 2 + 1;
            rightIndex = currentIndex * 2 + 2;
        }
    }
}
