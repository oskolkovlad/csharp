using CRM.BL.Model;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class LoginForm : Form
    {
        public Customer Customer { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Customer = new Customer(nameLoginTextBox.Text);
            DialogResult = DialogResult.OK;
        }
    }
}
