using System;
using System.Collections.Generic;

namespace CRM.BL.Model
{
    public class Generator
    {
        public Generator()
        {
            Customers = new List<Customer>();
            Sellers = new List<Seller>();
            Products = new List<Product>();
        }

        public List<Customer> Customers { get; private set; }
        public List<Seller> Sellers { get; private set; }
        public List<Product> Products { get; private set; }


        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();
            for (var i = 0; i < count; i++)
            {
                var customer = new Customer(RandomText()) { CustomerId = Customers.Count };

                Customers.Add(customer);
                result.Add(customer);
            }

            return result;
        }

        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();
            for (var i = 0; i < count; i++)
            {
                var seller = new Seller(RandomText()) { SellerId = Sellers.Count };

                Sellers.Add(seller);
                result.Add(seller);
            }

            return result;
        }

        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (var i = 0; i < count; i++)
            {
                var product = new Product(RandomText(),
                                          (decimal)(new Random()).NextDouble() + (new Random()).Next(10, 100000),
                                          (new Random()).Next(10, 1000))
                {
                    ProductId = Products.Count
                };

                Products.Add(product);
                result.Add(product);
            }

            return result;
        }

        public List<Product> GetRandomProduts(int min, int max)
        {
            var result = new List<Product>();
            var count = new Random().Next(min, max);
            for (var i = 0; i < count; i++)
            {
                result.Add(Products[new Random().Next(Products.Count - 1)]);
            }

            return result;
        }


        private static string RandomText() => Guid.NewGuid().ToString().Substring(0, 5);
    }
}
