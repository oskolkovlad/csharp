using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class BinaryTree<T>
        where T : IComparable
    {
        public BinaryTree()
        {
            Root = null;
            Count = default;
        }

        public BinaryTree(IEnumerable<T> items)
            : this()
        {
            foreach(var i in items)
            {
                Add(i);
            }
        }

        private Node<T> Root { get; set; }
        public int Count { get; set; }
        public bool IsEmpty => Count == 0;


        public void Add(T data)
        {
            if (Root is null)
            {
                Root = new Node<T>(data);
            }
            else
            {
               Root.Add(data);
            }

            Count++;
        }


        public List<T> PreOrder()
        {
            if (Root is null)
            {
                return null;
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
                return null;
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
                return null;
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
