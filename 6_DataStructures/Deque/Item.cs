namespace Deque
{
    class Item<T>
    {
        public Item(T data)
        {
            Data = data;
        }

        public T Data { get; private set; }
        public Item<T> Next { get; set; }
        public Item<T> Previous { get; set; }
    }
}
