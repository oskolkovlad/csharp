namespace Circular_Linked_List
{
    public class ItemTwo<T>
    {
        public ItemTwo(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public ItemTwo<T> Previous {get;set; }
        public ItemTwo<T> Next {get;set; }
    }
}
