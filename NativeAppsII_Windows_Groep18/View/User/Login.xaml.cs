using NativeAppsII_Windows_Groep18.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Navigation;
using System.Numerics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        #region Properties
        public LoginViewModel LoginViewModel { get; set; }
        private ResourceLoader ResourceLoader { get; set; }
        #endregion

        #region Constructors
        public Login()
        {
            InitializeComponent();
            LoginViewModel = App.Current.Services.GetService<LoginViewModel>();
            DataContext = LoginViewModel;
            ResourceLoader = ResourceLoader.GetForCurrentView();
            LoginMail.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            LoginPassword.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }
        #endregion

        #region Methods
        private async void LoginUser(object sender, RoutedEventArgs e)
        {
            if (Validate())
                switch (await LoginViewModel.Login(LoginMail.Text, LoginPassword.Password))
                {
                    case "SUCCESS":
                        Frame.Navigate(typeof(Navigation));
                        break;
                    case "FAIL":
                        LoginError("notfound");
                        break;
                    case "ERROR":
                        LoginError("error");
                        break;
                    default:
                        break;
                }
        }

        private bool Validate()
        {
            var success = true;
            if (string.IsNullOrWhiteSpace(LoginMail.Text))
            {
                LoginMail.Text = string.Empty;
                LoginMail.Header = ResourceLoader.GetString("LoginMailHeaderEmpty");
                LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (string.IsNullOrWhiteSpace(LoginPassword.Password))
            {
                LoginPassword.Password = string.Empty;
                LoginPassword.Header = ResourceLoader.GetString("LoginPasswordHeaderEmpty");
                LoginPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            return success;
        }

        private void NavigateToRegister(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private void LoginError(string type)
        {
            switch (type.ToLower())
            {
                case "notfound":
                    LoginMail.Text = string.Empty;
                    LoginMail.Header = ResourceLoader.GetString("LoginUserNotFound");
                    LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
                    LoginPassword.Password = string.Empty;
                    LoginPassword.Header = ResourceLoader.GetString("LoginUserNotFound");
                    LoginPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case "error":
                    LoginMail.Text = string.Empty;
                    LoginMail.Header = ResourceLoader.GetString("ErrorText");
                    LoginMail.BorderBrush = new SolidColorBrush(Colors.Red);
                    LoginPassword.Password = string.Empty;
                    LoginPassword.Header = ResourceLoader.GetString("ErrorText");
                    LoginPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                default:
                    break;
            }
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            LoginMail.Header = ResourceLoader.GetString("LoginMail/Header");
            LoginMail.ClearValue(BorderBrushProperty);

            LoginPassword.Header = ResourceLoader.GetString("LoginPassword/Header");
            LoginPassword.ClearValue(BorderBrushProperty);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SharedShadow.Receivers.Add(BackgroundGrid);
            LoginStackPanel.Translation += new Vector3(0, 0, 10);
        }
        #endregion
    }
}
