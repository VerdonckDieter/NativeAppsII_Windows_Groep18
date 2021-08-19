using NativeAppsII_Windows_Groep18.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;
using NativeAppsII_Windows_Groep18.Model;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View.TripView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripOverview : Page
    {
        #region Properties
        public TripViewModel TripViewModel { get; set; }
        private ResourceLoader ResourceLoader { get; set; }
        #endregion

        #region Constructors
        public TripOverview()
        {
            InitializeComponent();
            TripViewModel = App.Current.Services.GetService<TripViewModel>();
            DataContext = TripViewModel;
            ResourceLoader = ResourceLoader.GetForCurrentView();
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (TripViewModel.Trips.Count < 1)
            {
                TripViewModel.LoadTrips();
            }
        }

        private void NavigateToDetail(object sender, TappedRoutedEventArgs e)
        {
            if (TripGridView.SelectedItem is Trip clickedItem)
            {
                Frame.Navigate(typeof(TripDetail), clickedItem);
            }
        }

        private void ShowMenu(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((StackPanel)sender);
        }

        private void MenuFlyoutItemTapped(object sender, RoutedEventArgs e)
        {
            var modify = (MenuFlyoutItem)sender;
            switch (modify.Name)
            {
                case "MenuModifyTrip":
                    Modify(modify);
                    break;
                case "MenuDeleteTrip":
                    Delete(modify);
                    break;
                default: break;
            }
        }

        private void Modify(MenuFlyoutItem sender)
        {
            var modifyTrip = (Trip)sender.DataContext;
            if (modifyTrip != null)
            {
                Frame.Navigate(typeof(UpdateTripView), modifyTrip);
            }
        }

        private async void Delete(MenuFlyoutItem sender)
        {
            var deleteTrip = (Trip)sender.DataContext;
            if (deleteTrip != null)
            {
                if (await ShowDeleteContentDialog(deleteTrip.Name) == ContentDialogResult.Primary)
                {
                    if (await TripViewModel.DeleteTrip(deleteTrip.Id))
                    {
                        TripViewModel.Trips.Remove(deleteTrip);
                    }
                }
            }
        }

        private async Task<ContentDialogResult> ShowDeleteContentDialog(string name)
        {
            return await TripViewModel.ShowContentDialog(
                            ResourceLoader.GetString("DeleteContentDialogTitle"),
                            string.Format(ResourceLoader.GetString("DeleteContentDialogContent"), name),
                            ResourceLoader.GetString("DeleteContentDialogPrimaryButton"),
                            ResourceLoader.GetString("DeleteContentDialogCloseButton"));
        }
        #endregion
    }
}