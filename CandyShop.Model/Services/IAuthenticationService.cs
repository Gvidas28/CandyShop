using CandyShop.Model.Entities.Requests;
using CandyShop.Model.Entities.Responses;

namespace CandyShop.Model.Services
{
    public interface IAuthenticationService
    {
        LoginResponse Login(LoginRequest request);
        RegisterResponse Register(RegisterRequest request);
        string HashPassword(string password);
    }
}