using NativeAppsII_Windows_Groep18.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeAppsII_Windows_Groep18
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void RegisterUser(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }
    }
}
