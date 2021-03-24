using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using POC15.Models;
using POC15.Services;

namespace POC15.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}