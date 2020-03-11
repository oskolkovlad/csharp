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
            var catalogProduct = new Catalog<Product>(db.Products);
            catalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(db.Sellers);
            catalogSeller.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers);
            catalogCustomer.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks);
            catalogCheck.Show();
        }

        #endregion

        private void AddCustomerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm();
            if(customerForm.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(customerForm.Customer);
                db.SaveChanges();
            }
        }
    }
}
