using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BL.Model
{
    public class ShopComputerModel
    {
        Generator Generator;
        Random rnd = new Random();

        public ShopComputerModel()
        {
            Generator = new Generator();
            CashDesks = new List<CashDesk>();
            Carts = new List<Cart>();
            Checks = new List<Check>();
            Sells = new List<Sell>();

            Sellers = new Queue<Seller>();

            var sellers = Generator.GetNewSellers(25);
            foreach(var s in sellers)
            {
                Sellers.Enqueue(s);
            }

            for(var i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }

            Generator.GetNewCustomers(100);
            Generator.GetNewProducts(1000);
        }

        public List<CashDesk> CashDesks { get; private set; }
        public List<Cart> Carts { get; private set; }
        public List<Check> Checks { get; private set; }
        public List<Sell> Sells { get; private set; }

        public Queue<Seller> Sellers { get; private set; }


        public void Start()
        {
            var customers = Generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();

            foreach(var customer in customers)
            {
                var cart = new Cart(customer);


                foreach(var product in Generator.GetRandomProduts(10, 30))
                {
                    cart.Add(product);
                }

                carts.Enqueue(cart);
            }

            //var cashDesk = CashDesks[rnd.Next(CashDesks.Count - 1)]; // TODO:
            while(carts.Count > 0)
            {
                var cashDesk = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cashDesk.Enqueue(carts.Dequeue());
            }

            decimal cash;
            while (true)
            {
                var cashDesk = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cash = cashDesk.Dequeue();
            }

            

        }

    }
}
