using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Алгоритм
    // 1. Выбирается опорный элемент (например, посередине массива).
    // 2. Массив просматривается слева-направо и производится поиск ближайшего элемента, больший чем опорный.
    // 3. Массив просматривается справа-налево и производится поиск ближайшего элемента, меньший чем опорный.
    // 4. Найденные элементы меняются местами.
    // 5. Продолжается одновременный двухсторонний просмотр по массиву с последующими обменами в соответствии с пунктами 2-4.
    // 6. В конце концов, просмотры слева-напрво и справа-налево сходятся в одной точке, которая делит массив на два подмассива.
    // 7. К каждому из двух подмассивов рекурсивно применяется "Быстрая сортировка".

    // Сложность по времени:
    // - Худшая	 O(n)
    // - Средняя O(n * log n)
    // - Лучшая  O(n * n)

    // Сложность по доп. памяти
    // - Нативная O(n)
    // - Седжвик O(log n)

    public class QuickSort<T> : Base<T>
        where T : IComparable
    {
        public QuickSort() { }

        public QuickSort(IEnumerable<T> items)
            :base (items) { }


        protected override void MakeSort()
        {
            QSort(0, Items.Count - 1);
        }

        private void QSort(int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var pivot = LeftRightSort(left, right);
            QSort(left, pivot - 1);
            QSort(pivot + 1, right);
        }

        private int LeftRightSort(int left, int right)
        {
            var pointer = left;

            // Опорный элемент находится под right
            for (var i = left; i <= right; i++)
            {
                if (Compare(Items[i], Items[right]) == -1)
                {
                    Swap(pointer, i);
                    pointer++; 
                }
            }

            Swap(pointer, right);
            return pointer;
        }
    }
}
