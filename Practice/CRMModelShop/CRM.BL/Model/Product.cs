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
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }


        public override string ToString() => Name;

        public override int GetHashCode() => ProductId;

        public override bool Equals(object obj)
        {
            if (obj is Product product)
            {
                return ProductId.Equals(product.ProductId);
            }

            return false;
        }
    }
}
