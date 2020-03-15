using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM.BL.Model;

namespace CRM.UI
{
    public partial class Main : Form
    {
        private readonly CRMContext db;
        private Cart cart;
        private Customer customer;
        private CashDesk cashDesk;

        public Main()
        {
            InitializeComponent();

            db = new CRMContext();
            cart = new Cart(customer);
            cashDesk = new CashDesk(1, db.Sellers.FirstOrDefault(), db)
            {
                IsModel = false
            };


            label3.Text = "Итого: "; 
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

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelForm modelForm = new ModelForm();
            modelForm.Show();
        }

        #endregion


        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBox1.Invoke((Action)delegate
                {
                    listBox1.Items.AddRange(db.Products.ToArray());
                    UpdateListBoxes();
                });
            });
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem is Product product)
            {
                cart.Add(product);
                UpdateListBoxes();
            }
        }

        private void UpdateListBoxes()
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(cart.GetAllProducts().ToArray());

            label3.Text = "Итого: " + cart.Price;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();

            if(login.DialogResult == DialogResult.OK)
            {
                var tempCustomer = db.Customers.FirstOrDefault(c => c.Name.Equals(login.Customer.Name));
                if (tempCustomer != null)
                {
                    customer = tempCustomer;
                }
                else
                {
                    db.Customers.Add(login.Customer);
                    db.SaveChanges();
                    customer = login.Customer;
                }

                cart.Customer = customer;
                linkLabel1.Text = "Здравствуй, " + customer.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customer != null)
            {
                if (listBox2.Items.Count != 0)
                {
                    cashDesk.Enqueue(cart);
                    cashDesk.Dequeue();

                    MessageBox.Show($"Спасибо за покупку! Сумма покупки: {cart.Price}", "Продажа", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listBox2.Items.Clear();
                    cart = new Cart(customer);
                }
                else
                {
                    MessageBox.Show("Заполните корзину!", "Корзина пуста", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Авторизуйтесь, пожалуйста...", "Пользователь не авторизован", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
