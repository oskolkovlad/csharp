using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.BL.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            // Arrange
            Customer customer1 = new Customer("Tom")
            {
                CustomerId = 1
            };
            Customer customer2 = new Customer("Michael")
            {
                CustomerId = 2
            };

            Seller seller = new Seller("Alex")
            {
                SellerId = 1
            };

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

            Cart cart1 = new Cart(customer1);
            Cart cart2 = new Cart(customer2);
            Check check1 = new Check(seller.SellerId, seller, customer1.CustomerId, customer1);
            Check check2 = new Check(seller.SellerId, seller, customer2.CustomerId, customer2);

            CashDesk cashDesk = new CashDesk(1, seller, null);


            // Act
            cart1.Add(product1);
            cart1.Add(product2);
            cart1.Add(product3);
            cart1.Add(product3);
            cart1.Add(product3);
            cart1.Add(product3);

            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product3);
            cart2.Add(product3);

            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);


            // Assert
            Assert.AreEqual(600, cashDesk.Dequeue());
            Assert.AreEqual(400, cashDesk.Dequeue());

            Assert.AreEqual(43 - 2,     product1.Count);
            Assert.AreEqual(43 - 2,     product2.Count);
            Assert.AreEqual(43 - 4 - 2, product3.Count);
        }
    }
}