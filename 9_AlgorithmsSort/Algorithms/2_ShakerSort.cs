using System;

namespace Algorithms
{
    // Алгоритм

    // Производится многократный прогон по массиву, соседние элементы сравниваются и, в случае необходимости,
    // меняются местами.При достижении конца массива направление меняется на противоположное.
    // Таким образом по очереди выталкиваются крупные и мелкие элементы массива в конец и начало структуры соответственно.
    // Коктейльная сортировка ещё называется двухсторонней сортировкой простыми обменами.

    // Сложность по времени:
    // - Худшая	 O(n * n)
    // - Средняя O(n * n)
    // - Лучшая  O(n)

    // Сложность по памяти
    // - Общая          O(n)
    // - Дополнительная O(1)

    public class ShakerSort<T> : Base<T>
        where T : IComparable
    {
        protected override void MakeSort()
        {
            var left = 0;
            var right = Items.Count - 1;

            do
            {
                IsSwapped = false;

                BubblePart(left, right, true);
                right--;

                if (!IsSwapped)
                    break;
                IsSwapped = false;

                BubblePart(left, right, false);
                left++;
            }
            while (IsSwapped);
        }

        public void BubblePart(int left, int right, bool direction)
        {
            if (direction)
            {
                for (var i = left; i < right; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                    }
                    CompareCount++;
                }
            }
            else
            {
                for (var i = right; i > left; i--)
                {
                    if (Items[i].CompareTo(Items[i - 1]) == -1)
                    {
                        Swap(i, i - 1);
                    }
                    CompareCount++;
                }
            }
        }
    }
}
