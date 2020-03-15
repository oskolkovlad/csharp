using System;
using System.Collections.Generic;
using Algorithms;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public partial class Form1 : Form
    {
        ShakerSort<int> shakerSort;
        public Form1()
        {
            InitializeComponent();

            shakerSort = new ShakerSort<int>();

            numericUpDown1.Maximum = 100000;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            shakerSort.Items.Clear();

            shakerSort.Items.AddRange(FillRandom((int)numericUpDown1.Value));
            foreach (var b in shakerSort.Items)
            {
                listBox1.Items.Add(b);
            }

            shakerSort.Sort();
            foreach (var b in shakerSort.Items)
            {
                listBox2.Items.Add(b);
            }

            textBox1.Text = shakerSort.SwapCount.ToString();
            textBox2.Text = shakerSort.CompareCount.ToString();
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
