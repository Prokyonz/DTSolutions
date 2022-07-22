using DiamondTradeApp.ViewModels;
using EFCore.SQL.Repository;
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



namespace DiamondTradeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
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

                SqlConnection sqlConnection = new SqlConnection(@"Data Source=103.83.81.7;Initial Catalog=karmajew_DiamondTradingLive;Persist Security Info=True;User ID=karmajew_DiamondTrading;Password=DT@123456;");

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("Select * from UserMaster", sqlConnection));
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);

                await Shell.Current.GoToAsync("//AboutPage");
            }
            catch (Exception ex)
            {

                throw;
            }            
        }
    }
}