using CandyShop.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CandyShop.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCommentPage : ContentPage
    {
        public AddCommentPage()
        {
            InitializeComponent();
            BindingContext = new AddCommentViewModel();
        }
    }
}