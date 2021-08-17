using NativeAppsII_Windows_Groep18.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View.TripView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripWeather : Page
    {
        #region Properties
        public WeatherViewModel WeatherViewModel { get; set; }
        #endregion

        #region Constructors
        public TripWeather()
        {
            InitializeComponent();
            WeatherViewModel = App.Current.Services.GetService<WeatherViewModel>();
            DataContext = WeatherViewModel;
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            WeatherViewModel.TripLocation = (string)e.Parameter;
            if (WeatherViewModel.DailyForecast.Count < 1)
            {
                WeatherViewModel.GetWeatherForecast();
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        #endregion
    }
}
