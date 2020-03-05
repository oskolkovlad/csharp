namespace Circular_Linked_List
{
    /// <summary>
    /// Узел односвязного списка.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ItemOne<T>
    {
        /// <summary>
        /// Конструктор создания узла в односвязном списке.
        /// </summary>
        /// <param name="data"> Данные узла. </param>
        public ItemOne(T data)
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
        public ItemOne<T> Next { get; set; }
    }
}
