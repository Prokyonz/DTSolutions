using DiamondTradeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DiamondTradeApp.Views
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