using System.Collections;
using System.Collections.Generic;

namespace CRM.BL.Model
{
    public class Cart : IEnumerable
    {
        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        public Customer Customer { get; private set; }
        public Dictionary<Product, int> Products { get; private set; }


        public void Add(Product product)
        {
            if (product != null)
            {
                if (Products.TryGetValue(product, out int count))
                {
                    Products[product] += 1;
                }
                else
                {
                    Products.Add(product, 1);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var p in Products.Keys)
            {
                for (var i = 0; i < Products[p]; i++)
                {
                    yield return p;
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            var cartList = new List<Product>();

            if (this != null)
            {
                foreach (var c in this)
                {
                    cartList.Add(c as Product);
                }
            }

            return cartList;
        }
    }
}
