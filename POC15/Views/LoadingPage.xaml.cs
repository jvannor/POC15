﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POC15.ViewModels;

namespace POC15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
            BindingContext = viewModel = AppContainer.Resolve<LoadingViewModel>();
        }

        protected override async void OnAppearing()
        {
            await viewModel.OnAppearing();
            base.OnAppearing();
        }

        private LoadingViewModel viewModel;
    }
}