using System.Collections;
using System.Collections.Generic;

namespace Linked_List_2
{
    class LinkedList<T> : IEnumerable<T>
    {

        Item<T> head;
        Item<T> tail;

        public LinkedList()
        {
            Clear();
        }

        public LinkedList(T data)
        {
            Item<T> item = new Item<T>(data);
            head = item;
            tail = item;
            Count = 1;
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(T data)
        {
            Item<T> item = new Item<T>(data);

            if (head is null)
            {
                head = item;
            }
            else
            {
                tail.Next = item;
                item.Previous = tail;     
            }

            tail = item;
            Count++;
        }

        public void AddFirst(T data)
        {
            Item<T> item = new Item<T>(data);
            Item<T> temp = head;

            item.Next = head;
            head = item;

            if (head is null)
            {
                tail = head;
            }
            else
            {
                temp.Previous = item;
            }
            
            Count++;
        }

        public bool Remove(T data)
        {
            Item<T> current = head;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Next != null)
                    {
                        (current.Next).Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                    }

                    if (current.Previous != null)
                    {
                        (current.Previous).Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Contains(T data)
        {
            Item<T> current = head;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = default;
        }

        public override string ToString()
        {
            return $"В списке Count: {Count}";
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackGetEnumerator()
        {
            Item<T> current = tail;

            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
