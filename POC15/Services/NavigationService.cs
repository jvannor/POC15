using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using POC15.ViewModels;

namespace POC15.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoToRoute(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
