using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using POC15.Models;
using POC15.Services;
using POC15.Views;

namespace POC15.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel(INavigationService navigation) : base(navigation)
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await navigationService.GoToRoute($"//{nameof(LoadingPage)}");
        }
    }
}
