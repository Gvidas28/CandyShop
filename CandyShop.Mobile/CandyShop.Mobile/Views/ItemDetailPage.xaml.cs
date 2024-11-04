using CandyShop.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CandyShop.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}