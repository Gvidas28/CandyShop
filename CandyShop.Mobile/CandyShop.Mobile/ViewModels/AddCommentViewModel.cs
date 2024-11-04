using CandyShop.Mobile.Models;
using CandyShop.Mobile.Services;
using CandyShop.Mobile.Views;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CandyShop.Mobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class AddCommentViewModel : BaseViewModel
    {
        private IClientService _clientService;

        public Comment CommentObject { get; set; } = null;

        private int itemId;
        private string text;

        public Command AddCommentCommand { get; }

        public int Id { get; set; }

        public AddCommentViewModel()
        {
            AddCommentCommand = new Command(OnAddCommentClicked);
            _clientService = DependencyService.Get<IClientService>();
        }

        private async void OnAddCommentClicked(object obj)
        {
            try
            {
                var newComment = new Comment
                {
                    ID = 0,
                    ItemId = itemId,
                    CustomerId = _clientService.CustomerId.Value,
                    Text = text,
                    CustomerName = "any"
                };

                var addRes = await _clientService.SendRequestToBackendAsync<Comment, bool>(newComment, "comment/add", Method.Post);
                if (!addRes)
                {
                    await Application.Current.MainPage.DisplayAlert("Comment failure!", $"Failed to add comment!", "OK");
                    return;
                }

                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Comment failure!", $"Failed to add comment: {ex.Message}!", "OK");
                return;
            }
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
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
            }
        }
    }
}