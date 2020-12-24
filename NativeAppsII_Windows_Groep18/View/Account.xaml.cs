using NativeAppsII_Windows_Groep18.Model.Singleton;
using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Account : Page
    {
        public AccountViewModel AccountViewModel;
        public Account()
        {
            InitializeComponent();
            InitializeElements();
            AccountViewModel = new AccountViewModel();
        }

        private async void UpdateUser(object sender, RoutedEventArgs e)
        {
            int id = ClientSingleton.Instance.Client.Id;
            string email = AccountEmail.Text;
            string firstname = AccountFirstname.Text;
            string lastname = AccountLastname.Text;
            DateTime birthdate = AccountBirthdate.Date.DateTime;
            try
            {
                await AccountViewModel.UpdateUser(id, email, firstname, lastname, birthdate);
                EditableElements(false);
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog();

                dialog.CloseButtonText = "Close";
                dialog.ShowAsync();
            }

        }

        private void EditAccount(object sender, RoutedEventArgs e)
        {
            EditableElements(true);
        }

        private void EditableElements(bool edit)
        {
            AccountEmail.IsEnabled = edit;
            AccountFirstname.IsEnabled = edit;
            AccountLastname.IsEnabled = edit;
            AccountBirthdate.IsEnabled = edit;
            AccountButton.IsEnabled = edit;
        }

        private void InitializeElements()
        {
            var binding = new Binding { Source = ClientSingleton.Instance.Client.Email, Mode = BindingMode.TwoWay };
            AccountEmail.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding { Source = ClientSingleton.Instance.Client.Firstname, Mode = BindingMode.TwoWay };
            AccountFirstname.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding { Source = ClientSingleton.Instance.Client.Lastname, Mode = BindingMode.TwoWay };
            AccountLastname.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding { Source = ClientSingleton.Instance.Client.Birthdate, Mode = BindingMode.TwoWay };
            AccountBirthdate.SetBinding(DatePicker.DateProperty, binding);
        }
    }
}
