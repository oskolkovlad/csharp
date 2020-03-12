using CRM.BL.Model;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; private set; }

        public SellerForm()
        {
            InitializeComponent();

            addSellerButton.Text = "Добавить";
        }

        public SellerForm(Seller seller)
            : this()
        {
            Seller = seller;
            nameSellerTextBox.Text = Seller.Name;

            addSellerButton.Text = "Изменить";
        }

        private void addSellerButton_Click(object sender, EventArgs e)
        {
            Seller = Seller ?? new Seller();
            Seller.Name = nameSellerTextBox.Text;

            Close();
        }
    }
}
