namespace Linked_List_1
{
    /// <summary>
    /// Узел односвязного списка.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Item<T>
    {
        /// <summary>
        /// Конструктор создания узла в односвязном списке.
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        public Item(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Данные узла.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Следующий узел.
        /// </summary>
        public Item<T> Next { get; set; }
    }
}
