namespace CandyShop.Model.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int? CommentId { get; set; }
        public string CustomerName { get; set; }
        public int ItemId { get; set; }
        public string Text { get; set; }
    }
}