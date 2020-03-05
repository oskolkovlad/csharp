namespace Linked_List_2
{
    public class Item<T>
    {
        public Item(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Item<T> Previous {get;set; }
        public Item<T> Next {get;set; }
    }
}
