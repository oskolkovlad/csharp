using System.Data.Entity;

namespace CRM.BL.Model
{
    public class CRMContext : DbContext
    {
        public CRMContext()
            : base("DBConnectionString") { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Sell> Sells { get; set; }
    }
}
