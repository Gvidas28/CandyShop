namespace CandyShop.Desktop
{
    partial class OrderUpdatePage
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
            this.label3 = new System.Windows.Forms.Label();
            this.CustomerIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemIdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(114, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update Order";
            // 
            // CustomerIdTextBox
            // 
            this.CustomerIdTextBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CustomerIdTextBox.Location = new System.Drawing.Point(84, 78);
            this.CustomerIdTextBox.Name = "CustomerIdTextBox";
            this.CustomerIdTextBox.Size = new System.Drawing.Size(231, 27);
            this.CustomerIdTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(139, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "*Customer ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(150, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "*Item ID";
            // 
            // ItemIdTextBox
            // 
            this.ItemIdTextBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemIdTextBox.Location = new System.Drawing.Point(84, 142);
            this.ItemIdTextBox.Name = "ItemIdTextBox";
            this.ItemIdTextBox.Size = new System.Drawing.Size(231, 27);
            this.ItemIdTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(160, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "*Status";
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusTextBox.Location = new System.Drawing.Point(84, 195);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(231, 27);
            this.StatusTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(160, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "*Price";
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PriceTextBox.Location = new System.Drawing.Point(84, 248);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(231, 27);
            this.PriceTextBox.TabIndex = 13;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.Yellow;
            this.UpdateButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpdateButton.ForeColor = System.Drawing.Color.Indigo;
            this.UpdateButton.Location = new System.Drawing.Point(124, 478);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(135, 63);
            this.UpdateButton.TabIndex = 17;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Indigo;
            this.label6.Location = new System.Drawing.Point(139, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "*Order Date";
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(84, 312);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(231, 27);
            this.DatePicker.TabIndex = 22;
            // 
            // OrderUpdatePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(382, 553);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerIdTextBox);
            this.Controls.Add(this.label3);
            this.Name = "OrderUpdatePage";
            this.Text = "OrderUpdatePage";
            this.Load += new System.EventHandler(this.OrderUpdatePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CustomerIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ItemIdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StatusTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DatePicker;
    }
}