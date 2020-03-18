using System;

namespace Algorithms
{
    public class Node<T>
         where T : IComparable
    {
        public Node() { }
        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public T Data { get; private set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        public void Add(T data)
        {
            if(Data.CompareTo(data) > 0)
            {
                if(Left is null)
                {
                    Left = new Node<T>(data);
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right is null)
                {
                    Right = new Node<T>(data);
                }
                else
                {
                    Right.Add(data);
                }
            }
        }
    }
}
