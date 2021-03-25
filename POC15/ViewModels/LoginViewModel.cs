using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using POC15.Models;
using POC15.Services;
using POC15.Views;

namespace POC15.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command CheckSignInStatusCommand { get; }

        public Command LoginCommand { get; }

        public LoginViewModel(INavigationService navigation, IAuthenticationService authentication) : base(navigation)
        {
            CheckSignInStatusCommand = new Command(CheckSignInStatus);
            LoginCommand = new Command(OnLoginClicked);
            authenticationService = authentication;
        }

        private async void CheckSignInStatus()
        {
            var result = await authenticationService.IsSignedIn();
            if (result)
            {
                await navigationService.GoToRoute("//AboutPage");
            }
        }
        private async void OnLoginClicked()
        {
            IsBusy = true;
            var result = await authenticationService.SignIn();
            if (result)
            {
                await navigationService.GoToRoute("//AboutPage");
            }
            IsBusy = false;
        }

        private IAuthenticationService authenticationService;
    }
}
