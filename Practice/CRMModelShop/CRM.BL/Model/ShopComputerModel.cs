using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue(), null));
            }

            Generator.GetNewProducts(1000);

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            Tasks = new List<Task>();
    }

        public List<CashDesk> CashDesks { get; private set; }
        public List<Cart> Carts { get; private set; }
        public List<Check> Checks { get; private set; }
        public List<Sell> Sells { get; private set; }

        public Queue<Seller> Sellers { get; private set; }

        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;

        private List<Task> Tasks;

        private readonly CancellationTokenSource tokenSource;
        private readonly CancellationToken token;


        public void Start()
        {
            Tasks.Add(new Task(() => CreateCarts(10)));
            Tasks.AddRange(CashDesks.Select(c => new Task(() => CashDeskWork(c))));

            foreach(var task in Tasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            tokenSource.Cancel();
        }

        private void CashDeskWork(CashDesk cashDesk)
        {
            while (!token.IsCancellationRequested)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(CashDeskSpeed);
                }
            }
        }

        private void CreateCarts(int customerCounts)
        {
            while (!token.IsCancellationRequested)
            {
                var customers = Generator.GetNewCustomers(customerCounts);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach (var product in Generator.GetRandomProduts(10, 30))
                    {
                        cart.Add(product);
                    }

                    var cashDesk = CashDesks[rnd.Next(CashDesks.Count)];
                    cashDesk.Enqueue(cart);
                }

                Thread.Sleep(CustomerSpeed);
            }
        }
    }
}
