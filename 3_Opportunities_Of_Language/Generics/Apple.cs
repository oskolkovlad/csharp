namespace Generics
{
    public class Apple<T> : Product<T>
    {
        public Apple(string name, T volume)
            : base(name, volume) { }
    }
}
