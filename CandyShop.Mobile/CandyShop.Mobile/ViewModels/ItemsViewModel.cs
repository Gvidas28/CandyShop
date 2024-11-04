using CandyShop.Mobile.Models;
using CandyShop.Mobile.Services;
using CandyShop.Mobile.Views;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CandyShop.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;
        private readonly IClientService _clientService;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            _clientService = DependencyService.Get<IClientService>();

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await _clientService.SendRequestToBackendAsync<List<Item>>("item/list", Method.Get);
                if (items?.Any() is false)
                {
                    await Application.Current.MainPage.DisplayAlert("Item failure!", "No candy available for sale right now!", "OK");
                    return;
                }

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Item failure!", $"Error occurred while loading candy: {ex.Message}!", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.ID}");
        }
    }
}