namespace Patrial_LocalMethod_PatternMatching_Deconstrucor
{
    // Частичный класс
    partial class Person
    {
        // Частичные методы не могут иметь модификаторов доступа - по умолчанию они все считаются приватными.
        // Также частичные методы не могут иметь таких модификаторов как virtual, abstract, override, new, sealed.
        // Хотя допустимы статические частичные методы.

        // Кроме того, частичные методы не могут возвращать значения, то есть они всегда имеют тип void.
        // И также они не могут иметь out-параметров.


        // Частичный метод - здесь определяется, во второй части реализуется
        partial void DoAction();

        public string Name { get; set; }


        public Person(string name, int age)
        {
            Name = name;
            Age = age;

            DoAction();
        }

    }
}
