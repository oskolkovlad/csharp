using System;

//*** SHADOWING ***/
namespace Abstract_Shadowing
{
    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine($"Name:\t{Name}");
        }
    }

    class Doctor : Person
    {
        public string Specialization { get; set; }

        public Doctor(string name, string speialization)
            : base(name)
        {
            Specialization = speialization;
        }


        // Фактически сокрытие представляет определение в классе-наследнике метода или свойства, которые
        // соответствует по имени и набору параметров методу или свойству базового класса.
        // Для сокрытия членов класса применяется ключевое слово "new".

        // В каких ситуациях можно использовать сокрытие? Например, в примере выше метод Display в базовом классе не является 
        // виртуальным, мы не можем его переопределить, но, допустим, нас не устраивает его реализация для производного класса, 
        // поэтому мы можем воспользоваться сокрытием, чтобы определить нужный нам функционал.

        // При этом если мы хотим обратиться именно к реализации свойства или метода в базовом классе, то опять же мы можем
        // использовать ключевое слово "base" и через него обращаться к функциональности базового класса.

        public new void Display()
        {
            Console.WriteLine();
            base.Display();
            Console.WriteLine($"Spec:\t{Specialization}");
        } 
    }
}
