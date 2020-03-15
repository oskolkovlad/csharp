using System.Data.Entity;
using System.Windows.Forms;
using CRM.BL.Model;

namespace CRM.UI
{
    public partial class Catalog<TEntity> : Form
        where TEntity: class
    {
        private readonly CRMContext db;
        private readonly DbSet<TEntity> dbSet;

        public Catalog()
        {
            InitializeComponent();
        }

        public Catalog(DbSet<TEntity> dbSet, CRMContext db)
            : this()
        {
            dataGridView.DataSource = dbSet.Local.ToBindingList();
            this.db = db;
            this.dbSet = dbSet;
            dbSet.Load();
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            if(typeof(TEntity) == typeof(Product))
            {
                var productForm = new ProductForm();
                if (productForm.ShowDialog() == DialogResult.OK)
                {
                    db.Products.Add(productForm.Product);
                    db.SaveChanges();
                }
            }
            else if (typeof(TEntity) == typeof(Seller))
            {
                var sellerForm = new SellerForm();
                if (sellerForm.ShowDialog() == DialogResult.OK)
                {
                    db.Sellers.Add(sellerForm.Seller);
                    db.SaveChanges();
                }
            }
            else if (typeof(TEntity) == typeof(Customer))
            {
                var customerForm = new CustomerForm();
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    db.Customers.Add(customerForm.Customer);
                    db.SaveChanges();
                }
            }
        }

        private void updateButton_Click(object sender, System.EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(TEntity) == typeof(Product))
            {
                var product = dbSet.Find(id) as Product;

                if(product != null)
                {
                    var productForm = new ProductForm(product);

                    if (productForm.ShowDialog() == DialogResult.OK)
                    {
                        product = productForm.Product;
                        db.SaveChanges();
                    }
                } 
            }
            else if (typeof(TEntity) == typeof(Seller))
            {
                var seller = dbSet.Find(id) as Seller;

                if (seller != null)
                {
                    var sellerForm = new SellerForm(seller);

                    if (sellerForm.ShowDialog() == DialogResult.OK)
                    {
                        seller = sellerForm.Seller;
                        db.SaveChanges();
                    }
                }
            }
            else if (typeof(TEntity) == typeof(Customer))
            {
                var customer = dbSet.Find(id) as Customer;

                if (customer != null)
                {
                    var customerForm = new CustomerForm(customer);

                    if (customerForm.ShowDialog() == DialogResult.OK)
                    {
                        customer = customerForm.Customer;
                        db.SaveChanges();
                    }
                }
            }

            dataGridView.Refresh();
        }

        private void removeButton_Click(object sender, System.EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(TEntity) == typeof(Product))
            {
                var product = dbSet.Find(id) as Product;

                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
            else if (typeof(TEntity) == typeof(Seller))
            {
                var seller = dbSet.Find(id) as Seller;

                if (seller != null)
                {
                    db.Sellers.Remove(seller);
                    db.SaveChanges();
                }
            }
            else if (typeof(TEntity) == typeof(Customer))
            {
                var customer = dbSet.Find(id) as Customer;

                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
            }

            dataGridView.Update();
        }
    }
}
