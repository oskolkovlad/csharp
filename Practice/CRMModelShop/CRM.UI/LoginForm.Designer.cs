namespace CRM.UI
{
    partial class LoginForm
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
            this.loginButton = new System.Windows.Forms.Button();
            this.nameLoginLabel = new System.Windows.Forms.Label();
            this.nameLoginTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loginButton.Location = new System.Drawing.Point(14, 90);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(407, 28);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // nameLoginLabel
            // 
            this.nameLoginLabel.AutoSize = true;
            this.nameLoginLabel.Location = new System.Drawing.Point(11, 25);
            this.nameLoginLabel.Name = "nameLoginLabel";
            this.nameLoginLabel.Size = new System.Drawing.Size(96, 17);
            this.nameLoginLabel.TabIndex = 4;
            this.nameLoginLabel.Text = "Введите имя:";
            // 
            // nameLoginTextBox
            // 
            this.nameLoginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLoginTextBox.Location = new System.Drawing.Point(130, 25);
            this.nameLoginTextBox.Name = "nameLoginTextBox";
            this.nameLoginTextBox.Size = new System.Drawing.Size(291, 22);
            this.nameLoginTextBox.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 148);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.nameLoginLabel);
            this.Controls.Add(this.nameLoginTextBox);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label nameLoginLabel;
        private System.Windows.Forms.TextBox nameLoginTextBox;
    }
}