using CRM.BL.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model;
        private List<CashBoxView> CashBoxView;

        public ModelForm()
        {
            InitializeComponent();

            model = new ShopComputerModel();
            CashBoxView = new List<CashBoxView>();

            numericUpDown1.Value = model.CustomerSpeed;
            numericUpDown2.Value = model.CashDeskSpeed;
            numericUpDown1.Maximum = 5000;
            numericUpDown2.Maximum = 5000;

            stopModelButton.Enabled = false;
        }

        private void runModelButton_Click(object sender, EventArgs e)
        {
            if (CashBoxView != null)
            {
                foreach (var cashBoxView in CashBoxView)
                {
                    Controls.Remove(cashBoxView.NumLabel);
                    Controls.Remove(cashBoxView.ExitLabel);
                    Controls.Remove(cashBoxView.NumericUpDown);
                    Controls.Remove(cashBoxView.ProgressBar);
                }
                CashBoxView.Clear();
            }

            stopModelButton.Enabled = true;
            runModelButton.Enabled = false;

            for (var i = 0; i < model.CashDesks.Count; i++)
            {
                var cashBoxView = new CashBoxView(model.CashDesks[i], i, 29, 27 + i * 80, 223, 25 + i * 80, 32, 64 + i * 80);
                CashBoxView.Add(cashBoxView);

                Controls.Add(cashBoxView.NumLabel);
                Controls.Add(cashBoxView.ExitLabel);
                Controls.Add(cashBoxView.NumericUpDown);
                Controls.Add(cashBoxView.ProgressBar);
            }

            model.Start();
        }

        private void stopModelButton_Click(object sender, EventArgs e)
        {
            stopModelButton.Enabled = false;
            runModelButton.Enabled = true;

            model.Stop();
            model = new ShopComputerModel();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeed = Convert.ToInt32(numericUpDown1.Value);
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = Convert.ToInt32(numericUpDown2.Value);
        }
    }
}
