using CandyShop.Model.Entities.Enums;

namespace CandyShop.Model.Entities.Responses
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int? CustomerId { get; set; }
    }
}