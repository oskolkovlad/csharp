using System;
using System.Collections.Generic;
using System.Linq;

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

        public BinaryTreeSort(IEnumerable<T> items)
        {
            var nodes = items.ToList();
            for (int i = 0; i < nodes.Count; i++)
            {
                var item = nodes[i];
                Items.Add(item);
                Add(new Node<T>(item, i));
            }
        }

        private Node<T> Root { get; set; }
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(Node<T> node)
        {
            if (Root is null)
            {
                Root = node;
                Count++;
                return;
            }

            Add(Root, node);
            Count++;
        }

        public void Add(Node<T> node, Node<T> newNode)
        {
            if (Compare(node.Data, newNode.Data) == 1)
            {
                if (node.Left is null)
                {
                    node.Left = newNode;
                }
                else
                {
                    Add(node.Left, newNode);
                }
            }
            else
            {
                if (node.Right is null)
                {
                    node.Right = newNode;
                }
                else
                {
                    Add(node.Right, newNode);
                }
            }
        }

        private List<Node<T>> InOrder(Node<T> node)
        {
            var items = new List<Node<T>>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    items.AddRange(InOrder(node.Left));
                }

                items.Add(node);

                if (node.Right != null)
                {
                    items.AddRange(InOrder(node.Right));
                }
            }

            return items;
        }

        protected override void MakeSort()
        {
            var result = InOrder(Root).Select(r => r.Data).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                Set(i, result[i]);
            }
        }
    }
}

