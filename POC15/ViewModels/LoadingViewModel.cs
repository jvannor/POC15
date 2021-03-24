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
        public LoadingViewModel(IAuthenticationService authentication)
        {
            authenticationService = authentication;
        }

        public async Task OnAppearing()
        {
            var authenticated = await authenticationService.SignIn();
            if (authenticated)
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }

        private IAuthenticationService authenticationService;
    }
}
