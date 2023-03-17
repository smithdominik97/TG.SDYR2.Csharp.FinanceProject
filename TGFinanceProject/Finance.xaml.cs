using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
    public sealed partial class Finance : Page
    {
        ArrayList transactions = new ArrayList();
        ObservableCollection<String> transactionList = new ObservableCollection<string>();

        Account account = new Account();//Instantiate Account object called account
        Regex regexNumbers = new Regex(@"^\d+(\.\d{1,2})?$"); //Set up regex to only accept numbers and decimal values. - Validation uses.
        Regex regexLetters = new Regex("^[A-Za-z ]+$"); //Set up regex to only accept letters - Validation uses.

        public Finance()
        {
            this.InitializeComponent();

            
            account.Balance = 250.34;
            balanceValueText.Text = "£" + account.Balance;
        }

        //Deposit button
        private async void depositValueBTN(object sender, RoutedEventArgs e)
        {
            //Title inserted into deposit will be stored within title variable.
            string title = depositTitleText.Text;
            //Amount inserted into deposit will be stored within value variable
            string value = depositValueText.Text;
            //Get the time and date currently.
            DateTime date = DateTime.Now;
            //Convert the date and time to a string
            String dateConvertToString = date.ToString("MM/dd/yyyy HH:mm");


            // Check for valid input
            if (string.IsNullOrWhiteSpace(value))
            {
                // Display an error message for blank space
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Deposit Error - Value",
                    Content = "Invalid value.\nPlease include a value.\nExamples: 5, 5.50, 50, 500.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else if (string.IsNullOrWhiteSpace(title)){
                // Display an error message for blank space
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Deposit Error - Title",
                    Content = "Invalid Title.\nPlease include a Title.\nExamples: Bills, Holiday, Medical.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else if(!regexNumbers.IsMatch(value)){
                // Display an error message for invalid input - Anything that isnt a number or decimal value.
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Deposit Error - Value",
                    Content = "Invalid value.\nPlease include a valid number with up to 2 decimal places.\nExamples: 5, 5.50, 50, 500.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else if (!regexLetters.IsMatch(title)){
                //Display an error message for invalid input - Anything that isnt a letter.
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Deposit Error - Title",
                    Content = "Invalid title.\nPlease include a valid title with no numbers.\nExamples: Bills, Holiday, Medical.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else {
                //Instantiate object of Transactions.
                Transactions thisTransaction = new Transactions();
                thisTransaction.Title = title;
                thisTransaction.Amount = Convert.ToDouble(value);
                thisTransaction.DateTimeValue = dateConvertToString;

                //Successful validation of values.
                account.Deposit(Convert.ToDouble(value));
                balanceValueText.Text = "£" + account.Balance.ToString("0.00");
            }
        }

        //Withdraw button
        private async void withdrawValueBTN(object sender, RoutedEventArgs e)
        {
            //Title inserted into deposit will be stored within title variable.
            string title = withdrawTitleText.Text;
            //Amount inserted into deposit will be stored within value variable
            string value = withdrawValueText.Text;
            //Get the time and date currently.
            DateTime date = DateTime.Now;
            //Convert the date and time to a string
            String dateConvertToString = date.ToString("MM/dd/yyyy HH:mm");

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
                //Error message END
            }
            else if (string.IsNullOrWhiteSpace(title))
            {
                // Display an error message for blank space
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Withdraw Error - Title",
                    Content = "Invalid Title.\nPlease include a Title.\nExamples: Bills, Holiday, Medical.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else if (!regexNumbers.IsMatch(value))
            {
                // Display an error message for invalid input - Anything that isnt a number or decimal value.
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Withdraw Error",
                    Content = "Invalid value.\nPlease include a valid number with up to 2 decimal places.\nExamples: 5, 5.50, 50, 500.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else if (!regexLetters.IsMatch(title))
            {
                //Display an error message for invalid input - Anything that isnt a letter.
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Withdraw Error - Title",
                    Content = "Invalid title.\nPlease include a valid title with no numbers.\nExamples: Bills, Holiday, Medical.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else if (account.Balance < Convert.ToDouble(value))
            {
                // Display an error message for not enough funds.
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Withdraw Error",
                    Content = "Insufficient Funds.\nPlease make sure you have enough money to withdraw.",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
                //Error message END
            }
            else
            {
                //Instantiate object of Transactions.
                Transactions thisTransaction = new Transactions();
                thisTransaction.Title = title;
                thisTransaction.Amount = Convert.ToDouble(value);
                thisTransaction.DateTimeValue = dateConvertToString;

                //Successful validation of values.
                account.Withdraw(Convert.ToDouble(value));
                balanceValueText.Text = "£" + account.Balance.ToString("0.00");
            }
        }
    }
}
