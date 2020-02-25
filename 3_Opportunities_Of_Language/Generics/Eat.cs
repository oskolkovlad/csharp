namespace Generics
{
    public class Eat<T>
        where T: Product<T>
    {
        public int Volume { get; private set; }
        public void Add(T product)
        {
            //Volume += product.Volume * product.Energy;
        }
    }
}
