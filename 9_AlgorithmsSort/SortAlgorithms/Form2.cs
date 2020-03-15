using Algorithms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public partial class Form2 : Form
    {
        Base<int> shaker;
        //List<int> items;
        List<SortedItem> verticalProgressBars;

        public Form2()
        {
            InitializeComponent();

            //items = new List<int>();
            shaker = new ShakerSort<int>();
            verticalProgressBars = new List<SortedItem>();

            addNumericUpDown.Maximum = 100000;
            randNumericUpDown.Maximum = 100000;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //items.Add((int)addNumericUpDown.Value);

            var item = new SortedItem((int)addNumericUpDown.Value);
            verticalProgressBars.Add(item);
            barsPanel.Controls.Add(item.Label);
            barsPanel.Controls.Add(item.ProgressBar);
             

            addNumericUpDown.Value = 0;
        }

        private void RandButton_Click(object sender, EventArgs e)
        {
            //items.AddRange(FillRandom((int)randNumericUpDown.Value));

            var item = new SortedItem((int)randNumericUpDown.Value);
            verticalProgressBars.Add(item);
            //barsPanel.Controls.Add(item.ProgressBar);
            //barsPanel.Controls.Add(item.Label);

            randNumericUpDown.Value = 0;
        }

        private List<int> FillRandom(int count)
        {
            var result = new List<int>(count);
            var rnd = new Random();

            for (var i = 0; i < count; i++)
            {
                result.Add(rnd.Next(0, 100));
            }

            return result;
        }
    }
}
