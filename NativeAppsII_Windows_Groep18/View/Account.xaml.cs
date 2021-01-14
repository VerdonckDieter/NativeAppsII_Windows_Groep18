using NativeAppsII_Windows_Groep18.Model.Singleton;
using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

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
            AccountEmail.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AccountFirstname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AccountLastname.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }

        private async void UpdateUser(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(AccountEmail.Text) ||
                String.IsNullOrEmpty(AccountFirstname.Text) ||
                String.IsNullOrEmpty(AccountLastname.Text) ||
                AccountBirthdate.SelectedDate == null)
            {
                AddAccountError();
            }
            else
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
        }

        private void AddAccountError()
        {
            if (String.IsNullOrEmpty(AccountEmail.Text))
            {
                AccountEmail.Text = string.Empty;
                AccountEmail.Header = "E-mail is required";
                AccountEmail.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (String.IsNullOrEmpty(AccountFirstname.Text))
            {
                AccountFirstname.Text = string.Empty;
                AccountFirstname.Header = "First name is required";
                AccountFirstname.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (String.IsNullOrEmpty(AccountLastname.Text))
            {
                AccountLastname.Text = string.Empty;
                AccountLastname.Header = "Last name is required";
                AccountLastname.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (AccountBirthdate.SelectedDate == null)
            {
                AccountBirthdate.SelectedDate = null;
                AccountBirthdate.Header = "Birth date is required";
                AccountBirthdate.Foreground = new SolidColorBrush(Colors.Red);
                AccountBirthdate.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            switch (sender.GetType().Name)
            {
                case "TextBox":
                    if (((TextBox)sender).Name.Equals("AccountEmail"))
                    {
                        AccountEmail.Header = "E-mail";
                        AccountEmail.ClearValue(TextBox.BorderBrushProperty);
                    }
                    else if (((TextBox)sender).Name.Equals("AccountFirstname"))
                    {
                        AccountFirstname.Header = "First name";
                        AccountFirstname.ClearValue(TextBox.BorderBrushProperty);
                    }
                    else
                    {
                        AccountLastname.Header = "Last name";
                        AccountLastname.ClearValue(TextBox.BorderBrushProperty);
                    }
                    break;
                case "DatePicker":
                    AccountBirthdate.Header = "Birth date";
                    AccountBirthdate.ClearValue(DatePicker.ForegroundProperty);
                    AccountBirthdate.ClearValue(DatePicker.BorderBrushProperty);
                    break;
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
            var binding = new Binding { Source = ClientSingleton.Instance.Client.Email, Mode = BindingMode.OneWay };
            AccountEmail.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding { Source = ClientSingleton.Instance.Client.Firstname, Mode = BindingMode.OneWay };
            AccountFirstname.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding { Source = ClientSingleton.Instance.Client.Lastname, Mode = BindingMode.OneWay };
            AccountLastname.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding { Source = ClientSingleton.Instance.Client.Birthdate, Mode = BindingMode.OneWay };
            AccountBirthdate.SetBinding(DatePicker.DateProperty, binding);
        }
    }
}
