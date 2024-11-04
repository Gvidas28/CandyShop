using CandyShop.Model.Entities.Enums;

namespace CandyShop.Model.Entities.Requests
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}