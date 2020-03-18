using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Tree<T>
        where T: IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public int Count { get; private set; }


        public void Add(T data)
        {
            if (Root is null)
            {
                Root = new Node<T>(data);
                Count++;
                return;
            }

            Root.Add(data);
            Count++;
        }


        //### Префиксный обход дерева: (копирование дерева)
        //# 1. Текущий элемент.
        //# 2. Левое поддерево.
        //# 3. Правое поддерево.

        //### Постфиксный обход дерева: (удаление)
        //# 1. Левое поддерево.
        //# 2. Правое поддерево.
        //# 3. Текущий элемент.

        //### Инфиксный обоход дерева: (сортировка)
        //# 1. Левое поддерево.
        //# 2. Текущий элемент.
        //# 3. Правое поддерево.


        public List<T> PreOrder()
        {
            if(Root is null)
            {
                return new List<T>();
            }

            return PreOrder(Root);
        }

        private List<T> PreOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(PreOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(PreOrder(node.Right));
                }
            }

            return list;
        }

        public List<T> PostOrder()
        {
            if(Root is null)
            {
                return new List<T>();
            }

            return PostOrder(Root);
        }

        public List<T> PostOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(PostOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(PostOrder(node.Right));
                }

                list.Add(node.Data);
            }
            

            return list;
        }

        public List<T> InOrder()
        {
            if(Root is null)
            {
                return new List<T>();
            }

            return InOrder(Root);
        }

        public List<T> InOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(InOrder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(InOrder(node.Right));
                } 
            }

            return list;
        }
    }
}
