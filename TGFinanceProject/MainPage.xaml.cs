using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TGFinanceProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Log in verification
        private async void ButtonLogin(object sender, RoutedEventArgs e)
        {
            // Get the input values from the text boxes
            string username = idText.Text;
            string password = passwordText.Password;

            // Check if the login details are correct
            if (username == "tg" && password == "tg")
            {
                // Navigate to the main page of the application
                Frame.Navigate(typeof(Finance));
            }
            else
            {
                // Display an error message
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Login Error",
                    Content = "Invalid username or password",
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
            }
        }
    }
}
