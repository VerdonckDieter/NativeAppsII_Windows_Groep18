using NativeAppsII_Windows_Groep18.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Input;
using NativeAppsII_Windows_Groep18.Services.Instances;
using Windows.UI.Xaml.Navigation;
using System.Numerics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View.TripView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTripView : Page
    {
        #region Properties
        public AddTripViewModel AddTripViewModel { get; set; }
        private ResourceLoader ResourceLoader { get; set; }
        #endregion
        public AddTripView()
        {
            InitializeComponent();
            AddTripViewModel = App.Current.Services.GetService<AddTripViewModel>();
            DataContext = AddTripViewModel;
            ResourceLoader = ResourceLoader.GetForCurrentView();
            AddTripName.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AddTripLocation.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AddTripStartDate.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AddTripEndDate.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
        }

        private async void AddTrip(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (await AddTripViewModel.AddTrip(AddTripName.Text, AddTripLocation.Text, AddTripStartDate.Date.Value.DateTime, AddTripEndDate.Date.Value.DateTime) != null)
                {
                    ToastService.MakeToast(string.Format(ResourceLoader.GetString("AddTripCreated"), AddTripName.Text));
                }
            }
        }

        private bool Validate()
        {
            var success = true;
            if (string.IsNullOrWhiteSpace(AddTripName.Text))
            {
                AddTripName.Text = string.Empty;
                AddTripName.Header = ResourceLoader.GetString("TripNameEmpty");
                AddTripName.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (string.IsNullOrWhiteSpace(AddTripLocation.Text))
            {
                AddTripLocation.Text = string.Empty;
                AddTripLocation.Header = ResourceLoader.GetString("TripLocationEmpty");
                AddTripLocation.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (AddTripStartDate.Date == null)
            {
                AddTripStartDate.Date = null;
                AddTripStartDate.Header = ResourceLoader.GetString("TripStartDateEmpty");
                AddTripStartDate.Foreground = new SolidColorBrush(Colors.Red);
                AddTripStartDate.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (AddTripEndDate.Date == null)
            {
                AddTripEndDate.Date = null;
                AddTripEndDate.Header = ResourceLoader.GetString("TripEndDateEmpty");
                AddTripEndDate.Foreground = new SolidColorBrush(Colors.Red);
                AddTripEndDate.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            return success;
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            AddTripName.Header = ResourceLoader.GetString("TripName/Header");
            AddTripName.ClearValue(BorderBrushProperty);

            AddTripLocation.Header = ResourceLoader.GetString("TripLocation/Header");
            AddTripLocation.ClearValue(BorderBrushProperty);

            AddTripStartDate.Header = ResourceLoader.GetString("TripStartDate/Header");
            AddTripStartDate.ClearValue(ForegroundProperty);
            AddTripStartDate.ClearValue(BorderBrushProperty);

            AddTripEndDate.Header = ResourceLoader.GetString("TripEndDate/Header");
            AddTripEndDate.ClearValue(ForegroundProperty);
            AddTripEndDate.ClearValue(BorderBrushProperty);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SharedShadow.Receivers.Add(BackgroundGrid);
            AddStackPanel.Translation += new Vector3(0, 0, 10);
        }
    }
}
