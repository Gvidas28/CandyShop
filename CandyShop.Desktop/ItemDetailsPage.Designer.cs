namespace CandyShop.Desktop
{
    partial class ItemDetailsPage
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
            this.ItemName = new System.Windows.Forms.Label();
            this.ItemImage = new System.Windows.Forms.PictureBox();
            this.ItemDescription = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemName
            // 
            this.ItemName.AutoSize = true;
            this.ItemName.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemName.ForeColor = System.Drawing.Color.Indigo;
            this.ItemName.Location = new System.Drawing.Point(143, 21);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(139, 26);
            this.ItemName.TabIndex = 1;
            this.ItemName.Text = "Item Name";
            // 
            // ItemImage
            // 
            this.ItemImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ItemImage.Location = new System.Drawing.Point(86, 60);
            this.ItemImage.Name = "ItemImage";
            this.ItemImage.Size = new System.Drawing.Size(270, 207);
            this.ItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ItemImage.TabIndex = 2;
            this.ItemImage.TabStop = false;
            // 
            // ItemDescription
            // 
            this.ItemDescription.AutoSize = true;
            this.ItemDescription.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemDescription.ForeColor = System.Drawing.Color.Indigo;
            this.ItemDescription.Location = new System.Drawing.Point(152, 290);
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.Size = new System.Drawing.Size(154, 20);
            this.ItemDescription.TabIndex = 3;
            this.ItemDescription.Text = "Item Description";
            this.ItemDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Price.ForeColor = System.Drawing.Color.Indigo;
            this.Price.Location = new System.Drawing.Point(193, 344);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(54, 20);
            this.Price.TabIndex = 4;
            this.Price.Text = "Price";
            this.Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Quantity.ForeColor = System.Drawing.Color.Indigo;
            this.Quantity.Location = new System.Drawing.Point(176, 395);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(88, 20);
            this.Quantity.TabIndex = 5;
            this.Quantity.Text = "Quantity";
            this.Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(446, 450);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.ItemDescription);
            this.Controls.Add(this.ItemImage);
            this.Controls.Add(this.ItemName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemDetailsPage";
            this.Text = "ItemDetailsPage";
            this.Load += new System.EventHandler(this.ItemDetailsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemName;
        private System.Windows.Forms.PictureBox ItemImage;
        private System.Windows.Forms.Label ItemDescription;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Quantity;
    }
}