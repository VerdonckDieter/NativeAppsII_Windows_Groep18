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
        }
        private void LoginEnterKey(object sender, KeyRoutedEventArgs e)
        {
            LoginUser();
        }


        private void LoginClick(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }

        private async void LoginUser()
        {
            if (String.IsNullOrEmpty(LoginMail.Text))
            {
                LoginError(true);
            }
            else
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
                        LoginError(false);
                    }
                }
                catch (Exception ex)
                {
                    var dialog = new ContentDialog
                    {
                        Title = ex.Message,
                        CloseButtonText = "Close"
                    };
                    await dialog.ShowAsync();
                }
            }  
        }

        private void NavigateToRegister(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private void LoginError(bool empty)
        {
            switch (empty)
            {
                case true:
                    LoginMail.Text = string.Empty;
                    LoginMail.Header = "Please enter your e-mail";
                    LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case false:
                    LoginMail.Text = string.Empty;
                    LoginMail.Header = "Could not find user";
                    LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
            }
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            LoginMail.Header = "E-mail";
            LoginMail.ClearValue(TextBox.BorderBrushProperty);
        }
    }
}
