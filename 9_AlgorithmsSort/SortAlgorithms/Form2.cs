using Algorithms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public partial class Form2 : Form
    {
        Base<int> algorithm;
        List<int> items;
        List<SortedItem> verticalProgressBars;

        public Form2()
        {
            InitializeComponent();

            items = new List<int>();
            verticalProgressBars = new List<SortedItem>();

            addNumericUpDown.Maximum = 100000;
            randNumericUpDown.Maximum = 100000;

            addNumericUpDown.Value = 10;
            randNumericUpDown.Value = 10;

            string[] cb = {
                "Bubble Sort",
                "Shaker Sort",
                "Insertion Sort"
            };
            comboBox1.Items.AddRange(cb);
            //comboBox1.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var item = new SortedItem((int)addNumericUpDown.Value, verticalProgressBars.Count);
            verticalProgressBars.Add(item);
            barsPanel.Controls.Add(item.ProgressBar);
            barsPanel.Controls.Add(item.Label);

            //addNumericUpDown.Value = 0;
        }

        private void RandButton_Click(object sender, EventArgs e)
        {
            items.Clear();
            items.AddRange(FillRandom((int)randNumericUpDown.Value));

            SortedItem item;
            foreach (var i in items)
            {
                item = new SortedItem(i, verticalProgressBars.Count);

                verticalProgressBars.Add(item);
                barsPanel.Controls.Add(item.ProgressBar);
                barsPanel.Controls.Add(item.Label);
            }
             
            //randNumericUpDown.Value = 0;
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            var algorithm = new BubbleSort<SortedItem>(verticalProgressBars);

            algorithm.CompareEvent += Algorithm_CompareEvent;
            algorithm.SwapEvent    += Algorithm_SwapEvent;

            algorithm.Sort();
        }

        private void Algorithm_CompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);

            barsPanel.Refresh();
        }

        private void Algorithm_SwapEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            var temp = e.Item1.Value;
            e.Item1.SetNewValue(e.Item2.Value);
            e.Item2.SetNewValue(temp);

            barsPanel.Refresh();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            barsPanel.Controls.Clear();
            verticalProgressBars.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    algorithm = new BubbleSort<int>();
                    break;
                case 1:
                    algorithm = new ShakerSort<int>();
                    break;
                case 2:
                    algorithm = new InsertionSort<int>();
                    break;
            }
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
