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



namespace DiamondTradeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly UserMasterRepository _userMasterRepository;

        public LoginPage()
        {
            _userMasterRepository = new UserMasterRepository();
            //InitializeComponent();
            //this.BindingContext = new LoginViewModel();
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login", "OK");
            InitializeComponent();


            //txtUserName.Completed += (object sender, EventArgs e) =>
            //{
            //    txtUserName.Focus();
            //};

            //txtPassword.Completed += (object sender, EventArgs e) =>
            //{
            //    vm.LoginCommand.Execute(null);
            //};
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == String.Empty || txtPassword.Text == null)
                {
                    return;
                }


                bool isLogin = _userMasterRepository.Login(txtUserName.Text, txtPassword.Text);
                if (isLogin)
                {
                    await Shell.Current.GoToAsync("//HomePage");
                }
                else
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}