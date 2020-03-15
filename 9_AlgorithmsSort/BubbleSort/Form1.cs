using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Algorithms;

namespace _BubbleSort
{
    public partial class Form1 : Form
    {
        Base<int> BubbleSort;
        public Form1()
        {
            InitializeComponent();

            BubbleSort = new BubbleSort<int>();

            numericUpDown1.Maximum = 1000;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            BubbleSort.Items.Clear();

            BubbleSort.Items.AddRange(FillRandom((int)numericUpDown1.Value));
            foreach(var b in BubbleSort.Items)
            {
                listBox1.Items.Add(b);
            }

            BubbleSort.Sort();
            foreach (var b in BubbleSort.Items)
            {
                listBox2.Items.Add(b);
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
