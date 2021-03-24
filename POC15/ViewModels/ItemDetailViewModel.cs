using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using POC15.Models;
using POC15.Services;

namespace POC15.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
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

        public ItemDetailViewModel(INavigationService navigation, IDataStore<Item> store) : base(navigation)
        {
            dataStore = store;
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await dataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private IDataStore<Item> dataStore;
        private string itemId;
        private string text;
        private string description;
    }
}
