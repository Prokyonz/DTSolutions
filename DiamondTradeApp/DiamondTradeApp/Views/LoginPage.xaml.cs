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
        private readonly UserMasterRepository _userMasterRepository;

        public LoginPage()
        {
            //check if user already logg-in?
            if (Preferences.ContainsKey("username_key"))
            {
                var savedUsername = Preferences.Get("username_key", ""); 
                if (savedUsername != null)
                {
                    //logged-in
                    Shell.Current.GoToAsync("//HomePage");
                }
            }
            InitializeComponent();
            _userMasterRepository = new UserMasterRepository();
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
                if(txtPassword.Text == null)
                {
                    await DisplayAlert("Error", "Please enter your Password.", "OK");
                    return;
                }

                bool isLogin = _userMasterRepository.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (isLogin)
                {
                    if (chkRememberMe.IsChecked)
                    {
                        RememberMe(txtUserName.Text.Trim());
                    }
                    AppShell appShell = new AppShell();
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

        private void RememberMe(string username)
        {
            if (!Preferences.ContainsKey("username_key"))
            {
                Preferences.Set("username_key", username);
            }
        }
    }
}