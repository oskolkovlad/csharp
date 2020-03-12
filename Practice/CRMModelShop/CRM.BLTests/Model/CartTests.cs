using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BL.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            // Arrange

            Customer customer = new Customer("Tom")
            {
                CustomerId = 1
            };
            Cart cart = new Cart(customer);

            Product product1 = new Product("Milk", 100, 43)
            {
                ProductId = 1
            };
            Product product2 = new Product("Bread", 100, 43)
            {
                ProductId = 2
            };
            Product product3 = new Product("Banan", 100, 43)
            {
                ProductId = 3
            };
            Product product4 = new Product("Apple", 100, 43)
            {
                ProductId = 4
            };
            Product product5 = null;


            // Act
            cart.Add(product1);
            cart.Add(product2);
            cart.Add(product3);
            cart.Add(product3);
            cart.Add(product3);
            cart.Add(product3);


            var expectedResult = new List<Product>()
            {
                product1, product2, product3, product3, product3, product3
            };

            // Assert
            Assert.AreEqual(cart.Products[product1], 1);
            Assert.AreEqual(cart.Products[product2], 1);
            Assert.AreEqual(cart.Products[product3], 4);
            Assert.AreEqual(cart.Products[product1], 1);
            Assert.AreEqual(expectedResult.Count, cart.GetAllProducts().Count);

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cart.GetAllProducts()[i]);
            }

            Assert.IsFalse(cart.Products.Keys.Contains(product4));
        }
    }
}