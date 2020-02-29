using System;

namespace Attribute_Reflection
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor)] // накладывается ограничение на то, что может пользоваться нашем атрибутом
    class GeoAttribute : Attribute
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GeoAttribute() { }
        public GeoAttribute(int x, int y)
        {
            // TODO: проверка входных данных

            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"[{X}; {Y}]";
        }
    }
}
