using CandyShop.Mobile.Services;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace CandyShop.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IClientService, ClientService>();
            MainPage = new AppShell();
            Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}