using POC15.Services;
using POC15.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POC15
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
