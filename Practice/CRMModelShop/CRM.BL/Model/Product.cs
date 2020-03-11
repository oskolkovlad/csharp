using System.Collections.Generic;

namespace CRM.BL.Model
{
    public class Product
    {
        public Product() { }

        public Product(string name, decimal price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        public int ProductId { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; set; }
        public int Count { get; private set; }

        public virtual ICollection<Sell> Sells { get; set; }


        public override string ToString() => Name;
    }
}
