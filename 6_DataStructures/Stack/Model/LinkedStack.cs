using System;
using System.Collections;

namespace Stack
{
    public class LinkedStack<T> : IEnumerable
    {
        public LinkedStack()
        {
            head = null;
            Count = default;
        }
        
        public LinkedStack(T data)
        {
            head = new Item<T>(data);
            Count = 1;
        }

        private Item<T> head;

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;


        public void Push(T data)
        {
            var item = new Item<T>(data);

            item.Next = head;
            head = item;
            Count++;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Стек пустой!");
            }

            return head.Data;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Стек пустой!");
            }

            var item = head.Data;
            head = head.Next;
            Count--;

            return item;
        }

        public override string ToString() => $"Стек содержит {Count} эл. ...";

        public IEnumerator GetEnumerator()
        {
            var current = head;
            while (!(current is null))
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
