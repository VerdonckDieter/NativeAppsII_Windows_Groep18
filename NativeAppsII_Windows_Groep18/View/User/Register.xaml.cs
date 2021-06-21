using NativeAppsII_Windows_Groep18.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Resources;
using System.Threading.Tasks;
using NativeAppsII_Windows_Groep18.Services.Instances;
using Windows.UI.Xaml.Navigation;
using System.Numerics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        #region Properties
        public RegisterViewModel RegisterViewModel { get; set; }
        private ResourceLoader ResourceLoader { get; set; }
        #endregion

        #region Constructors
        public Register()
        {
            InitializeComponent();
            RegisterViewModel = App.Current.Services.GetService<RegisterViewModel>();
            DataContext = RegisterViewModel;
            ResourceLoader = ResourceLoader.GetForCurrentView();
            RegisterEmail.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            RegisterPassword.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            RegisterFirstname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            RegisterLastname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }
        #endregion

        #region Methods
        private async void RegisterUser(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (await ValidateEmail())
                {
                    switch (await RegisterViewModel.Register(RegisterEmail.Text, RegisterPassword.Password,
                        RegisterFirstname.Text, RegisterLastname.Text))
                    {
                        case "SUCCESS":
                            Frame.Navigate(typeof(Login));
                            ToastService.MakeToast(string.Format(ResourceLoader.GetString("RegisterAccountCreated"), RegisterEmail.Text));
                            break;
                        case "FAIL":
                            RegisterError("fail");
                            break;
                        case "ERROR":
                            RegisterError("error");
                            break;
                    }
                }
            }
        }

        private bool Validate()
        {
            var success = true;
            if (string.IsNullOrWhiteSpace(RegisterEmail.Text))
            {
                RegisterEmail.Text = string.Empty;
                RegisterEmail.Header = ResourceLoader.GetString("RegisterEmailHeaderEmpty");
                RegisterEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (string.IsNullOrWhiteSpace(RegisterPassword.Password))
            {
                RegisterPassword.Password = string.Empty;
                RegisterPassword.Header = ResourceLoader.GetString("RegisterPasswordHeaderEmpty");
                RegisterPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (string.IsNullOrWhiteSpace(RegisterFirstname.Text))
            {
                RegisterFirstname.Text = string.Empty;
                RegisterFirstname.Header = ResourceLoader.GetString("RegisterFirstnameHeaderEmpty");
                RegisterFirstname.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (string.IsNullOrWhiteSpace(RegisterLastname.Text))
            {
                RegisterLastname.Text = string.Empty;
                RegisterLastname.Header = ResourceLoader.GetString("RegisterLastnameHeaderEmpty");
                RegisterLastname.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            return success;
        }

        private async Task<bool> ValidateEmail()
        {
            if (await RegisterViewModel.CheckAvailableUsername(RegisterEmail.Text) == "NOTAVAILABLE")
            {
                RegisterEmail.Text = string.Empty;
                RegisterEmail.Header = ResourceLoader.GetString("RegisterEmailHeaderEmailInUse");
                RegisterEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            return true;
        }

        private void NavigateToLogin(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void RegisterError(string type)
        {
            switch (type.ToLower())
            {
                case "fail":
                    RegisterEmail.Text = string.Empty;
                    RegisterEmail.Header = ResourceLoader.GetString("RegisterFail");
                    RegisterEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                    RegisterPassword.Password = string.Empty;
                    RegisterPassword.Header = ResourceLoader.GetString("RegisterFail");
                    RegisterPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    RegisterFirstname.Text = string.Empty;
                    RegisterFirstname.Header = ResourceLoader.GetString("RegisterFail");
                    RegisterFirstname.BorderBrush = new SolidColorBrush(Colors.Red);
                    RegisterLastname.Text = string.Empty;
                    RegisterLastname.Header = ResourceLoader.GetString("RegisterFail");
                    RegisterLastname.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case "error":
                    RegisterEmail.Text = string.Empty;
                    RegisterEmail.Header = ResourceLoader.GetString("ErrorText");
                    RegisterEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                    RegisterPassword.Password = string.Empty;
                    RegisterPassword.Header = ResourceLoader.GetString("ErrorText");
                    RegisterPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    RegisterFirstname.Text = string.Empty;
                    RegisterFirstname.Header = ResourceLoader.GetString("ErrorText");
                    RegisterFirstname.BorderBrush = new SolidColorBrush(Colors.Red);
                    RegisterLastname.Text = string.Empty;
                    RegisterLastname.Header = ResourceLoader.GetString("ErrorText");
                    RegisterLastname.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
            }
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            RegisterEmail.Header = ResourceLoader.GetString("RegisterEmail/Header");
            RegisterEmail.ClearValue(BorderBrushProperty);

            RegisterPassword.Header = ResourceLoader.GetString("RegisterPassword/Header");
            RegisterPassword.ClearValue(BorderBrushProperty);

            RegisterFirstname.Header = ResourceLoader.GetString("RegisterFirstname/Header");
            RegisterFirstname.ClearValue(BorderBrushProperty);

            RegisterLastname.Header = ResourceLoader.GetString("RegisterLastname/Header");
            RegisterLastname.ClearValue(BorderBrushProperty);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SharedShadow.Receivers.Add(BackgroundGrid);
            RegisterStackPanel.Translation += new Vector3(0, 0, 10);
        }
        #endregion
    }
}
