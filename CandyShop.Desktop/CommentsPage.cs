using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class CommentsPage : Form
    {
        public int ItemID { get; set; }
        public bool IsReplies { get; set; }
        public int? CommentId { get; set; }
        public int CustomerId { get; set; }

        private readonly ICommentRepository _commentRepository;

        public CommentsPage(
            ICommentRepository commentRepository,
            int itemId,
            bool isReplies,
            int? commentId,
            int customerId
            )
        {
            _commentRepository = commentRepository;
            ItemID = itemId;
            IsReplies = isReplies;
            CommentId = commentId;
            CustomerId = customerId;
            InitializeComponent();
        }

        private void CommentsPage_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while loading comments: {ex}");
            }
        }

        private void ViewRepliesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = CommentDataTable.SelectedCells[0].RowIndex;
                var selectedCommentRow = CommentDataTable.Rows[selectedCell].DataBoundItem as CommentMinimal;
                if (selectedCommentRow is null)
                {
                    MessageBox.Show($"Please select comment you want to view replies of!");
                    return;
                }
                if (!selectedCommentRow.HasReplies)
                {
                    MessageBox.Show($"Selected comment has no replies!");
                    return;
                }

                var repliesPage = new CommentsPage(
                    _commentRepository,
                    ItemID,
                    true,
                    selectedCommentRow.ID,
                    CustomerId
                    );

                repliesPage.FormClosed += (senderForm, eForm) => LoadComments();

                repliesPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to view replies due to {ex}");
            }
        }

        private void DeleteCommentButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = CommentDataTable.SelectedCells[0].RowIndex;
                var selectedCommentRow = CommentDataTable.Rows[selectedCell].DataBoundItem as CommentMinimal;
                if (selectedCommentRow is null)
                {
                    MessageBox.Show($"No comment selected!");
                    return;
                }
                var fullComment = _commentRepository.GetCommentById(selectedCommentRow.ID);
                if (fullComment.CustomerId != CustomerId)
                {
                    MessageBox.Show($"Cannot delete a comment that is not yours!");
                    return;
                }

                _commentRepository.DeleteComment(selectedCommentRow.ID);

                LoadComments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while deleting comment {ex}");
            }
        }

        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            try
            {
                var addCommentPage = new AddCommentPage(
                    _commentRepository,
                    ItemID,
                    false,
                    null,
                    CustomerId
                    );

                addCommentPage.FormClosed += (senderForm, eForm) => LoadComments();

                addCommentPage.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while deleting comment {ex}");
            }
        }

        private void ReplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = CommentDataTable.SelectedCells[0].RowIndex;
                var selectedCommentRow = CommentDataTable.Rows[selectedCell].DataBoundItem as CommentMinimal;
                if (selectedCommentRow is null)
                {
                    MessageBox.Show($"First select a comment you want to reply to!");
                    return;
                }

                var addCommentPage = new AddCommentPage(
                    _commentRepository,
                    ItemID,
                    true,
                    selectedCommentRow.ID,
                    CustomerId
                    );

                addCommentPage.FormClosed += (senderForm, eForm) => LoadComments();

                addCommentPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to reply due to {ex}");
            }
        }

        private void LoadComments()
        {
            if (IsReplies)
                AddCommentButton.Visible = false;

            var comments = _commentRepository.GetCommentsByItemId(ItemID);

            if (IsReplies)
                comments = comments.Where(x => x.CommentId == CommentId).ToList();

            var commentsMinimalList = comments.Select(x => new CommentMinimal
            {
                ID = x.ID,
                CustomerName = x.CustomerName,
                HasReplies = _commentRepository.GetCommentsByItemId(ItemID).Any(c => c.CommentId == x.ID),
                Text = x.Text
            }).ToList();

            CommentDataTable.DataSource = commentsMinimalList;
        }
    }
}