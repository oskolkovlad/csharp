using System;
using System.Collections.Generic;
using System.Text;

namespace Extension_Method
{
    sealed class Road
    {
        public int Number { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return $"Номер дороги: M-{Number}; Длина дороги: {Length}";
        }
    }
}
