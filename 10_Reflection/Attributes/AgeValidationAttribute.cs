using System;

namespace Attributes
{
    // Ограничение задает перечисление AttributeTargets, которое может принимать еще ряд значений:

    // - All: используется всеми типами
    // - Assembly: атрибут применяется к сборке
    // - Constructor: атрибут применяется к конструктору
    // - Delegate: атрибут применяется к делегату
    // - Enum: применяется к перечислению
    // - Event: атрибут применяется к событию
    // - Field: применяется к полю типа
    // - Interface: атрибут применяется к интерфейсу
    // - Method: применяется к методу
    // - Property: применяется к свойству
    // - Struct: применяется к структуре

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AgeValidationAttribute : Attribute
    {
        public int Age { get; set; }

        public AgeValidationAttribute()
        { }

        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }
}
