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
        }

        private void addSellerButton_Click(object sender, EventArgs e)
        {
            Seller = new Seller()
            {
                Name = nameSellerTextBox.Text
            };

            Close();
        }
    }
}
