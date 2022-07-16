using DiamondTradeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiamondTradeApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string oldPassword;
        private string newPassword;
        private string confirmPassword;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(oldPassword)
                && !String.IsNullOrWhiteSpace(newPassword)
                && !String.IsNullOrWhiteSpace(confirmPassword);
        }

        public string OldPassword
        {
            get => oldPassword;
            set => SetProperty(ref oldPassword, value);
        }

        public string NewPassword
        {
            get => newPassword;
            set => SetProperty(ref newPassword, value);
        }

        public string ConfirmPassword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Console.WriteLine(OldPassword + NewPassword + ConfirmPassword);
            //Item newItem = new Item()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Text = Text,
            //    Description = Description
            //};

            //await DataStore.AddItemAsync(newItem);

            //// This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }
    }
}
