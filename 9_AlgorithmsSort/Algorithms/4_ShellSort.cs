﻿using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class ShellSort<T> : Base<T>
        where T: IComparable
    {
        // Алгоритм

        // Сортируем вставкой подгруппы элементов, но только в подгруппе они идут не в ряд, а равномерно выбираются
        // с некоторой дельтой по индексу. После первоначальных грубых проходов, дельта методично уменьшается, пока
        // расстояние между элементами этих несвязных подмножеств не достигнет единицы. Благодаря первоначальным проходам
        // с большим шагом, большинство малых по значению элементов перебрасываются в левую часть массива, большинство
        // крупных элементов массива попадают в правую.

        // Как известно, вставочный метод очень эффективно обрабатывает почти отсортированные массивы. Сортировка Шелла при
        // первоначальных проходах достаточно быстро и доводит массив к состоянию неполной упорядоченности. На заключительном
        // этапе шаг равен единице, т.е. "Шелл" естественным образом трансформируется в сортировку простыми вставками.

        // Сложность по времени:
        // - Худшая	 O(n * n) - Зависит от шага
        // - Средняя O(n * n) - Зависит от шага
        // - Лучшая  O(n)

        // Сложность по памяти
        // - Общая          O(n)
        // - Дополнительная O(1)

        public ShellSort() : base() { }
        public ShellSort(IEnumerable<T> items) : base(items) { }


        protected override void MakeSort()
        {
            var step = Items.Count / 2;

            while (step > 0)
            {
                for (var i = step; i < Items.Count; i++)
                {
                    var temp = Items[i];
                    var j = i;

                    while (j >= step && Compare(Items[j - step], temp) > 0)
                    {
                        //Items[j] = Items[j - step]; // Так правильней, Swap используется только для события
                        Swap(j, j - step);
                        j = j - step;
                    }

                    Items[j] = temp;
                }

                step /= 2;
            }
        }
    }
}
