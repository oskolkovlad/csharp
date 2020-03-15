using System.Drawing;
using System.Windows.Forms;

namespace SortAlgorithms
{
    class SortedItem
    {
        public SortedItem(int value)
        {
            Value = value;

            ProgressBar = new VerticalProgressBar.VerticalProgressBar();
            Label = new Label();

            // 
            // verticalProgressBar
            // 
            ProgressBar.BorderStyle = VerticalProgressBar.BorderStyles.Classic;
            ProgressBar.Color = Color.Blue;
            ProgressBar.Location = new Point(18, 12);
            ProgressBar.Maximum = 100;
            ProgressBar.Minimum = 0;
            ProgressBar.Name = "verticalProgressBar";
            ProgressBar.Size = new Size(20, 120);
            ProgressBar.Step = 10;
            ProgressBar.Style = VerticalProgressBar.Styles.Solid;
            ProgressBar.Value = Value;

            // 
            // label
            // 
            Label.AutoSize = true;
            Label.Location = new Point(18, 146);
            Label.Name = "sortLabel";
            Label.Size = new Size(46, 17);
            Label.Text = Value.ToString();
        }

        public VerticalProgressBar.VerticalProgressBar ProgressBar { get; private set; }
        public Label Label { get; private set; }

        public int Value { get; set; }          
    }
}
