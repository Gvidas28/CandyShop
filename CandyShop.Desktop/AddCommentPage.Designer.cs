namespace CandyShop.Desktop
{
    partial class AddCommentPage
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
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.AddCommentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add comment/reply";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CommentTextBox.Location = new System.Drawing.Point(51, 117);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(231, 27);
            this.CommentTextBox.TabIndex = 7;
            // 
            // AddCommentButton
            // 
            this.AddCommentButton.BackColor = System.Drawing.Color.Yellow;
            this.AddCommentButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddCommentButton.ForeColor = System.Drawing.Color.Indigo;
            this.AddCommentButton.Location = new System.Drawing.Point(88, 187);
            this.AddCommentButton.Name = "AddCommentButton";
            this.AddCommentButton.Size = new System.Drawing.Size(135, 63);
            this.AddCommentButton.TabIndex = 13;
            this.AddCommentButton.Text = "Add comment";
            this.AddCommentButton.UseVisualStyleBackColor = false;
            this.AddCommentButton.Click += new System.EventHandler(this.AddCommentButton_Click);
            // 
            // AddCommentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(317, 298);
            this.Controls.Add(this.AddCommentButton);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCommentPage";
            this.Text = "AddCommentPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Button AddCommentButton;
    }
}