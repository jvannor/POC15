using POC15.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace POC15.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}