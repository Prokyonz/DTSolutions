using DiamondTradeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DiamondTradeApp.Services;

namespace DiamondTradeApp.Views
{
    public partial class ChangePasswordPage : ContentPage
    {
        private readonly UserMasterRepository _userMasterRepository;
        public ChangePasswordPage()
        {
            InitializeComponent();
            _userMasterRepository = new UserMasterRepository();
        }

        private async void btnChangePass_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(txtNewPassword.Text == null || txtOldPassword.Text == null || txtConfPassword == null)
                {
                    return;
                }

                if(txtNewPassword.Text != txtConfPassword.Text)
                {
                    return;
                }

                bool isUpdated = _userMasterRepository.ChangePassword("Demouser",
                    txtOldPassword.Text, txtNewPassword.Text);

                if (isUpdated)
                {
                    await Shell.Current.GoToAsync("//HomePage");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}