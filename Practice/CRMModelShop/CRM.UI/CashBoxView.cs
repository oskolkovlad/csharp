using CRM.BL.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CRM.UI
{
    public class CashBoxView
    {
        public CashBoxView(CashDesk cashDesk, int number, int lX, int lY, int nX, int nY, int pX, int pY)
        {
            NumLabel = new Label();
            ExitLabel = new Label();
            NumericUpDown = new NumericUpDown();
            ProgressBar = new ProgressBar();
            CashDesk = cashDesk;

            CreateElements(number, lX, lY, nX, nY, pX, pY);
        }

        private CashDesk CashDesk { get; set; }
        public Label NumLabel { get; private set; }
        public Label ExitLabel { get; private set; }
        public NumericUpDown NumericUpDown { get; private set; }
        public ProgressBar ProgressBar { get; private set; }


        private void CreateElements(int num, int labelX, int labelY, int numX, int numY, int progX, int progY)
        {
            var number = num + 1;
            NumLabel.AutoSize = true;
            NumLabel.Location = new Point(labelX, labelY);
            NumLabel.Name = "numCustomersLable" + number;
            NumLabel.Size = new Size(46, 17);
            NumLabel.Text = "Касса №" + number;

            NumericUpDown.Location = new Point(numX, numY);
            NumericUpDown.Name = "numericUpDown" + number;
            NumericUpDown.Size = new Size(155, 22);
            NumericUpDown.Maximum = 1000000000000;

            ProgressBar.Location = new Point(progX, progY);
            ProgressBar.Maximum = CashDesk.MaxQueueLength;
            ProgressBar.Name = "progressBar" + number;
            ProgressBar.Size = new Size(346, 23);
            ProgressBar.Value = 0;

            ExitLabel.AutoSize = true;
            ExitLabel.Location = new Point(346 + 50, progY);
            ExitLabel.Name = "exitCustomersLable" + number;
            ExitLabel.Size = new Size(46, 17);
            ExitLabel.Text = "";

            CashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            NumericUpDown?.Invoke((Action)delegate
            {
                NumericUpDown.Value += e.Price;
                ProgressBar.Value = CashDesk.Count;
                ExitLabel.Text = "Ушло: " + CashDesk.ExitCustomers;
            });
        }
    }
}
