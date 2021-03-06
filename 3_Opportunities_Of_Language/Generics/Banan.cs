﻿namespace Generics
{

    //*** Наследование обобщенных типов ***//

    // 2. Второй вариант представляет создание обычного необобщенного класса-наследника.
    // В этом случае при наследовании у базового класса надо явным образом определить используемый тип.
    public class Banan : Product<int>
    {
        public Banan(string name, int volume)
            : base(name, volume) { }
    }
}
