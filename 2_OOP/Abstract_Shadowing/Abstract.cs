using System;

//*** ABSTRACT CLASS ***//

namespace Abstract_Shadowing
{
    // Абстрактные члены классов не должны иметь модификатор private. При этом производный класс
    // обязан переопределить и реализовать все абстрактные методы и свойства, которые имеются в базовом абстрактном классе.

    // Также следует учесть, что если класс имеет хотя бы один абстрактный метод (или абстрактное
    // свойство, индексатор, событие), то этот класс должен быть определен как абстрактный.

    // Производный класс обязан реализовать все абстрактные члены базового класса. Однако мы можем отказаться от реализации,
    // но в этом случае производный класс также должен быть определен как абстрактный.

    abstract class Figure
    {

        // Абстрактное свойство Area. Оно похоже на автосвойство, но это не автосвойство. Так как данное свойство
        // не должно иметь реализацию, то оно имеет только пустые блоки get и set.

        public abstract float Width { get; set; }
        public float Heigth { get; set; }

        public abstract float Perimeter(float wigth, float heigth);
        public abstract float Area(float wigth, float heigth);

        public void Display()
        {
            Console.WriteLine($"Perimeter:\t{Perimeter(Width, Heigth)}; Area:\t{Area(Width, Heigth)}");
        }
    }

    class Rectangle : Figure
    {
        public override float Width { get; set; }

        public Rectangle(float wigth, float heigth)
        {
            Width = wigth;
            Heigth = heigth;
        }

        public override float Perimeter(float wigth, float heigth)
        {
            return (Width + Heigth) * 2;
        }
        public override float Area(float wigth, float heigth)
        {
            return Width * Heigth;
        }
    }
}
