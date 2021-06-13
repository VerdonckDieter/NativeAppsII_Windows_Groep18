using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

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
            LoginPassword.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }

        private async void LoginUser(object sender, RoutedEventArgs e)
        {
            string email = LoginMail.Text;
            string password = LoginPassword.Password;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                LoginError("empty");
            }
            else
            {
                if (await LoginViewModel.Login(email, password))
                {
                    Frame.Navigate(typeof(Navigation));
                }
                else
                {
                    LoginError("notfound");
                }
            }
        }

        private void NavigateToRegister(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private void LoginError(string type)
        {
            switch (type.ToLower())
            {
                case "empty":
                    LoginMail.Text = string.Empty;
                    LoginMail.Header = "Please enter your e-mail";
                    LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
                    LoginPassword.Password = string.Empty;
                    LoginPassword.Header = "Please enter your password";
                    LoginPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case "notfound":
                    LoginMail.Text = string.Empty;
                    LoginMail.Header = "Could not find user";
                    LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
                    LoginPassword.Password = string.Empty;
                    LoginPassword.Header = "Could not find user";
                    LoginPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                default:
                    break;
            }
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            LoginMail.Header = "E-mail";
            LoginMail.ClearValue(BorderBrushProperty);

            LoginPassword.Header = "Password";
            LoginPassword.ClearValue(BorderBrushProperty);
        }
    }
}
