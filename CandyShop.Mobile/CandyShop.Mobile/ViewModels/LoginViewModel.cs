using CandyShop.Mobile.Models.Enums;
using CandyShop.Mobile.Models.Requests;
using CandyShop.Mobile.Models.Responses;
using CandyShop.Mobile.Services;
using CandyShop.Mobile.Views;
using RestSharp;
using System;
using Xamarin.Forms;

namespace CandyShop.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;

        public Command LoginCommand { get; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            _clientService = DependencyService.Get<IClientService>();
        }

        private async void OnLoginClicked(object obj)
        {
            try
            {
                var loginRequest = new LoginRequest
                {
                    Username = Username,
                    Password = Password,
                    UserType = UserType.Customer
                };

                var loginRes = await _clientService.SendRequestToBackendAsync<LoginRequest, LoginResponse>(loginRequest, "authentication/login", Method.Post);
                if (!loginRes.Success)
                {
                    await Application.Current.MainPage.DisplayAlert("Login failure!", loginRes.ErrorMessage, "OK");
                    return;
                }

                _clientService.Customer = Username;
                _clientService.CustomerId = loginRes.CustomerId;

                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Login failure!", $"Login failed due to {ex.Message}", "OK");
            }
        }
    }
}