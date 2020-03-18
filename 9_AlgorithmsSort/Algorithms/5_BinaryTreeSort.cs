using Algorithms.Trees;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    // Алгоритм

    // Из элементов массива формируется бинарное дерево поиска. Первый элемент - корень дерева, остальные добавляются по
    // следующему методу. Начиная с корня дерева, элемент сравнивается с узлами. Если элемент меньше чем узел - то спускаемся
    // по левой ветке, если не меньше - то по правой. Спустившись до конца, элемент сам становится узлом.

    // Построенное таким образом дерево можно легко обойти так, чтобы двигаться от узлов с меньшими значениями к узлам с
    // большими значениями. При этом получаем все элементы в возрастающем порядке.

    // Сложность по времени:
    // - Худшая	 O(n * n)
    // - Средняя O(n * log n)
    // - Лучшая  O(n * log n)

    // Сложность по памяти
    // - Дополнительная O(n)

    public class BinaryTreeSort<T> : Base<T>
        where T : IComparable
    {
         public BinaryTreeSort() { }
         public BinaryTreeSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            var tree = new BinaryTree<T>(Items);
            var sorted = tree.InOrder();
            Items = sorted;
        }
    }
}
