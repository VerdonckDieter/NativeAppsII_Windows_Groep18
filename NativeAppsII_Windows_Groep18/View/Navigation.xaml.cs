using NativeAppsII_Windows_Groep18.Services.Instances;
using NativeAppsII_Windows_Groep18.View.TripView;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Navigation : Page
    {
        public Navigation()
        {
            InitializeComponent();
            ContentFrame.Navigate(typeof(TripOverview));
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var invokedItem = args.InvokedItemContainer.Tag.ToString();
            switch (invokedItem)
            {
                case "Home":
                    ContentFrame.Navigate(typeof(TripOverview));
                    break;
                case "Add":
                    ContentFrame.Navigate(typeof(AddTripView));
                    break;
                case "Maps":
                    ContentFrame.Navigate(typeof(Itinerary));
                    break;
                default:
                    break;
            }
        }

        private void Logout(object sender, TappedRoutedEventArgs e)
        {
            StorageService.StoreToken("");
            Frame.Navigate(typeof(Login));
        }
    }
}
