using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        }

        private async void RegisterUser(object sender, RoutedEventArgs e)
        {
            string email = RegisterEmail.Text;
            string firstname = RegisterFirstname.Text;
            string lastname = RegisterLastname.Text;
            DateTime birthdate = RegisterBirthdate.Date.DateTime;
            try
            {
                await RegisterViewModel.Register(email, firstname, lastname, birthdate);
                Frame.Navigate(typeof(Login));
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog();

                dialog.CloseButtonText = "Close";
                dialog.ShowAsync();
            }

        }

        private void NavigateToLogin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }
    }
}
