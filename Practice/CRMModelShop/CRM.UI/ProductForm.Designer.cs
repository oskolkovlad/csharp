namespace CRM.UI
{
    partial class ProductForm
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
            this.nameProductTextBox = new System.Windows.Forms.TextBox();
            this.nameProductLabel = new System.Windows.Forms.Label();
            this.addProductButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.countNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.countNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameProductTextBox
            // 
            this.nameProductTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameProductTextBox.Location = new System.Drawing.Point(140, 24);
            this.nameProductTextBox.Name = "nameProductTextBox";
            this.nameProductTextBox.Size = new System.Drawing.Size(291, 22);
            this.nameProductTextBox.TabIndex = 0;
            // 
            // nameProductLabel
            // 
            this.nameProductLabel.AutoSize = true;
            this.nameProductLabel.Location = new System.Drawing.Point(21, 24);
            this.nameProductLabel.Name = "nameProductLabel";
            this.nameProductLabel.Size = new System.Drawing.Size(76, 17);
            this.nameProductLabel.TabIndex = 1;
            this.nameProductLabel.Text = "Название:";
            // 
            // addProductButton
            // 
            this.addProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addProductButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addProductButton.Location = new System.Drawing.Point(308, 174);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(123, 28);
            this.addProductButton.TabIndex = 2;
            this.addProductButton.Text = "Добавить";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(21, 124);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(90, 17);
            this.countLabel.TabIndex = 1;
            this.countLabel.Text = "Количество:";
            // 
            // countNumericUpDown
            // 
            this.countNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countNumericUpDown.Location = new System.Drawing.Point(140, 118);
            this.countNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.countNumericUpDown.Name = "countNumericUpDown";
            this.countNumericUpDown.Size = new System.Drawing.Size(291, 22);
            this.countNumericUpDown.TabIndex = 3;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(21, 74);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(47, 17);
            this.priceLabel.TabIndex = 1;
            this.priceLabel.Text = "Цена:";
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceNumericUpDown.DecimalPlaces = 2;
            this.priceNumericUpDown.Location = new System.Drawing.Point(140, 68);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(291, 22);
            this.priceNumericUpDown.TabIndex = 3;
            this.priceNumericUpDown.ThousandsSeparator = true;
            // 
            // ProductForm
            // 
            this.AcceptButton = this.addProductButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 242);
            this.Controls.Add(this.priceNumericUpDown);
            this.Controls.Add(this.countNumericUpDown);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.nameProductLabel);
            this.Controls.Add(this.nameProductTextBox);
            this.Name = "ProductForm";
            this.Text = "Product Form";
            ((System.ComponentModel.ISupportInitialize)(this.countNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameProductTextBox;
        private System.Windows.Forms.Label nameProductLabel;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.NumericUpDown countNumericUpDown;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
    }
}