namespace CRM.BL.Model
{
    public class Sell
    {
        public Sell() { }

        public Sell(int checkId, Check check, int productId, Product product)
        {
            CheckId = checkId;
            Check = check;
            ProductId = productId;
            Product = product;
        }

        public int SellId { get; set; }


        public int CheckId { get; set; }
        public virtual Check Check { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
