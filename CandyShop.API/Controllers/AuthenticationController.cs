using CandyShop.Model.Entities.Requests;
using CandyShop.Model.Entities.Responses;
using CandyShop.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace CandyShop.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IAuthenticationService authenticationService
            )
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public LoginResponse Login([FromBody]LoginRequest request) => _authenticationService.Login(request);
    }
}