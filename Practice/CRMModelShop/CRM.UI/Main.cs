using System;
using System.Windows.Forms;
using CRM.BL.Model;

namespace CRM.UI
{
    public partial class Main : Form
    {
        private readonly CRMContext db;

        public Main()
        {
            InitializeComponent();

            db = new CRMContext();
        }


#region MenuStrip

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products, db);
            catalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(db.Sellers, db);
            catalogSeller.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers, db);
            catalogCustomer.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks, db);
            catalogCheck.Show();
        }


        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(productForm.Product);
                db.SaveChanges();
            }
        }

        private void AddCustomerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm();
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(customerForm.Customer);
                db.SaveChanges();
            }
        }

        private void AddSellerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sellerForm = new SellerForm();
            if (sellerForm.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(sellerForm.Seller);
                db.SaveChanges();
            }
        }

        #endregion



    }
}
