using System; 

namespace BinarySearchTree
{
    class Node<T> : IComparable<T>
        where T: IComparable<T>
    {
        public Node() { }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Left = left;
            Right = right;
        }

        public T Data { get; set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }


        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (data.CompareTo(Data) == -1 )
            {
                if(Left is null)
                {
                    Left = node;
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
                    Right  = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public int CompareTo(T obj) => Data.CompareTo(obj); // ??? - не работает
    }
}
