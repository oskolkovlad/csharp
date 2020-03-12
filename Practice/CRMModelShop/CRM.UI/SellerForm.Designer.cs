namespace CRM.UI
{
    partial class SellerForm
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
            this.nameSellerTextBox = new System.Windows.Forms.TextBox();
            this.nameSellerLabel = new System.Windows.Forms.Label();
            this.addSellerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameSellerTextBox
            // 
            this.nameSellerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameSellerTextBox.Location = new System.Drawing.Point(140, 24);
            this.nameSellerTextBox.Name = "nameSellerTextBox";
            this.nameSellerTextBox.Size = new System.Drawing.Size(291, 22);
            this.nameSellerTextBox.TabIndex = 0;
            // 
            // nameSellerLabel
            // 
            this.nameSellerLabel.AutoSize = true;
            this.nameSellerLabel.Location = new System.Drawing.Point(21, 24);
            this.nameSellerLabel.Name = "nameSellerLabel";
            this.nameSellerLabel.Size = new System.Drawing.Size(96, 17);
            this.nameSellerLabel.TabIndex = 1;
            this.nameSellerLabel.Text = "Введите имя:";
            // 
            // addSellerButton
            // 
            this.addSellerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addSellerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addSellerButton.Location = new System.Drawing.Point(308, 133);
            this.addSellerButton.Name = "addSellerButton";
            this.addSellerButton.Size = new System.Drawing.Size(123, 28);
            this.addSellerButton.TabIndex = 2;
            this.addSellerButton.Text = "Добавить";
            this.addSellerButton.UseVisualStyleBackColor = true;
            this.addSellerButton.Click += new System.EventHandler(this.addSellerButton_Click);
            // 
            // SellerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 185);
            this.Controls.Add(this.addSellerButton);
            this.Controls.Add(this.nameSellerLabel);
            this.Controls.Add(this.nameSellerTextBox);
            this.Name = "SellerForm";
            this.Text = "Seller Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameSellerTextBox;
        private System.Windows.Forms.Label nameSellerLabel;
        private System.Windows.Forms.Button addSellerButton;
    }
}