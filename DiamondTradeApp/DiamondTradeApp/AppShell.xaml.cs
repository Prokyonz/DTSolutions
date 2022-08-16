using DiamondTradeApp.ViewModels;
using DiamondTradeApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace DiamondTradeApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private string username;
        public string LoggedInUserName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(LoggedInUserName)); // Notify that there was a change on this property
            }
        }
        public AppShell()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("username_key"))
            {
                username = Preferences.Get("username_key", "");
            }

            Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
