using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    // Алгоритм

    // Разделение:     массив разбивается на два подмассива.
    // Упорядочивание: подмассивы сортируются (к ним рекурсивно применяется сортировка слиянием).
    // Слияние:        упорядоченные подмассивы объединяются в один отсортированный массив.

    // Сложность по времени:
    // - Худшая	 O(n * log n)
    // - Средняя O(n * log n)
    // - Лучшая  O(n * log n)

    // Сложность по памяти
    // - Общая O(n)
    // - Дополнительная O(n)

    public class MergeSort<T> : Base<T>
        where T : IComparable
    {
        public MergeSort() { }
        public MergeSort(IEnumerable<T> items)
            : base(items) { }


        protected override void MakeSort()
        {
            Items = Sort(Items);
            for (var i = 0; i < Items.Count; i++)
            {
                Set(i, Items[i]);
            }
        }

        private List<T> Sort(List<T> items)
        {
            if (items.Count == 1)
            {
                return items;
            }

            Split(items, out List<T> left, out List<T> right);
            return Merge(Sort(left), Sort(right));
        }

        private void Split(List<T> items, out List<T> left, out List<T> right)
        {
            var middleItems = items.Count / 2;

            left  = items.Take(middleItems).ToList();
            right = items.Skip(middleItems).ToList();
        }

        private List<T> Merge(List<T> left, List<T> right)
        {
            var result = new List<T>();

            var length = left.Count + right.Count;
            var leftPointer  = 0;
            var rightPointer = 0;

            for (var i = 0; i < length; i++)
            {
                if (leftPointer < left.Count && rightPointer < right.Count)
                {
                    if (Compare(left[leftPointer], right[rightPointer]) == -1)
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                    else
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                }
                else
                {
                    if (rightPointer < right.Count)
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                    else
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                }
            }

            return result;
        }
    }
}
