namespace CRM.UI
{
    partial class CustomerForm
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
            this.nameCustomerTextBox = new System.Windows.Forms.TextBox();
            this.nameCustomerLabel = new System.Windows.Forms.Label();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameCustomerTextBox
            // 
            this.nameCustomerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameCustomerTextBox.Location = new System.Drawing.Point(140, 24);
            this.nameCustomerTextBox.Name = "nameCustomerTextBox";
            this.nameCustomerTextBox.Size = new System.Drawing.Size(291, 22);
            this.nameCustomerTextBox.TabIndex = 0;
            // 
            // nameCustomerLabel
            // 
            this.nameCustomerLabel.AutoSize = true;
            this.nameCustomerLabel.Location = new System.Drawing.Point(21, 24);
            this.nameCustomerLabel.Name = "nameCustomerLabel";
            this.nameCustomerLabel.Size = new System.Drawing.Size(96, 17);
            this.nameCustomerLabel.TabIndex = 1;
            this.nameCustomerLabel.Text = "Введите имя:";
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCustomerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addCustomerButton.Location = new System.Drawing.Point(308, 133);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(123, 28);
            this.addCustomerButton.TabIndex = 2;
            this.addCustomerButton.Text = "Добавить";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 185);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.nameCustomerLabel);
            this.Controls.Add(this.nameCustomerTextBox);
            this.Name = "CustomerForm";
            this.Text = "Customer Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameCustomerTextBox;
        private System.Windows.Forms.Label nameCustomerLabel;
        private System.Windows.Forms.Button addCustomerButton;
    }
}