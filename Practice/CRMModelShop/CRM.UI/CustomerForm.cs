using CRM.BL.Model;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; private set; }

        public CustomerForm()
        {
            InitializeComponent();

            addCustomerButton.Text = "Добавить";
        }

        public CustomerForm(Customer customer)
            : this()
        {
            Customer = customer ?? new Customer();
            nameCustomerTextBox.Text = Customer.Name;

            addCustomerButton.Text = "Изменить";
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new Customer();
            Customer.Name = nameCustomerTextBox.Text;

            Close();
        }
    }
}
