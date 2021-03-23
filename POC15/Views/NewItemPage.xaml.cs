using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POC15.Models;
using POC15.ViewModels;

namespace POC15.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = viewModel = AppContainer.Resolve<NewItemViewModel>();
        }

        private NewItemViewModel viewModel;
    }
}