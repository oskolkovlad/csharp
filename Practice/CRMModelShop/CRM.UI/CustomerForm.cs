using CRM.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; private set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = nameCustomerTextBox.Text
            };

            Close();
        }
    }
}
