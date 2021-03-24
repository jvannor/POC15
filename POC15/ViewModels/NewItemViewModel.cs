using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using POC15.Services;
using POC15.Models;

namespace POC15.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

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

        public NewItemViewModel(INavigationService navigation, IDataStore<Item> store) : base(navigation)
        {
            dataStore = store;

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await navigationService.GoToRoute("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await dataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await navigationService.GoToRoute("..");
        }

        private IDataStore<Item> dataStore;
        private string text;
        private string description;
    }
}
