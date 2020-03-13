using System.Collections.Generic;

namespace CRM.BL.Model
{
    public class CashDesk
    {
        CRMContext db;

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            QueueCarts = new Queue<Cart>();
            IsModel = true;
            db = new CRMContext();
            MaxQueueLength = 100;
        }

        public int Number { get; private set; }
        public Seller Seller { get; private set; }
        public Queue<Cart> QueueCarts { get; private set; }

        public int MaxQueueLength { get; private set; }
        public int ExitCustomers { get; private set; }
        public bool IsModel { get; set; }


        public void Enqueue(Cart cart)
        {
            if (QueueCarts.Count < MaxQueueLength)
            {
                QueueCarts.Enqueue(cart);
            }
            else
            {
                ExitCustomers++;
            }
        }

        public decimal Dequeue()
        {
            var cart = QueueCarts.Dequeue();
            decimal cash = 0;

            if (cart != null)
            {
                var check = new Check(Seller.SellerId, Seller, cart.Customer.CustomerId, cart.Customer);

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in cart)
                {
                    if (product.Count > 0)
                    {
                        var sell = new Sell(check.CheckId, check, product.ProductId, product);
                        sells.Add(sell);

                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }

                        product.Count--;
                        cash += product.Price;
                    }
                    else
                    {
                        break;
                    }
                }

                if (!IsModel)
                {
                    db.SaveChanges();
                } 
            }

            return cash;
        }
    }
}
