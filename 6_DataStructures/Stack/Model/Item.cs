namespace Stack
{
    public class Item<T>
    {
        public Item(T data)
        {
            Data = data;
        }
        
        public T Data { get; set; }
        
        public Item<T> Next { get; set; }
    }
}