using System;


namespace Virtual_Method_and_Property
{
    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine(Name);
        }
    }
    class Employee : Person
    {
        public string Company { get; set; }

        public Employee(string name, string company) : base(name)
        {
            Company = company;
        }


        // При переопределении виртуальных методов следует учитывать ряд ограничений:

        // - Виртуальный и переопределенный методы должны иметь один и тот же модификатор доступа.
        // То есть если виртуальный метод определен с помощью модификатора public, то и переопределенный метод
        // также должен иметь модификатор public.
        // - Нельзя переопределить или объявить виртуальным статический метод.


        // Также можно запретить переопределение методов и свойств с помощью модификатора sealed.
        // При создании методов с модификатором sealed надо учитывать, что sealed применяется в паре с override, 
        // то есть только в переопределяемых методах.
        public override sealed void Display()
        {
            // Кроме конструкторов, мы можем обратиться с помощью ключевого слова base к другим членам базового класса.
            base.Display();
            Console.WriteLine($"{Name} работает в {Company}");
        }
    }
}
