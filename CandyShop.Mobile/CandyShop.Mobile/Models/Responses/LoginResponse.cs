namespace CandyShop.Mobile.Models.Responses
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int? CustomerId { get; set; }
    }
}