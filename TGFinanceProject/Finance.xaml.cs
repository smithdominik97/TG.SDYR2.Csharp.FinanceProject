using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TGFinanceProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Finance : Page
    {
        Account account = new Account();//Instantiate Account object called account
        Regex regex = new Regex(@"^\d+(\.\d{1,2})?$"); //Set up regex to only accept numbers and decimal values. - Validation uses.

        public Finance()
        {
            this.InitializeComponent();

            
            account.Balance = 250.34;
            balanceValueText.Text = "£" + account.Balance;
        }

        //Deposit button
        private async void depositValueBTN(object sender, RoutedEventArgs e)
        {
            string value = depositValueText.Text;

            // Check for valid input
            if (string.IsNullOrWhiteSpace(value))
            {
                // Display an error message for blank space
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Deposit Error",
                    Content = "Invalid value.\nPlease include a value.\nExamples: 5, 5.50, 50, 500.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
            }else if(!regex.IsMatch(value)){
                // Display an error message for invalid input - Anything that isnt a number or decimal value.
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Deposit Error",
                    Content = "Invalid value.\nPlease include a valid number with up to 2 decimal places.\nExamples: 5, 5.50, 50, 500.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                } else {
                    account.Deposit(Convert.ToDouble(value));
                    balanceValueText.Text = "£" + account.Balance.ToString("0.00");
                }
        }

        //Withdraw button
        private async void withdrawValueBTN(object sender, RoutedEventArgs e)
        {
            string value = withdrawValueText.Text;
            if (string.IsNullOrWhiteSpace(value))
            {
                // Display an error message for blank space
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Withdraw Error",
                    Content = "Invalid value.\nPlease include a value.\nExamples: 5, 5.50, 50, 500.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
            }else if (!regex.IsMatch(value)){
                // Display an error message for invalid input - Anything that isnt a number or decimal value.
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Deposit Error",
                    Content = "Invalid value.\nPlease include a valid number with up to 2 decimal places.\nExamples: 5, 5.50, 50, 500.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
            }else{
                account.Withdraw(Convert.ToDouble(value));
                balanceValueText.Text = "£" + account.Balance.ToString("0.00");
            }
        }
    }
}
