namespace Generics
{

    //*** Наследование обобщенных типов ***//

    // 1. Первый вариант заключается в создание класса-наследника, который типизирован тем же типом, что и базовый.
    public class Apple<T> : Product<T>
    {
        public Apple(string name, T volume)
            : base(name, volume) { }
    }
}
