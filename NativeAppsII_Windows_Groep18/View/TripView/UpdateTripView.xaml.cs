using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using Windows.ApplicationModel.Resources;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Navigation;
using NativeAppsII_Windows_Groep18.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View.TripView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateTripView : Page
    {
        #region Properties
        private UpdateTripViewModel UpdateTripViewModel { get; set; }
        private ResourceLoader ResourceLoader { get; set; }

        #endregion


        #region Constructors
        public UpdateTripView()
        {
            InitializeComponent();
            UpdateTripViewModel = App.Current.Services.GetService<UpdateTripViewModel>();
            DataContext = UpdateTripViewModel;
            ResourceLoader = ResourceLoader.GetForCurrentView();
            UpdateTripName.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            UpdateTripLocation.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            UpdateTripStartDate.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            UpdateTripEndDate.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Trip trip = (Trip)e.Parameter;
            UpdateTripViewModel.Trip = trip;
        }
        private async void UpdateTrip(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                await UpdateTripViewModel.UpdateTrip();
            }
        }

        private bool Validate()
        {
            var success = true;
            if (string.IsNullOrWhiteSpace(UpdateTripName.Text))
            {
                UpdateTripName.Text = string.Empty;
                UpdateTripName.Header = ResourceLoader.GetString("TripNameEmpty");
                UpdateTripName.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (string.IsNullOrWhiteSpace(UpdateTripLocation.Text))
            {
                UpdateTripLocation.Text = string.Empty;
                UpdateTripLocation.Header = ResourceLoader.GetString("TripLocationEmpty");
                UpdateTripLocation.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (UpdateTripStartDate.Date == null)
            {
                UpdateTripStartDate.Date = null;
                UpdateTripStartDate.Header = ResourceLoader.GetString("TripStartDateEmpty");
                UpdateTripStartDate.Foreground = new SolidColorBrush(Colors.Red);
                UpdateTripStartDate.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (UpdateTripEndDate.Date == null)
            {
                UpdateTripEndDate.Date = null;
                UpdateTripEndDate.Header = ResourceLoader.GetString("TripEndDateEmpty");
                UpdateTripEndDate.Foreground = new SolidColorBrush(Colors.Red);
                UpdateTripEndDate.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            return success;
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            UpdateTripName.Header = ResourceLoader.GetString("TripName/Header");
            UpdateTripName.ClearValue(BorderBrushProperty);

            UpdateTripLocation.Header = ResourceLoader.GetString("TripLocation/Header");
            UpdateTripLocation.ClearValue(BorderBrushProperty);

            UpdateTripStartDate.Header = ResourceLoader.GetString("TripStartDate/Header");
            UpdateTripStartDate.ClearValue(ForegroundProperty);
            UpdateTripStartDate.ClearValue(BorderBrushProperty);

            UpdateTripEndDate.Header = ResourceLoader.GetString("TripEndDate/Header");
            UpdateTripEndDate.ClearValue(ForegroundProperty);
            UpdateTripEndDate.ClearValue(BorderBrushProperty);
        }
        #endregion
    }
}
