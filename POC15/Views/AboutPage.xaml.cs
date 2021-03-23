using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POC15.ViewModels;

namespace POC15.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = AppContainer.Resolve<AboutViewModel>();
        }

        private AboutViewModel viewModel;
    }
}