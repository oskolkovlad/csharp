using System;
using System.Drawing;
using System.Windows.Forms;

namespace SortAlgorithms
{
    class SortedItem : IComparable
    {
        public SortedItem(int value, int number)
        {
            StartNumber = number;
            Number = number;
            Value = value;

            ProgressBar = new VerticalProgressBar.VerticalProgressBar();
            Label = new Label();

            // verticalProgressBar
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

            // label
            Label.AutoSize = true;
            Label.Location = new Point(18 * number + 20, 146);
            Label.Name = "sortLabel" + number;
            Label.Size = new Size(46, 17);
            Label.Text = Value.ToString();
        }

        public void SetPosition(int number)
        {
            var x = 18 * number + 20;

            ProgressBar.Location = new Point(x, 12);
            ProgressBar.Name = "verticalProgressBar" + number;
            Label.Location = new Point(x, 146);
            Label.Name = "sortLabel" + number;
            Number = number;
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

        public void RefreshToStart()
        {
            SetPosition(StartNumber);
        }

        public static void Swap(SortedItem A, SortedItem B)
        {
            var pointP = A.ProgressBar.Location;
            var pointL = A.Label.Location;
            var nameP  = A.ProgressBar.Name;
            var nameL  = A.Label.Name;

            A.ProgressBar.Location = B.ProgressBar.Location;
            A.Label.Location       = B.Label.Location;
            A.ProgressBar.Name     = B.ProgressBar.Name;
            A.Label.Name           = B.Label.Name;

            B.ProgressBar.Location = pointP;
            B.Label.Location       = pointL;
            B.ProgressBar.Name     = nameP;
            B.Label.Name           = nameL;
        }


        public VerticalProgressBar.VerticalProgressBar ProgressBar { get; private set; }
        public Label Label { get; private set; }

        public int Value { get; private set; }
        public int Number { get; private set; }
        public int StartNumber { get; private set; }


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

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
