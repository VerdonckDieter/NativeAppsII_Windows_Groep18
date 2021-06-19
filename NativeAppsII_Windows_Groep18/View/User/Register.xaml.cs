using Microsoft.Toolkit.Uwp.Notifications;
using NativeAppsII_Windows_Groep18.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI;
using Windows.UI.Notifications;
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
    public sealed partial class Register : Page
    {
        public RegisterViewModel RegisterViewModel;
        public Register()
        {
            InitializeComponent();
            RegisterViewModel = App.Current.Services.GetService<RegisterViewModel>();
            DataContext = RegisterViewModel;
            RegisterEmail.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            RegisterFirstname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            RegisterLastname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }

        private async void RegisterUser(object sender, RoutedEventArgs e)
        {
            string email = RegisterEmail.Text;
            string password = RegisterPassword.Text;
            string firstname = RegisterFirstname.Text;
            string lastname = RegisterLastname.Text;
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(firstname) ||
                string.IsNullOrEmpty(lastname))
            {
                AddRegisterError();
            }
            else
            {
                if (await RegisterViewModel.CheckAvailableUsername(email) == "NOTAVAILABLE")
                {
                    RegisterEmail.Text = string.Empty;
                    RegisterEmail.Header = "E-mail is already in use";
                    RegisterEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                if (await RegisterViewModel.Register(email, password, firstname, lastname) == "SUCCESS")
                {
                    ShowToast(email);
                    Frame.Navigate(typeof(Login));
                }
            }
        }

        private void AddRegisterError()
        {
            if (string.IsNullOrEmpty(RegisterEmail.Text))
            {
                RegisterEmail.Text = string.Empty;
                RegisterEmail.Header = "E-mail is required";
                RegisterEmail.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(RegisterPassword.Text))
            {
                RegisterPassword.Text = string.Empty;
                RegisterPassword.Header = "Password is required";
                RegisterPassword.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(RegisterFirstname.Text))
            {
                RegisterFirstname.Text = string.Empty;
                RegisterFirstname.Header = "First name is required";
                RegisterFirstname.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(RegisterLastname.Text))
            {
                RegisterLastname.Text = string.Empty;
                RegisterLastname.Header = "Last name is required";
                RegisterLastname.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            switch (sender.GetType().Name)
            {
                case "TextBox":
                    if (((TextBox)sender).Name.Equals("RegisterEmail"))
                    {
                        RegisterEmail.Header = "E-mail";
                        RegisterEmail.ClearValue(BorderBrushProperty);
                    }
                    else if (((TextBox)sender).Name.Equals("RegisterPassword"))
                    {
                        RegisterPassword.Header = "Password";
                        RegisterPassword.ClearValue(BorderBrushProperty);
                    }
                    else if (((TextBox)sender).Name.Equals("RegisterFirstname"))
                    {
                        RegisterFirstname.Header = "First name";
                        RegisterFirstname.ClearValue(BorderBrushProperty);
                    }
                    else
                    {
                        RegisterLastname.Header = "Last name";
                        RegisterLastname.ClearValue(BorderBrushProperty);
                    }
                    break;
            }
        }

        private void NavigateToLogin(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void ShowToast(string text)
        {
            var content = new ToastContentBuilder()
                .AddText("Account for " + text + " was created")
                .SetToastDuration(ToastDuration.Short)
                .GetToastContent();
            var notif = new ToastNotification(content.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(notif);
        }
    }
}
