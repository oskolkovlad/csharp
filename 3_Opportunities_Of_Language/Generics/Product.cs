namespace Generics
{
    public class Product<T>
    {
        public string Name { get; set; }
        public T Volume { get; set; }
        public T Energy { get; set; }

        public Product(string name, T volume)
        {
            // TODO: проверить входные параметры

            Name = name;
            Volume = volume;

            // Значение по умолчанию:

            // В этом случае нам надо использовать оператор default(T). Он присваивает ссылочным типам в
            // качестве значения null, а типам значений - значение 0
            Energy = default(T);
        }

        public T AllEnergy (T Volume, T Energy)
        {
            return Volume = Energy;
        }
    }
}
