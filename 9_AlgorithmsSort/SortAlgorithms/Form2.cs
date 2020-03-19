using Algorithms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public partial class Form2 : Form
    {
        Base<SortedItem> algorithm;
        List<int> items;
        List<SortedItem> verticalProgressBars;
        readonly int sleep = 50;

        public Form2()
        {
            InitializeComponent();

            addNumericUpDown.Maximum  = 30;
            randNumericUpDown.Maximum = 30;
            addNumericUpDown.Value    = 10;
            randNumericUpDown.Value   = 10;
            compareTextBox.ReadOnly   = true;
            swapTextBox.ReadOnly      = true;
            timeTextBox.ReadOnly      = true;

            items                = new List<int>();
            verticalProgressBars = new List<SortedItem>();

            // Переключение сортировок
            string[] cb = {
                "Bubble Sort",
                "Shaker Sort",
                "Insertion Sort",
                "Shell Sort",
                "Binary Tree Sort",
                "Heap Sort",
                "Selection Sort"
            };
            comboBox1.Items.AddRange(cb);
            comboBox1.SelectedIndex = 5;    // Изначально будет выбрана Bubble Sort
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            var item = new SortedItem((int)addNumericUpDown.Value, verticalProgressBars.Count);
            verticalProgressBars.Add(item);

            RefreshVerBars();
        }

        private void RandButton_Click(object sender, EventArgs e)
        {
            items.Clear();
            items.AddRange(FillRandom((int)randNumericUpDown.Value));

            foreach (var i in items)
            {
                var sortedItem = new SortedItem(i, verticalProgressBars.Count);
                verticalProgressBars.Add(sortedItem);
            }

            RefreshVerBars();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    algorithm = new BubbleSort<SortedItem>(verticalProgressBars);
                    break;
                case 1:
                    algorithm = new ShakerSort<SortedItem>(verticalProgressBars);
                    break;
                case 2:
                    algorithm = new InsertionSort<SortedItem>(verticalProgressBars);
                    break;
                case 3:
                    algorithm = new ShellSort<SortedItem>(verticalProgressBars);
                    break;
                case 4:
                    algorithm = new BinaryTreeSort<SortedItem>(verticalProgressBars);
                    break;
                case 5:
                    algorithm = new HeapSort<SortedItem>(verticalProgressBars);
                    break;
                case 6:
                    algorithm = new SelectionSort<SortedItem>(verticalProgressBars);
                    break;
            }

            Button_Click(algorithm);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            barsPanel.Controls.Clear();
            verticalProgressBars.Clear();

            compareTextBox.Text = "";
            swapTextBox.Text = "";
            timeTextBox.Text = "";
        }



        private void Button_Click(Base<SortedItem> _algorithm)
        {
            compareTextBox.Text = "";
            swapTextBox.Text = "";
            timeTextBox.Text = "";

            RefreshVerBars();

            for (var i = 0; i < _algorithm.Items.Count; i++)
            {
                _algorithm.Items[i].SetPosition(i);
            }
            barsPanel.Refresh();

            _algorithm.CompareEvent += Algorithm_CompareEvent;
            _algorithm.SwapEvent    += Algorithm_SwapEvent;

            var time = _algorithm.Sort();

            compareTextBox.Text = _algorithm.CompareCount.ToString();
            swapTextBox.Text = _algorithm.SwapCount.ToString();
            timeTextBox.Text = time.ToString();
        }

        private void RefreshVerBars()
        {
            foreach (var bar in verticalProgressBars)
            {
                bar.RefreshToStart();
            }

            DrawVerBars(verticalProgressBars);
        }

        private void DrawVerBars(List<SortedItem> bars)
        {
            barsPanel.Controls.Clear();
            barsPanel.Refresh();

            foreach(var bar in bars)
            {
                barsPanel.Controls.Add(bar.ProgressBar);
                barsPanel.Controls.Add(bar.Label);
            }

            barsPanel.Refresh();
        }


        private void Algorithm_CompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);
            barsPanel.Refresh();

            Thread.Sleep(sleep);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            barsPanel.Refresh();

            Thread.Sleep(sleep);
        }

        private void Algorithm_SwapEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Aqua);
            e.Item2.SetColor(Color.Brown);
            barsPanel.Refresh();

            Thread.Sleep(sleep);

            var temp = e.Item1.Number;
            e.Item1.SetPosition(e.Item2.Number);
            e.Item2.SetPosition(temp); 
            barsPanel.Refresh();

            Thread.Sleep(sleep);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            barsPanel.Refresh();

            Thread.Sleep(sleep);
        }

        private void AlgorithmSetEvent(object sender, Tuple<int, SortedItem> e)
        {
            e.Item2.SetColor(Color.Red);
            barsPanel.Refresh();

            Thread.Sleep(sleep);

            e.Item2.SetPosition(e.Item1);
            barsPanel.Refresh();

            Thread.Sleep(sleep);

            e.Item2.SetColor(Color.Blue);
            barsPanel.Refresh();

            Thread.Sleep(sleep);
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
