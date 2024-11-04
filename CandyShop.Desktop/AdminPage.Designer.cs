namespace CandyShop.Desktop
{
    partial class AdminPage
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
            this.AdminListButton = new System.Windows.Forms.Button();
            this.AdminDataTable = new System.Windows.Forms.DataGridView();
            this.EmployeeListButton = new System.Windows.Forms.Button();
            this.CustomerListButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ItemsButton = new System.Windows.Forms.Button();
            this.OrderList = new System.Windows.Forms.Button();
            this.CriticalOrdersButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemIDFilter = new System.Windows.Forms.TextBox();
            this.StatusFilter = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DateFromFilter = new System.Windows.Forms.DateTimePicker();
            this.DateFromFilterLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateToFilter = new System.Windows.Forms.DateTimePicker();
            this.FilterButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ItemsSoldLabel = new System.Windows.Forms.Label();
            this.WaitingOrdersLabel = new System.Windows.Forms.Label();
            this.MoneyMadeLabel = new System.Windows.Forms.Label();
            this.BestCustomerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AdminDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminListButton
            // 
            this.AdminListButton.BackColor = System.Drawing.Color.Yellow;
            this.AdminListButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AdminListButton.ForeColor = System.Drawing.Color.Indigo;
            this.AdminListButton.Location = new System.Drawing.Point(12, 12);
            this.AdminListButton.Name = "AdminListButton";
            this.AdminListButton.Size = new System.Drawing.Size(135, 63);
            this.AdminListButton.TabIndex = 4;
            this.AdminListButton.Text = "Admin List";
            this.AdminListButton.UseVisualStyleBackColor = false;
            this.AdminListButton.Click += new System.EventHandler(this.AdminListButton_Click);
            // 
            // AdminDataTable
            // 
            this.AdminDataTable.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.AdminDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdminDataTable.Location = new System.Drawing.Point(12, 91);
            this.AdminDataTable.Name = "AdminDataTable";
            this.AdminDataTable.ReadOnly = true;
            this.AdminDataTable.RowHeadersWidth = 51;
            this.AdminDataTable.RowTemplate.Height = 29;
            this.AdminDataTable.Size = new System.Drawing.Size(958, 290);
            this.AdminDataTable.TabIndex = 5;
            // 
            // EmployeeListButton
            // 
            this.EmployeeListButton.BackColor = System.Drawing.Color.Yellow;
            this.EmployeeListButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmployeeListButton.ForeColor = System.Drawing.Color.Indigo;
            this.EmployeeListButton.Location = new System.Drawing.Point(162, 12);
            this.EmployeeListButton.Name = "EmployeeListButton";
            this.EmployeeListButton.Size = new System.Drawing.Size(135, 63);
            this.EmployeeListButton.TabIndex = 6;
            this.EmployeeListButton.Text = "Employee List";
            this.EmployeeListButton.UseVisualStyleBackColor = false;
            this.EmployeeListButton.Click += new System.EventHandler(this.EmployeeListButton_Click);
            // 
            // CustomerListButton
            // 
            this.CustomerListButton.BackColor = System.Drawing.Color.Yellow;
            this.CustomerListButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CustomerListButton.ForeColor = System.Drawing.Color.Indigo;
            this.CustomerListButton.Location = new System.Drawing.Point(315, 12);
            this.CustomerListButton.Name = "CustomerListButton";
            this.CustomerListButton.Size = new System.Drawing.Size(135, 63);
            this.CustomerListButton.TabIndex = 7;
            this.CustomerListButton.Text = "Customer List";
            this.CustomerListButton.UseVisualStyleBackColor = false;
            this.CustomerListButton.Click += new System.EventHandler(this.CustomerListButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.Yellow;
            this.AddButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddButton.ForeColor = System.Drawing.Color.Indigo;
            this.AddButton.Location = new System.Drawing.Point(12, 397);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(84, 44);
            this.AddButton.TabIndex = 8;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.Yellow;
            this.UpdateButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpdateButton.ForeColor = System.Drawing.Color.Indigo;
            this.UpdateButton.Location = new System.Drawing.Point(113, 397);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(84, 44);
            this.UpdateButton.TabIndex = 9;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Yellow;
            this.DeleteButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.ForeColor = System.Drawing.Color.Indigo;
            this.DeleteButton.Location = new System.Drawing.Point(213, 397);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(84, 44);
            this.DeleteButton.TabIndex = 10;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ItemsButton
            // 
            this.ItemsButton.BackColor = System.Drawing.Color.Yellow;
            this.ItemsButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemsButton.ForeColor = System.Drawing.Color.Indigo;
            this.ItemsButton.Location = new System.Drawing.Point(835, 12);
            this.ItemsButton.Name = "ItemsButton";
            this.ItemsButton.Size = new System.Drawing.Size(135, 63);
            this.ItemsButton.TabIndex = 11;
            this.ItemsButton.Text = "Items";
            this.ItemsButton.UseVisualStyleBackColor = false;
            this.ItemsButton.Click += new System.EventHandler(this.ItemsButton_Click);
            // 
            // OrderList
            // 
            this.OrderList.BackColor = System.Drawing.Color.Yellow;
            this.OrderList.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OrderList.ForeColor = System.Drawing.Color.Indigo;
            this.OrderList.Location = new System.Drawing.Point(682, 12);
            this.OrderList.Name = "OrderList";
            this.OrderList.Size = new System.Drawing.Size(135, 63);
            this.OrderList.TabIndex = 12;
            this.OrderList.Text = "Orders";
            this.OrderList.UseVisualStyleBackColor = false;
            this.OrderList.Click += new System.EventHandler(this.OrderList_Click);
            // 
            // CriticalOrdersButton
            // 
            this.CriticalOrdersButton.BackColor = System.Drawing.Color.Yellow;
            this.CriticalOrdersButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CriticalOrdersButton.ForeColor = System.Drawing.Color.Indigo;
            this.CriticalOrdersButton.Location = new System.Drawing.Point(532, 12);
            this.CriticalOrdersButton.Name = "CriticalOrdersButton";
            this.CriticalOrdersButton.Size = new System.Drawing.Size(135, 63);
            this.CriticalOrdersButton.TabIndex = 13;
            this.CriticalOrdersButton.Text = "Critical Orders";
            this.CriticalOrdersButton.UseVisualStyleBackColor = false;
            this.CriticalOrdersButton.Click += new System.EventHandler(this.CriticalOrdersButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(791, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Item ID";
            // 
            // ItemIDFilter
            // 
            this.ItemIDFilter.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemIDFilter.Location = new System.Drawing.Point(726, 433);
            this.ItemIDFilter.Name = "ItemIDFilter";
            this.ItemIDFilter.Size = new System.Drawing.Size(231, 27);
            this.ItemIDFilter.TabIndex = 14;
            // 
            // StatusFilter
            // 
            this.StatusFilter.AutoSize = true;
            this.StatusFilter.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusFilter.ForeColor = System.Drawing.Color.Indigo;
            this.StatusFilter.Location = new System.Drawing.Point(803, 476);
            this.StatusFilter.Name = "StatusFilter";
            this.StatusFilter.Size = new System.Drawing.Size(89, 26);
            this.StatusFilter.TabIndex = 17;
            this.StatusFilter.Text = "Status";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(726, 505);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(231, 27);
            this.textBox1.TabIndex = 16;
            // 
            // DateFromFilter
            // 
            this.DateFromFilter.Location = new System.Drawing.Point(726, 573);
            this.DateFromFilter.Name = "DateFromFilter";
            this.DateFromFilter.Size = new System.Drawing.Size(231, 27);
            this.DateFromFilter.TabIndex = 18;
            // 
            // DateFromFilterLabel
            // 
            this.DateFromFilterLabel.AutoSize = true;
            this.DateFromFilterLabel.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DateFromFilterLabel.ForeColor = System.Drawing.Color.Indigo;
            this.DateFromFilterLabel.Location = new System.Drawing.Point(782, 544);
            this.DateFromFilterLabel.Name = "DateFromFilterLabel";
            this.DateFromFilterLabel.Size = new System.Drawing.Size(135, 26);
            this.DateFromFilterLabel.TabIndex = 19;
            this.DateFromFilterLabel.Text = "Date From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(782, 617);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "Date To";
            // 
            // DateToFilter
            // 
            this.DateToFilter.Location = new System.Drawing.Point(726, 646);
            this.DateToFilter.Name = "DateToFilter";
            this.DateToFilter.Size = new System.Drawing.Size(231, 27);
            this.DateToFilter.TabIndex = 20;
            // 
            // FilterButton
            // 
            this.FilterButton.BackColor = System.Drawing.Color.Yellow;
            this.FilterButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilterButton.ForeColor = System.Drawing.Color.Indigo;
            this.FilterButton.Location = new System.Drawing.Point(560, 610);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(135, 63);
            this.FilterButton.TabIndex = 22;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = false;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(547, 387);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(423, 300);
            this.dataGridView1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(560, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 63);
            this.label3.TabIndex = 24;
            this.label3.Text = "ORDERS FILTER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 460);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(329, 213);
            this.dataGridView2.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(18, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 26);
            this.label4.TabIndex = 27;
            this.label4.Text = "STATISTICS";
            // 
            // ItemsSoldLabel
            // 
            this.ItemsSoldLabel.AutoSize = true;
            this.ItemsSoldLabel.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemsSoldLabel.ForeColor = System.Drawing.Color.Indigo;
            this.ItemsSoldLabel.Location = new System.Drawing.Point(18, 512);
            this.ItemsSoldLabel.Name = "ItemsSoldLabel";
            this.ItemsSoldLabel.Size = new System.Drawing.Size(104, 20);
            this.ItemsSoldLabel.TabIndex = 28;
            this.ItemsSoldLabel.Text = "Items Sold:";
            // 
            // WaitingOrdersLabel
            // 
            this.WaitingOrdersLabel.AutoSize = true;
            this.WaitingOrdersLabel.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WaitingOrdersLabel.ForeColor = System.Drawing.Color.Indigo;
            this.WaitingOrdersLabel.Location = new System.Drawing.Point(18, 549);
            this.WaitingOrdersLabel.Name = "WaitingOrdersLabel";
            this.WaitingOrdersLabel.Size = new System.Drawing.Size(146, 20);
            this.WaitingOrdersLabel.TabIndex = 29;
            this.WaitingOrdersLabel.Text = "Waiting Orders:";
            // 
            // MoneyMadeLabel
            // 
            this.MoneyMadeLabel.AutoSize = true;
            this.MoneyMadeLabel.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MoneyMadeLabel.ForeColor = System.Drawing.Color.Indigo;
            this.MoneyMadeLabel.Location = new System.Drawing.Point(18, 591);
            this.MoneyMadeLabel.Name = "MoneyMadeLabel";
            this.MoneyMadeLabel.Size = new System.Drawing.Size(119, 20);
            this.MoneyMadeLabel.TabIndex = 30;
            this.MoneyMadeLabel.Text = "Money Made:";
            // 
            // BestCustomerLabel
            // 
            this.BestCustomerLabel.AutoSize = true;
            this.BestCustomerLabel.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BestCustomerLabel.ForeColor = System.Drawing.Color.Indigo;
            this.BestCustomerLabel.Location = new System.Drawing.Point(18, 631);
            this.BestCustomerLabel.Name = "BestCustomerLabel";
            this.BestCustomerLabel.Size = new System.Drawing.Size(139, 20);
            this.BestCustomerLabel.TabIndex = 31;
            this.BestCustomerLabel.Text = "Best Customer:";
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(982, 685);
            this.Controls.Add(this.BestCustomerLabel);
            this.Controls.Add(this.MoneyMadeLabel);
            this.Controls.Add(this.WaitingOrdersLabel);
            this.Controls.Add(this.ItemsSoldLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateToFilter);
            this.Controls.Add(this.DateFromFilterLabel);
            this.Controls.Add(this.DateFromFilter);
            this.Controls.Add(this.StatusFilter);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemIDFilter);
            this.Controls.Add(this.CriticalOrdersButton);
            this.Controls.Add(this.OrderList);
            this.Controls.Add(this.ItemsButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CustomerListButton);
            this.Controls.Add(this.EmployeeListButton);
            this.Controls.Add(this.AdminDataTable);
            this.Controls.Add(this.AdminListButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminPage";
            this.Text = "AdminPage";
            this.Load += new System.EventHandler(this.AdminPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AdminDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AdminListButton;
        private System.Windows.Forms.DataGridView AdminDataTable;
        private System.Windows.Forms.Button EmployeeListButton;
        private System.Windows.Forms.Button CustomerListButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ItemsButton;
        private System.Windows.Forms.Button OrderList;
        private System.Windows.Forms.Button CriticalOrdersButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ItemIDFilter;
        private System.Windows.Forms.Label StatusFilter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker DateFromFilter;
        private System.Windows.Forms.Label DateFromFilterLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateToFilter;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ItemsSoldLabel;
        private System.Windows.Forms.Label WaitingOrdersLabel;
        private System.Windows.Forms.Label MoneyMadeLabel;
        private System.Windows.Forms.Label BestCustomerLabel;
    }
}