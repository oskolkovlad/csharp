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
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            Product = new Product()
            {
                Name = nameProductTextBox.Text,
                Price = priceNumericUpDown.Value,
                Count = Convert.ToInt32(countNumericUpDown.Value)
            };

            Close();
        }
    }
}
