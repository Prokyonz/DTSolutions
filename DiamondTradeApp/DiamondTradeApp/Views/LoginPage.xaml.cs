using DiamondTradeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DiamondTradeApp.Services;
using Xamarin.Essentials;



namespace DiamondTradeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private UserMasterRepository _userMasterRepository;

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == null)
                {
                    await DisplayAlert("Error", "Please enter your Username.", "OK");
                    return;
                }
                if (txtPassword.Text == null)
                {
                    await DisplayAlert("Error", "Please enter your Password.", "OK");
                    return;
                }
                _userMasterRepository = new UserMasterRepository();

                string userID = _userMasterRepository.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                if (userID != null)
                {
                    SaveToLocalStorage("userId_key", userID);
                    SaveToLocalStorage("userName_key", txtUserName.Text.ToString());
                    if (chkRememberMe.IsChecked)
                    {
                        SaveToLocalStorage("rememberMe_Key", "true");
                    }
                    else
                    {
                        SaveToLocalStorage("rememberMe_Key", "false");
                    }
                    await Shell.Current.GoToAsync("//HomePage");
                }
                else
                {
                    await DisplayAlert("Error", "Invalid Username or Password, Please Try Again!", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void SaveToLocalStorage(string key, string value)
        {
            Preferences.Set(key, value);
        }
    }
}