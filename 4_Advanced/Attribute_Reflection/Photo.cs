using System;

namespace Attribute_Reflection
{
    class Photo
    {
        [Geo(10, 20)]
        public string Name { get; set; }
        public string Path { get; set; }

        public Photo(string name)
        {
            // TODO: проверка входных данных

            Name = name;
        }
    }
}
