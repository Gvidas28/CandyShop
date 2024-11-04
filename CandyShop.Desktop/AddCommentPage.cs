using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class AddCommentPage : Form
    {
        public int ItemId { get; set; }
        public bool IsReply { get; set; }
        public int? CommentId { get; set; }
        public int CustomerId { get; set; }

        private readonly ICommentRepository _comentRepository;

        public AddCommentPage(
            ICommentRepository commentRepository,
            int itemId,
            bool isReply,
            int? commentId,
            int customerId
            )
        {
            _comentRepository = commentRepository;
            ItemId = itemId;
            IsReply = isReply;
            CommentId = commentId;
            CustomerId = customerId;
            InitializeComponent();
        }

        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CommentTextBox.Text))
                {
                    MessageBox.Show($"Comment or reply cannot be empty");
                    return;
                }

                var comment = new Comment
                {
                    CustomerId = CustomerId,
                    ItemId = ItemId,
                    CommentId = IsReply ? CommentId : null,
                    Text = CommentTextBox.Text
                };

                _comentRepository.AddComment(comment);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while adding comment {ex}");
            }
        }
    }
}