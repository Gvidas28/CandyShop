namespace CandyShop.Model.Entities
{
    public class CommentMinimal
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public bool HasReplies { get; set; }
        public string Text { get; set; }
    }
}