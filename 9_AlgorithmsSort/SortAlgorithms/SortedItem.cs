using System;
using System.Drawing;
using System.Windows.Forms;

namespace SortAlgorithms
{
    class SortedItem : IComparable
    {
        public SortedItem(int value, int number)
        {
            Value = value;

            ProgressBar = new VerticalProgressBar.VerticalProgressBar();
            Label = new Label();

            // 
            // verticalProgressBar
            // 
            ProgressBar.BorderStyle = VerticalProgressBar.BorderStyles.Classic;
            ProgressBar.Color = Color.Blue;
            ProgressBar.Location = new Point(18 * number + 20, 12);
            ProgressBar.Maximum = 100;
            ProgressBar.Minimum = 0;
            ProgressBar.Name = "verticalProgressBar" + number;
            ProgressBar.Size = new Size(20, 120);
            ProgressBar.Step = 10;
            ProgressBar.Style = VerticalProgressBar.Styles.Solid;
            ProgressBar.Value = Value;

            // 
            // label
            // 
            Label.AutoSize = true;
            Label.Location = new Point(18 * number + 20, 146);
            Label.Name = "sortLabel" + number;
            Label.Size = new Size(46, 17);
            Label.Text = Value.ToString();
        }

        public void SetNewValue(int value)
        {
            Value = value;
            ProgressBar.Value = Value;
            Label.Text = Value.ToString();
        }

        public void SetColor(Color color)
        {
            ProgressBar.Color = color;
        }

        public VerticalProgressBar.VerticalProgressBar ProgressBar { get; private set; }
        public Label Label { get; private set; }

        public int Value { get; private set; }


        public int CompareTo(object obj)
        {
            if(obj is SortedItem item)
            {
                return Value.CompareTo(item.Value);
            }
            else
            {
                throw new ArgumentException("Объект не является SortesItem...");
            }
        }
    }
}
