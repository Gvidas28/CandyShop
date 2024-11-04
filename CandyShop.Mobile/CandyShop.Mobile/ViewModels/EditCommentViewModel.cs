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
    [QueryProperty(nameof(CommentId), nameof(CommentId))]
    public class EditCommentViewModel : BaseViewModel
    {
        private IClientService _clientService;

        public Comment CommentObject { get; set; } = null;

        private int commentId;
        private string text;

        public Command DeleteCommentCommand { get; }
        public Command UpdateCommentCommand { get; }

        public int Id { get; set; }

        public EditCommentViewModel()
        {
            DeleteCommentCommand = new Command(OnDeleteCommentClicked);
            UpdateCommentCommand = new Command(OnUpdateCommentClicked);
            _clientService = DependencyService.Get<IClientService>();
        }

        private async void OnDeleteCommentClicked(object obj)
        {
            try
            {
                var deleteRes = await _clientService.SendRequestToBackendAsync<bool>("comment/delete", Method.Delete, $"commentId={commentId}");
                if (!deleteRes)
                {
                    await Application.Current.MainPage.DisplayAlert("Comment failure!", $"Failed to delete comment!", "OK");
                    return;
                }

                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Comment failure!", $"Failed to delete comment: {ex.Message}!", "OK");
                return;
            }
        }

        private async void OnUpdateCommentClicked(object obj)
        {
            try
            {
                CommentObject.Text = text;

                var updateRes = await _clientService.SendRequestToBackendAsync<Comment, bool>(CommentObject, "comment/update", Method.Put);
                if (!updateRes)
                {
                    await Application.Current.MainPage.DisplayAlert("Comment failure!", $"Failed to update comment!", "OK");
                    return;
                }

                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Comment failure!", $"Failed to update comment: {ex.Message}!", "OK");
                return;
            }
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public int CommentId
        {
            get
            {
                return commentId;
            }
            set
            {
                commentId = value;
                LoadCommentId(value);
            }
        }

        public async void LoadCommentId(int itemId)
        {
            try
            {
                var comment = await _clientService.SendRequestToBackendAsync<Comment>($"comment/getById", Method.Get, $"commentId={commentId}");
                if (comment is null)
                {
                    await Application.Current.MainPage.DisplayAlert("Item failure!", "Failed to load comment!", "OK");
                    return;
                }

                Id = comment.ID;
                Text = comment.Text;
                CommentObject = comment;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Item failure!", $"Failed to load item details: {ex.Message}!", "OK");
                return;
            }
        }
    }
}