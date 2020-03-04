using System.Collections;
using System.Collections.Generic;

namespace Linked_List_1
{
    /// <summary>
    /// Односвязный список.
    /// </summary>
    /// <typeparam name="T"> Тип списка. </typeparam>
    public class LinkedList<T> : IEnumerable<T> // Односвязный список
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public LinkedList()
        {
            RemoveAll();
        }

        /// <summary>
        /// Конструктор создания односвязного списка с одним элементом.
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            head = item;
            tail = item;
            Count++;
        }

        /// <summary>
        /// Головной (начальный) узел.
        /// </summary>
        Item<T> head;

        /// <summary>
        /// Конечный узел (хвост).
        /// </summary>
        Item<T> tail;

        /// <summary>
        /// Количество узлов в списке.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Проверяет пустой список ли нет.
        /// </summary>
        public bool IsEmpty { get => Count == 0; }


        /// <summary>
        /// Добавление узла в список.
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        public void Add(T data) //Сложность алгоритма метода составляет O(1).
        {
            Item<T> item = new Item<T>(data);

            if (head is null)
            {
                head = item;
            }
            else
            {
                tail.Next = item;
            }

            tail = item;
            Count++;
        }

        // Данный способ вполне рабочий и нередко встречается, однако необходимость перебора элементов для нахождения
        // последнего увеличивает время на поиск и сложность алгоритма. Она равна O(n).
        
        /// <summary>
        /// Добавление узла в список (без хвоста).
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        public void AddWithoutTail(T data) //Сложность алгоритма метода составляет O(n).
        {
            var item = new Item<T>(data);

            if (head is null)
            {
                head = item;
            }
            else
            {
                Item<T> current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = item;
            }

            Count++;
        }

        /// <summary>
        /// Добавление узла в начало списка.
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        public void AppendFirst(T data)
        {
            var item = new Item<T>(data);
            item.Next = head;
            head = item;

            if (Count == 0)
            {
                tail = head;
            }

            Count++;
        }

        /// <summary>
        /// Добавление узла после указанного.
        /// </summary>
        /// <param name="target"> Узел, после которого необходима вставка. </param>
        /// <param name="data"> Данные узла. </param>
        public void InsertAfter(T target, T data)
        {
            Item<T> item = new Item<T>(data);
            Item<T> current = head;
            Item<T> next = head.Next;

            while(current != null)
            {
                if (current.Data.Equals(target))
                {
                    if (next is null)
                    {
                        current.Next = item;
                        tail = item;
                    }
                    else
                    {
                        item.Next = next;
                        current.Next = item;
                    }

                    Count++;
                    break;
                }

                current = current.Next;
                next = current.Next;
            }
        }

        /// <summary>
        /// Удаление узла из списка.
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        /// <returns> Успешность удаления. </returns>
        public bool Remove(T data) //Сложность алгоритма метода составляет O(n).
        {
            Item<T> current = head;
            Item<T> previous = null;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    if(previous != null)
                    {
                        previous.Next = current.Next;

                        if(current.Next is null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;

                        if(head is null)
                        {
                            tail = null;
                        }
                    }

                    Count--;
                    return true;  
                }

                previous = current;
                current = current.Next;
            }

            return false;   
        }

        /// <summary>
        /// Проверка на наличие узла в списке.
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        /// <returns> Успешность проверки. </returns>
        public bool Contains(T data) //Сложность алгоритма метода составляет O(n).
        {
            var current = head;

            while(current.Next != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Очистка списка.
        /// </summary>
        public void RemoveAll()
        {
            head = null;
            tail = null;
            Count = default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = head;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return $"Linked list contains {Count} items...";
        }
    }
}
