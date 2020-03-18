using System;
using System.Collections.Generic;

namespace Algorithms.Trees
{
    public class BinaryTree<T>
        where T : IComparable
    {
        public BinaryTree() { }

        public BinaryTree(IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                Add(item);
            }
        }

        private Node<T> Root { get; set; }
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(T data)
        {
            if (Root is null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Add(Root, data);
            Count++;
        }

        public void Add(Node<T> item, T data)
        {
            var node = new Node<T>(data);

            if (node.Data.CompareTo(item.Data) == -1)
            {
                if (item.Left is null)
                {
                    item.Left = node;
                }
                else
                {
                    Add(item.Left, data);
                }
            }
            else
            {
                if (item.Right is null)
                {
                    item.Right = node;
                }
                else
                {
                    Add(item.Right, data);
                }
            }
        }


        public List<T> PreOrder()
        {
            if (Root is null)
            {
                return new List<T>();
            }

            return PreOrder(Root);
        }

        private List<T> PreOrder(Node<T> node)
        {
            var items = new List<T>();

            if (node != null)
            {
                items.Add(node.Data);

                if (node.Left != null)
                {
                    items.AddRange(PreOrder(node.Left));
                }

                if (node.Right != null)
                {
                    items.AddRange(PreOrder(node.Right));
                }
            }

            return items;
        }

        public List<T> PostOrder()
        {
            if (Root is null)
            {
                return new List<T>();
            }

            return PostOrder(Root);
        }

        private List<T> PostOrder(Node<T> node)
        {
            var items = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    items.AddRange(PostOrder(node.Left));
                }

                if (node.Right != null)
                {
                    items.AddRange(PostOrder(node.Right));
                }

                items.Add(node.Data);
            }

            return items;
        }

        public List<T> InOrder()
        {
            if (Root is null)
            {
                return new List<T>();
            }

            return InOrder(Root);
        }

        private List<T> InOrder(Node<T> node)
        {
            var items = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    items.AddRange(InOrder(node.Left));
                }

                items.Add(node.Data);

                if (node.Right != null)
                {
                    items.AddRange(InOrder(node.Right));
                }
            }

            return items;
        }
    }
}
