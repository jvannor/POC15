using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POC15.Helpers;
using POC15.Services;
using POC15.Views;

namespace POC15
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            InitializeApp();
     
            MainPage = new AppShell();
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();
        }

        protected override void OnStart()
        {
            AppCenter.Start($"android={Secrets.androidAppCenterSecret};ios={Secrets.iOSAppCenterSecret}", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
