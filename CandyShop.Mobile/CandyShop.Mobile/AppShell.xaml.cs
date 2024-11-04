using CandyShop.Mobile.ViewModels;
using CandyShop.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CandyShop.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CommentsPage), typeof(CommentsPage)); 
            Routing.RegisterRoute(nameof(EditCommentPage), typeof(EditCommentPage)); 
            Routing.RegisterRoute(nameof(AddCommentPage), typeof(AddCommentPage)); 
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
