namespace CandyShop.Desktop
{
    partial class CustomerPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.ShopItemsButton = new System.Windows.Forms.Button();
            this.ShoppingCartButton = new System.Windows.Forms.Button();
            this.CustomerDataTable = new System.Windows.Forms.DataGridView();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.ViewCommentsButton = new System.Windows.Forms.Button();
            this.ViewDetailsButton = new System.Windows.Forms.Button();
            this.CancelOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 69);
            this.label1.TabIndex = 1;
            this.label1.Text = "Candy Shop";
            // 
            // ShopItemsButton
            // 
            this.ShopItemsButton.BackColor = System.Drawing.Color.Yellow;
            this.ShopItemsButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShopItemsButton.ForeColor = System.Drawing.Color.Indigo;
            this.ShopItemsButton.Location = new System.Drawing.Point(114, 91);
            this.ShopItemsButton.Name = "ShopItemsButton";
            this.ShopItemsButton.Size = new System.Drawing.Size(143, 89);
            this.ShopItemsButton.TabIndex = 7;
            this.ShopItemsButton.Text = "Shop Items";
            this.ShopItemsButton.UseVisualStyleBackColor = false;
            this.ShopItemsButton.Click += new System.EventHandler(this.ShopItemsButton_Click);
            // 
            // ShoppingCartButton
            // 
            this.ShoppingCartButton.BackColor = System.Drawing.Color.Yellow;
            this.ShoppingCartButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShoppingCartButton.ForeColor = System.Drawing.Color.Indigo;
            this.ShoppingCartButton.Location = new System.Drawing.Point(280, 91);
            this.ShoppingCartButton.Name = "ShoppingCartButton";
            this.ShoppingCartButton.Size = new System.Drawing.Size(143, 89);
            this.ShoppingCartButton.TabIndex = 8;
            this.ShoppingCartButton.Text = "Shopping Cart";
            this.ShoppingCartButton.UseVisualStyleBackColor = false;
            this.ShoppingCartButton.Click += new System.EventHandler(this.ShoppingCartButton_Click);
            // 
            // CustomerDataTable
            // 
            this.CustomerDataTable.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.CustomerDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDataTable.Location = new System.Drawing.Point(28, 211);
            this.CustomerDataTable.Name = "CustomerDataTable";
            this.CustomerDataTable.ReadOnly = true;
            this.CustomerDataTable.RowHeadersWidth = 51;
            this.CustomerDataTable.RowTemplate.Height = 29;
            this.CustomerDataTable.Size = new System.Drawing.Size(485, 338);
            this.CustomerDataTable.TabIndex = 9;
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.BackColor = System.Drawing.Color.Yellow;
            this.AddToCartButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddToCartButton.ForeColor = System.Drawing.Color.Indigo;
            this.AddToCartButton.Location = new System.Drawing.Point(176, 555);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(157, 48);
            this.AddToCartButton.TabIndex = 10;
            this.AddToCartButton.Text = "Add To Cart";
            this.AddToCartButton.UseVisualStyleBackColor = false;
            this.AddToCartButton.Visible = false;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // ViewCommentsButton
            // 
            this.ViewCommentsButton.BackColor = System.Drawing.Color.Yellow;
            this.ViewCommentsButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ViewCommentsButton.ForeColor = System.Drawing.Color.Indigo;
            this.ViewCommentsButton.Location = new System.Drawing.Point(261, 609);
            this.ViewCommentsButton.Name = "ViewCommentsButton";
            this.ViewCommentsButton.Size = new System.Drawing.Size(162, 48);
            this.ViewCommentsButton.TabIndex = 11;
            this.ViewCommentsButton.Text = "View Comments";
            this.ViewCommentsButton.UseVisualStyleBackColor = false;
            this.ViewCommentsButton.Click += new System.EventHandler(this.ViewCommentsButton_Click);
            // 
            // ViewDetailsButton
            // 
            this.ViewDetailsButton.BackColor = System.Drawing.Color.Yellow;
            this.ViewDetailsButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ViewDetailsButton.ForeColor = System.Drawing.Color.Indigo;
            this.ViewDetailsButton.Location = new System.Drawing.Point(81, 609);
            this.ViewDetailsButton.Name = "ViewDetailsButton";
            this.ViewDetailsButton.Size = new System.Drawing.Size(162, 48);
            this.ViewDetailsButton.TabIndex = 12;
            this.ViewDetailsButton.Text = "View Details";
            this.ViewDetailsButton.UseVisualStyleBackColor = false;
            this.ViewDetailsButton.Click += new System.EventHandler(this.ViewDetailsButton_Click);
            // 
            // CancelOrderButton
            // 
            this.CancelOrderButton.BackColor = System.Drawing.Color.Yellow;
            this.CancelOrderButton.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CancelOrderButton.ForeColor = System.Drawing.Color.Indigo;
            this.CancelOrderButton.Location = new System.Drawing.Point(176, 555);
            this.CancelOrderButton.Name = "CancelOrderButton";
            this.CancelOrderButton.Size = new System.Drawing.Size(157, 48);
            this.CancelOrderButton.TabIndex = 13;
            this.CancelOrderButton.Text = "Cancel Order";
            this.CancelOrderButton.UseVisualStyleBackColor = false;
            this.CancelOrderButton.Visible = false;
            this.CancelOrderButton.Click += new System.EventHandler(this.CancelOrderButton_Click);
            // 
            // CustomerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(537, 697);
            this.Controls.Add(this.CancelOrderButton);
            this.Controls.Add(this.ViewDetailsButton);
            this.Controls.Add(this.ViewCommentsButton);
            this.Controls.Add(this.AddToCartButton);
            this.Controls.Add(this.CustomerDataTable);
            this.Controls.Add(this.ShoppingCartButton);
            this.Controls.Add(this.ShopItemsButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerPage";
            this.Text = "CustomerPage";
            this.Load += new System.EventHandler(this.CustomerPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShopItemsButton;
        private System.Windows.Forms.Button ShoppingCartButton;
        private System.Windows.Forms.DataGridView CustomerDataTable;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.Button ViewCommentsButton;
        private System.Windows.Forms.Button ViewDetailsButton;
        private System.Windows.Forms.Button CancelOrderButton;
    }
}