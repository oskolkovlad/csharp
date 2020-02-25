using System;
namespace Generics
{
    public class Banan<T> : Product<T>
    {
        public Banan(string name, T volume)
            : base(name, volume) { }
    }
}
