using System;
using System.Collections.Generic;

namespace Stack
{
    public class ListStack<T>
    {
        public ListStack()
        {
            items = new List<T>();
        }

        private List<T> items;

        public int Count => items.Count;
        
        public bool IsEmpty => Count == 0;
        
        public void Push(T item)
        {
            items.Add(item);
        }

        public T Peek() => items[Count - 1] ?? throw new NullReferenceException("Стек пустой!");
        
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("Стек пустой!");
            }
            
            var item = items[Count - 1];
            items.RemoveAt(Count - 1);

            return item;
        }

        public override string ToString() => $"Стек содержит {Count} эл. ...";

        public object Clone()
        {
            var newStack = new ListStack<T>();
            newStack.items = new List<T>(items);
            return newStack;
        }
    }
}