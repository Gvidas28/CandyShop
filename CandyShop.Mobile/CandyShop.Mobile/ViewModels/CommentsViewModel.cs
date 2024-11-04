using CandyShop.Mobile.Models;
using CandyShop.Mobile.Services;
using CandyShop.Mobile.Views;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CandyShop.Mobile.ViewModels
{

    [QueryProperty(nameof(CommentItemId), nameof(CommentItemId))]
    public class CommentsViewModel : BaseViewModel
    {
        private Comment _selectedComment;
        private int commentItemId;

        private readonly IClientService _clientService;

        public ObservableCollection<Comment> Comments { get; }
        public Command LoadItemsCommand { get; }
        public Command AddCommentCommand { get; }
        public Command<Comment> CommentTapped { get; }

        public CommentsViewModel()
        {
            Comments = new ObservableCollection<Comment>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCommentsCommand());
            CommentTapped = new Command<Comment>(OnCommentSelected);
            AddCommentCommand = new Command(OnAddCommentClicked);
            _clientService = DependencyService.Get<IClientService>();
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedComment = null;
        }

        public Comment SelectedComment
        {
            get => _selectedComment;
            set
            {
                SetProperty(ref _selectedComment, value);
            }
        }


        async void OnAddCommentClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(AddCommentPage)}?{nameof(AddCommentViewModel.ItemId)}={commentItemId}");
        }

        async void OnCommentSelected(Comment comment)
        {
            if (comment == null)
                return;

            if (comment.CustomerName != _clientService.Customer)
                return; 

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(EditCommentPage)}?{nameof(EditCommentViewModel.CommentId)}={comment.ID}");
        }

        public int CommentItemId
        {
            get
            {
                return commentItemId;
            }
            set
            {
                commentItemId = value;
            }
        }

        async Task ExecuteLoadCommentsCommand()
        {
            IsBusy = true;

            try
            {
                Comments.Clear();

                var comments = await _clientService.SendRequestToBackendAsync<List<Comment>>("comment/listByItem", Method.Get, $"itemId={commentItemId}");
                if (comments?.Any() is false)
                {
                    await Application.Current.MainPage.DisplayAlert("No comments!", "This item has no comments!", "OK");
                    return;
                }

                foreach (var comment in comments)
                {
                    Comments.Add(comment);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Comment failure!", $"Error occurred while loading comments: {ex.Message}!", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}