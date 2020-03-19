using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Алгоритм

    // Проходим массив и находим в нём максимальный элемент.Найденый максимум меняем местами с последним элементом. Затем проходим по неотсортированной
    // части массива(от первого элемента до предпоследнего) и находим в ней максимум, который затем меняем местами с предпоследним элементом массива.
    // Продолжаем действия, пока не отсортируем полностью.
    // Если кроме максимумов конец массива такое перемещать минимальные элементы его начало, то мы получаем двухстороннюю сортировку выбором.

    // Сложность по времени:
    // - Худшая	 O(n * n / 2)
    // - Средняя O(n * n / 2)
    // - Лучшая  O(n * n / 2)

    // Сложность по памяти
    // - Общая O(n)
    // - Дополнительная O(1)

    public class SelectionSort<T> : Base<T>
        where T : IComparable
    {
        public SelectionSort() { }

        public SelectionSort(IEnumerable<T> items) 
            :base(items) { }

        protected override void MakeSort()
        {
            for (var i = 0; i < Items.Count - 1; i++)
            {
                var maxIndex = 0;

                for (var j = 0; j < Items.Count - i; j++)
                {
                    if(Compare(Items[maxIndex], Items[j]) == -1)
                    {
                        maxIndex = j;
                    }
                }

                if (i != maxIndex)
                    Swap(maxIndex, Items.Count - 1 - i);
            }
        }

    }
}
