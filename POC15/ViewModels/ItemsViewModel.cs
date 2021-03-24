using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using POC15.Models;
using POC15.Services;
using POC15.Views;
using System.Collections.Generic;

namespace POC15.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }

        public Command AddItemCommand { get; }

        public Command InitializeCommand { get; }

        public Command<Item> ItemTapped { get; }

        public ObservableCollection<Item> Items { get; }

        public ItemsViewModel(INavigationService navigation, IDataStore<Item> store) : base(navigation) 
        {
            dataStore = store;

            Title = "Browse";
            Items = new ObservableCollection<Item>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Item>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            InitializeCommand = new Command(OnInitialize);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await dataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
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
            await navigationService.GoToRoute(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await navigationService.GoToRoute($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        private async void OnInitialize()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        private IDataStore<Item> dataStore;
        private Item _selectedItem;
    }
}