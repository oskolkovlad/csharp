using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    // Алгоритм

    // Массив несколько раз перебирается и элементы перегруппировываются в зависимости от того, какая цифра находится
    // в определённом разряде.После обработки разрядов (всех или почти всех) массив оказывается упорядоченным.
    // При этом разряды могут обрабатываться в противоположных направлениях - от младших к старшим или наоборот.

    // Поразрядная LSD-сортировка по младшим разрядам
    // Элементы перебираются по порядку и группируются по самому младшему разряду (сначала все,
    // заканчивающиеся на 0, затем заканчивающиеся на 1, ..., заканчивающиеся на 9). Возникает новая последовательность.
    // Затем группируются по следующему разряду с конца, затем по следующему и т.д.пока не будут перебраны все разряды, от младших к старшим.

    // Точное название способа LSD radix sort(Least significant digit radix sorts) - поразрядная сортировка по наименьшей значащей цифре.


    // Поразрядная MSD-сортировка по старшим разрядам
    // Элементы перегруппироввываются по определённому разряду (сначала по самому старшему). Затем разбиваются на подгруппы
    // в зависимости от значения этого разряда: равного 0, равного 1, равного 2, ..., равного 9. Каждая подгруппа обрабатывается
    // отдельно, в ней к следующему разряду рекурсивно применяется radix sort.

    // Точное название способа MSD radix sort (Most significant digit radix sorts) - поразрядная сортировка по наибольшей значащей цифре.

    // MSD реализовывается несколько сложнее чем LSD, но при этом она эффективнее. При ориентации на наименьшие значащие
    // цифры для всех элементов обрабатываются все разряды. А вот в случае наибольших значащих цифр рекурсия продолжается
    // только до той глубины, до которой это необходимо, то есть пока у элементов подгруппы есть различия в определённом разряде.
    // Кроме того, MSD, в отличие от LSD, является устойчивым алгоритмом.

    // Сложность по времени:
    // - Худшая	 O(n * k)
    // - Лучшая  O(n)

    // Сложность по памяти
    // - Общая O(n + k)

    public class RadixMSDSort : Base<int>
    {
        public RadixMSDSort() { }

        public RadixMSDSort(IEnumerable<int> items)
            : base(items) { }

        protected override void MakeSort()
        {
            var length = GetMaxLength(Items);
            var result = SortCollection(Items, length);
            Items = result;


            //************************************************************************//


            // Вариант для массивов (+ N к памяти, так как Items - List)

            /*var old = Items.ToArray();

            int i, j;
            int[] tmp = new int[old.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < old.Length; ++i)
                {
                    bool move = (old[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)  // shift the 0's to old's head
                        old[i - j] = old[i];
                    else                            // move the 1's to tmp
                        tmp[j++] = old[i];
                }
                Array.Copy(tmp, 0, old, old.Length - j, j);
            }


            Items = old.ToList();*/
        }


        private List<int> SortCollection(List<int> collection, int step)
        {
            var result = new List<int>();

            var groups = new List<List<int>>(10);
            for (var i = 0; i < 10; i++)
            {
                groups.Add(new List<int>());
            }

            // Распределение элементов по корзинам
            foreach (var item in collection)
            {
                int value = item % (int)Math.Pow(10, step) / (int)Math.Pow(10, step - 1);
                groups[value].Add(item);
            }

            // Сборка элементов
            foreach (var group in groups)
            {
                if (group.Count > 1 && step > 1)
                {
                    result.AddRange(SortCollection(group, step - 1));
                    continue;
                }

                result.AddRange(group);
            }

            return result;
        }

        private int GetMaxLength(List<int> collection)
        {
            var length = 0;

            foreach (var item in collection)
            {
                if (item < 0)
                {
                    throw new ArgumentException("Числа не могут быть меньше нуля...");
                }

                //var l = Convert.ToInt32(Math.Log10(item) + 1); // не работает при 0
                var l = item.ToString().Length;

                if (l > length)
                {
                    length = l;
                }
            }

            return length;
        }

    }
}
