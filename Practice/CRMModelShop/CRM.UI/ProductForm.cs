using CRM.BL.Model;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class ProductForm : Form
    {
        public Product Product { get; private set; }

        public ProductForm()
        {
            InitializeComponent();

            addProductButton.Text = "Добавить";
        }
        public ProductForm(Product product)
                        : this()
        {
            Product = product;

            nameProductTextBox.Text = Product.Name;
            priceNumericUpDown.Value = Product.Price;
            countNumericUpDown.Value = Convert.ToDecimal(Product.Count);

            addProductButton.Text = "Изменить";
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            Product.Name = nameProductTextBox.Text;
            Product.Price = priceNumericUpDown.Value;
            Product.Count = Convert.ToInt32(countNumericUpDown.Value);

            Close();
        }
    }
}
