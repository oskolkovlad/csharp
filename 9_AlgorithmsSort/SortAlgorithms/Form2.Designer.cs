namespace SortAlgorithms
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addPanel = new System.Windows.Forms.Panel();
            this.addNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.addLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.randPanel = new System.Windows.Forms.Panel();
            this.randNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.randLabel = new System.Windows.Forms.Label();
            this.randButton = new System.Windows.Forms.Button();
            this.barsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.addPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addNumericUpDown)).BeginInit();
            this.randPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // addPanel
            // 
            this.addPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addPanel.Controls.Add(this.addNumericUpDown);
            this.addPanel.Controls.Add(this.addLabel);
            this.addPanel.Controls.Add(this.addButton);
            this.addPanel.Location = new System.Drawing.Point(22, 23);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(417, 67);
            this.addPanel.TabIndex = 0;
            // 
            // addNumericUpDown
            // 
            this.addNumericUpDown.Location = new System.Drawing.Point(159, 17);
            this.addNumericUpDown.Name = "addNumericUpDown";
            this.addNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.addNumericUpDown.TabIndex = 3;
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(15, 19);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(110, 17);
            this.addLabel.TabIndex = 2;
            this.addLabel.Text = "Введите число:";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addButton.Location = new System.Drawing.Point(280, 15);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(122, 30);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // randPanel
            // 
            this.randPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.randPanel.Controls.Add(this.randNumericUpDown);
            this.randPanel.Controls.Add(this.randLabel);
            this.randPanel.Controls.Add(this.randButton);
            this.randPanel.Location = new System.Drawing.Point(22, 160);
            this.randPanel.Name = "randPanel";
            this.randPanel.Size = new System.Drawing.Size(417, 67);
            this.randPanel.TabIndex = 0;
            // 
            // randNumericUpDown
            // 
            this.randNumericUpDown.Location = new System.Drawing.Point(159, 17);
            this.randNumericUpDown.Name = "randNumericUpDown";
            this.randNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.randNumericUpDown.TabIndex = 3;
            // 
            // randLabel
            // 
            this.randLabel.AutoSize = true;
            this.randLabel.Location = new System.Drawing.Point(15, 19);
            this.randLabel.Name = "randLabel";
            this.randLabel.Size = new System.Drawing.Size(62, 17);
            this.randLabel.TabIndex = 2;
            this.randLabel.Text = "Рандом:";
            // 
            // randButton
            // 
            this.randButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.randButton.Location = new System.Drawing.Point(280, 15);
            this.randButton.Name = "randButton";
            this.randButton.Size = new System.Drawing.Size(122, 30);
            this.randButton.TabIndex = 1;
            this.randButton.Text = "Добавить";
            this.randButton.UseVisualStyleBackColor = false;
            this.randButton.Click += new System.EventHandler(this.RandButton_Click);
            // 
            // barsPanel
            // 
            this.barsPanel.Location = new System.Drawing.Point(472, 23);
            this.barsPanel.Name = "barsPanel";
            this.barsPanel.Size = new System.Drawing.Size(729, 204);
            this.barsPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(22, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(417, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сортировать";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 255);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.barsPanel);
            this.Controls.Add(this.randPanel);
            this.Controls.Add(this.addPanel);
            this.Name = "Form2";
            this.Text = "Алгоритмы сортировок";
            this.addPanel.ResumeLayout(false);
            this.addPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addNumericUpDown)).EndInit();
            this.randPanel.ResumeLayout(false);
            this.randPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.NumericUpDown addNumericUpDown;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel randPanel;
        private System.Windows.Forms.NumericUpDown randNumericUpDown;
        private System.Windows.Forms.Label randLabel;
        private System.Windows.Forms.Button randButton;
        private System.Windows.Forms.Panel barsPanel;
        private System.Windows.Forms.Button button1;
    }
}