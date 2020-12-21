﻿using NativeAppsII_Windows_Groep18.ViewModel;
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
    public sealed partial class Login : Page
    {
        public LoginViewModel LoginViewModel;
        public Login()
        {
            this.InitializeComponent();
            LoginViewModel = new LoginViewModel();
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            string mail = LoginMail.Text;
            try
            {
                LoginViewModel.Login(mail);
                this.Frame.Navigate(typeof(MasterDetail));
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog();

                dialog.CloseButtonText = "Close";
                dialog.ShowAsync();
            }

        }
    }
}
