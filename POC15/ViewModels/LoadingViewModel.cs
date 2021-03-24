using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using POC15.Services;
using POC15.Models;
using POC15.Views;

namespace POC15.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        public Command InitializeCommand { get;  }

        public LoadingViewModel(INavigationService navigation, IAuthenticationService authentication) : base(navigation)
        {
            authenticationService = authentication;
            InitializeCommand = new Command(OnInitialize);
        }

        private async void OnInitialize()
        {
            var authenticated = await authenticationService.SignIn();
            if (authenticated)
            {
                await navigationService.GoToRoute($"//{nameof(AboutPage)}");
            }
            else
            {
                await navigationService.GoToRoute($"//{nameof(LoginPage)}");
            }
        }

        private IAuthenticationService authenticationService;
    }
}
