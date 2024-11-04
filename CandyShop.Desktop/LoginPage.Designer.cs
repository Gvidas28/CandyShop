namespace CandyShop.Desktop
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EmployeeCheckBox = new System.Windows.Forms.CheckBox();
            this.AdminCheckBox = new System.Windows.Forms.CheckBox();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Candy Shop!";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameTextBox.Location = new System.Drawing.Point(85, 221);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(231, 27);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordTextBox.Location = new System.Drawing.Point(85, 287);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(231, 27);
            this.PasswordTextBox.TabIndex = 2;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Yellow;
            this.LoginButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginButton.ForeColor = System.Drawing.Color.Indigo;
            this.LoginButton.Location = new System.Drawing.Point(134, 347);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(135, 63);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(134, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(135, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // EmployeeCheckBox
            // 
            this.EmployeeCheckBox.AutoSize = true;
            this.EmployeeCheckBox.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmployeeCheckBox.ForeColor = System.Drawing.Color.Indigo;
            this.EmployeeCheckBox.Location = new System.Drawing.Point(152, 320);
            this.EmployeeCheckBox.Name = "EmployeeCheckBox";
            this.EmployeeCheckBox.Size = new System.Drawing.Size(93, 21);
            this.EmployeeCheckBox.TabIndex = 6;
            this.EmployeeCheckBox.Text = "Emloyee";
            this.EmployeeCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdminCheckBox
            // 
            this.AdminCheckBox.AutoSize = true;
            this.AdminCheckBox.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AdminCheckBox.ForeColor = System.Drawing.Color.Indigo;
            this.AdminCheckBox.Location = new System.Drawing.Point(152, 320);
            this.AdminCheckBox.Name = "AdminCheckBox";
            this.AdminCheckBox.Size = new System.Drawing.Size(81, 21);
            this.AdminCheckBox.TabIndex = 7;
            this.AdminCheckBox.Text = "Admin";
            this.AdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = global::CandyShop.Desktop.Properties.Resources.candy_png_30;
            this.LogoPictureBox.ImageLocation = "";
            this.LogoPictureBox.Location = new System.Drawing.Point(139, 65);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(123, 111);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 8;
            this.LogoPictureBox.TabStop = false;
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.Yellow;
            this.RegisterButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegisterButton.ForeColor = System.Drawing.Color.Indigo;
            this.RegisterButton.Location = new System.Drawing.Point(152, 416);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(99, 32);
            this.RegisterButton.TabIndex = 9;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.AdminCheckBox);
            this.Controls.Add(this.EmployeeCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Name = "LoginPage";
            this.Text = "Candy Shop";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox EmployeeCheckBox;
        private System.Windows.Forms.CheckBox AdminCheckBox;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Button RegisterButton;
    }
}