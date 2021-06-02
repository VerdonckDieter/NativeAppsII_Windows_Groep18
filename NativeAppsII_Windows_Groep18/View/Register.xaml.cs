using Microsoft.Toolkit.Uwp.Notifications;
using NativeAppsII_Windows_Groep18.ViewModel;
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
            RegisterViewModel = new RegisterViewModel();
            RegisterEmail.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            RegisterFirstname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            RegisterLastname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }

        private async void RegisterUser(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(RegisterEmail.Text) ||
                String.IsNullOrEmpty(RegisterFirstname.Text) ||
                String.IsNullOrEmpty(RegisterLastname.Text) ||
                RegisterBirthdate.SelectedDate == null)
            {
                AddRegisterError();
            }
            else
            {
                string email = RegisterEmail.Text;
                string firstname = RegisterFirstname.Text;
                string lastname = RegisterLastname.Text;
                DateTime birthdate = RegisterBirthdate.Date.DateTime;
                try
                {
                    await RegisterViewModel.Register(email, firstname, lastname, birthdate);
                    ShowToast(email);
                    Frame.Navigate(typeof(Login));
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

        private void AddRegisterError()
        {
            if (String.IsNullOrEmpty(RegisterEmail.Text))
            {
                RegisterEmail.Text = string.Empty;
                RegisterEmail.Header = "E-mail is required";
                RegisterEmail.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (String.IsNullOrEmpty(RegisterFirstname.Text))
            {
                RegisterFirstname.Text = string.Empty;
                RegisterFirstname.Header = "First name is required";
                RegisterFirstname.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (String.IsNullOrEmpty(RegisterLastname.Text))
            {
                RegisterLastname.Text = string.Empty;
                RegisterLastname.Header = "Last name is required";
                RegisterLastname.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (RegisterBirthdate.SelectedDate == null)
            {
                RegisterBirthdate.SelectedDate = null;
                RegisterBirthdate.Header = "Birth date is required";
                RegisterBirthdate.Foreground = new SolidColorBrush(Colors.Red);
                RegisterBirthdate.BorderBrush = new SolidColorBrush(Colors.Red);
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
                        RegisterEmail.ClearValue(TextBox.BorderBrushProperty);
                    }
                    else if (((TextBox)sender).Name.Equals("RegisterFirstname"))
                    {
                        RegisterFirstname.Header = "First name";
                        RegisterFirstname.ClearValue(TextBox.BorderBrushProperty);
                    }
                    else
                    {
                        RegisterLastname.Header = "Last name";
                        RegisterLastname.ClearValue(TextBox.BorderBrushProperty);
                    }
                    break;
                case "DatePicker":
                    RegisterBirthdate.Header = "Birth date";
                    RegisterBirthdate.ClearValue(DatePicker.ForegroundProperty);
                    RegisterBirthdate.ClearValue(DatePicker.BorderBrushProperty);
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
