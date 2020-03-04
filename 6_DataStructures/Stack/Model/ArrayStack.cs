using System;

namespace Stack
{
    public class ArrayStack<T>
    {
        public ArrayStack(int length = 10)
        {
            items = new T[length];
            Count = default;
        }

        private T[] items;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Push(T data)
        {
            if (Count == items.Length)
            {
                Resize(items.Length + 10);
            }

            items[Count++] = data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            
            return items[Count - 1];
        }
        
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            
            var item = items[--Count];
            items[Count] = default(T);
            
            if (Count > 0 && Count + 10 < items.Length)
            {
                Resize(items.Length - 10);
            }

            return item;
        }

        private void Resize(int length)
        {
            var newStack = new T[length];
            for (var i = 0; i < Count; i++)
            {
                newStack[i] = items[i];
            }

            items = newStack;
        }
        
        public override string ToString() => $"Стек содержит {Count} эл. ...";
    }
}