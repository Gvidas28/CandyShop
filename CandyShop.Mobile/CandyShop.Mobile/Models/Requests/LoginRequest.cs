using CandyShop.Mobile.Models.Enums;

namespace CandyShop.Mobile.Models.Requests
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}