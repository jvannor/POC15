using System;
using System.Collections.Generic;
using Xamarin.Forms;
using POC15.Services;
using POC15.Views;
using POC15.ViewModels;


namespace POC15
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            authenticationService = AppContainer.Resolve<IAuthenticationService>();

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await authenticationService.SignOut();
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private IAuthenticationService authenticationService;
    }
}
