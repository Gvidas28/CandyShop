namespace CandyShop.Desktop
{
    partial class CommentsPage
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
            this.CommentDataTable = new System.Windows.Forms.DataGridView();
            this.ViewRepliesButton = new System.Windows.Forms.Button();
            this.DeleteCommentButton = new System.Windows.Forms.Button();
            this.ReplyButton = new System.Windows.Forms.Button();
            this.AddCommentButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CommentDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(136, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Replies";
            // 
            // CommentDataTable
            // 
            this.CommentDataTable.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.CommentDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CommentDataTable.Location = new System.Drawing.Point(12, 69);
            this.CommentDataTable.Name = "CommentDataTable";
            this.CommentDataTable.ReadOnly = true;
            this.CommentDataTable.RowHeadersWidth = 51;
            this.CommentDataTable.RowTemplate.Height = 29;
            this.CommentDataTable.Size = new System.Drawing.Size(371, 300);
            this.CommentDataTable.TabIndex = 10;
            // 
            // ViewRepliesButton
            // 
            this.ViewRepliesButton.BackColor = System.Drawing.Color.Yellow;
            this.ViewRepliesButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ViewRepliesButton.ForeColor = System.Drawing.Color.Indigo;
            this.ViewRepliesButton.Location = new System.Drawing.Point(56, 375);
            this.ViewRepliesButton.Name = "ViewRepliesButton";
            this.ViewRepliesButton.Size = new System.Drawing.Size(119, 63);
            this.ViewRepliesButton.TabIndex = 11;
            this.ViewRepliesButton.Text = "View Replies";
            this.ViewRepliesButton.UseVisualStyleBackColor = false;
            this.ViewRepliesButton.Click += new System.EventHandler(this.ViewRepliesButton_Click);
            // 
            // DeleteCommentButton
            // 
            this.DeleteCommentButton.BackColor = System.Drawing.Color.Yellow;
            this.DeleteCommentButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteCommentButton.ForeColor = System.Drawing.Color.Indigo;
            this.DeleteCommentButton.Location = new System.Drawing.Point(193, 375);
            this.DeleteCommentButton.Name = "DeleteCommentButton";
            this.DeleteCommentButton.Size = new System.Drawing.Size(135, 63);
            this.DeleteCommentButton.TabIndex = 12;
            this.DeleteCommentButton.Text = "Delete Comment";
            this.DeleteCommentButton.UseVisualStyleBackColor = false;
            this.DeleteCommentButton.Click += new System.EventHandler(this.DeleteCommentButton_Click);
            // 
            // ReplyButton
            // 
            this.ReplyButton.BackColor = System.Drawing.Color.Yellow;
            this.ReplyButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReplyButton.ForeColor = System.Drawing.Color.Indigo;
            this.ReplyButton.Location = new System.Drawing.Point(56, 444);
            this.ReplyButton.Name = "ReplyButton";
            this.ReplyButton.Size = new System.Drawing.Size(119, 63);
            this.ReplyButton.TabIndex = 13;
            this.ReplyButton.Text = "Reply";
            this.ReplyButton.UseVisualStyleBackColor = false;
            this.ReplyButton.Click += new System.EventHandler(this.ReplyButton_Click);
            // 
            // AddCommentButton
            // 
            this.AddCommentButton.BackColor = System.Drawing.Color.Yellow;
            this.AddCommentButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddCommentButton.ForeColor = System.Drawing.Color.Indigo;
            this.AddCommentButton.Location = new System.Drawing.Point(193, 444);
            this.AddCommentButton.Name = "AddCommentButton";
            this.AddCommentButton.Size = new System.Drawing.Size(135, 63);
            this.AddCommentButton.TabIndex = 14;
            this.AddCommentButton.Text = "Add comment";
            this.AddCommentButton.UseVisualStyleBackColor = false;
            this.AddCommentButton.Click += new System.EventHandler(this.AddCommentButton_Click);
            // 
            // CommentsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(395, 520);
            this.Controls.Add(this.AddCommentButton);
            this.Controls.Add(this.ReplyButton);
            this.Controls.Add(this.DeleteCommentButton);
            this.Controls.Add(this.ViewRepliesButton);
            this.Controls.Add(this.CommentDataTable);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommentsPage";
            this.Text = "CommentsPage";
            this.Load += new System.EventHandler(this.CommentsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CommentDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CommentDataTable;
        private System.Windows.Forms.Button ViewRepliesButton;
        private System.Windows.Forms.Button DeleteCommentButton;
        private System.Windows.Forms.Button ReplyButton;
        private System.Windows.Forms.Button AddCommentButton;
    }
}