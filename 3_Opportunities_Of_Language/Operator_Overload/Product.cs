using System;


namespace Operator_Overload
{
    public abstract class Product
    {
        // Нельзя создавать объекты абстрактного класса


        public string Name { get;}
        /// <summary>
        /// Калорийность на 100 г продукта
        /// </summary>
        
        public int Сalories { get;}
        /// <summary>
        /// Объем в граммах
        /// </summary>
        
        public double Volume { get; set; }

        public double Energy
        {
            get
            {
                return Volume * Сalories / 100.0;
            }
        }


        public Product(string name, int calories, double volume)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (calories < 0)
                throw new ArgumentException(nameof(calories));

            if (volume <= 0)
                throw new ArgumentException(nameof(volume));
            
            Name = name;
            Сalories = calories;
            Volume = volume;
        }

        public override string ToString()
        {
            return $"{Name}:\tКалорийность: {Сalories}\tОбъем: {Volume}";
        }
    }
}
