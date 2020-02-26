namespace Generics
{

    //*** Наследование обобщенных типов ***//

    // 3. Третий вариант представляет типизацию производного класса параметром совсем другого типа, отличного
    // от универсального параметра в базовом классе.В этом случае для базового класса также надо указать используемый тип.

    class Ananas<T> : Product<int>
    {
        public Ananas(string name, int volume)
            : base(name, volume) { }
    }


    // 4. И также в классах-наследниках можно сочетать использование универсального параметра из базового класса
    // с применением своих параметров.

    class MixedAccount<T, K> : Product<T>
    where K : struct
    {
        public K Code { get; set; }
        public MixedAccount(string name, T volume)
            : base(name, volume) { }
    }
}
