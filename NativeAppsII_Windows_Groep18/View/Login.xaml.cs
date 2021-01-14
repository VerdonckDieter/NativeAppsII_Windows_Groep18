using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public LoginViewModel LoginViewModel;
        public Login()
        {
            InitializeComponent();
            LoginViewModel = new LoginViewModel();
            LoginMail.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }

        private async void LoginUser(object sender, RoutedEventArgs e)
        {
            string mail = LoginMail.Text;
            try
            {
                await LoginViewModel.Login(mail);
                if (LoginViewModel.Succes)
                {
                    Frame.Navigate(typeof(Navigation));
                }
                else
                {
                    LoginError();
                }
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog();

                dialog.CloseButtonText = "Close";
                dialog.ShowAsync();
            }

        }

        private void NavigateToRegister(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private void LoginError()
        {
            LoginMail.Text = string.Empty;
            LoginMail.Header = "Could not find user";
            LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            LoginMail.Header = "E-mail";
            LoginMail.ClearValue(TextBox.BorderBrushProperty);
        }
    }
}
