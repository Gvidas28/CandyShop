using CandyShop.Mobile.Models;
using CandyShop.Mobile.Services;
using CandyShop.Mobile.Views;
using RestSharp;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace CandyShop.Mobile.ViewModels
{

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private IClientService _clientService;

        private int itemId;
        private string text;
        private string description;
        private string quantity;
        private string price;
        private string image;

        public Command ViewCommentsCommand { get; }

        public int Id { get; set; }

        public ItemDetailViewModel()
        {
            ViewCommentsCommand = new Command(OnViewCommentsClicked);
            _clientService = DependencyService.Get<IClientService>();
        }

        private async void OnViewCommentsClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(CommentsPage)}?{nameof(CommentsViewModel.CommentItemId)}={itemId}");
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public string Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var itemDetails = await _clientService.SendRequestToBackendAsync<Item>($"item/details", Method.Get, $"id={itemId}");
                if (itemDetails is null)
                {
                    await Application.Current.MainPage.DisplayAlert("Item failure!", "Failed to load item details!", "OK");
                    return;
                }

                Id = itemDetails.ID;
                Text = itemDetails.Name;
                Description = itemDetails.Description;
                Price = itemDetails.Price.ToString();
                Quantity = itemDetails.Quantity.ToString();
                Image = itemDetails.Image;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Item failure!", $"Failed to load item details: {ex.Message}!", "OK");
                return;
            }
        }
    }
}
