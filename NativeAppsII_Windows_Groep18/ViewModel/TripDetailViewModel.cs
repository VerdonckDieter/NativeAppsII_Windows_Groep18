using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.Weather;
using NativeAppsII_Windows_Groep18.Services.IServices;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class TripDetailViewModel
    {
        #region Fields
        private readonly ITripService _tripService;
        private readonly IWeatherService _weatherService;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        public WeatherForecast WeatherForecast { get; set; }
        #endregion

        #region Constructors
        public TripDetailViewModel(ITripService tripService, IWeatherService weatherService)
        {
            _tripService = tripService;
            _weatherService = weatherService;
        }
        #endregion

        #region Methods
        public async void DeleteTrip(int id) => await _tripService.DeleteTrip(id);

        public async void GetWeatherForecast() => await _weatherService.GetWeatherForecast(Trip.Location);
        #endregion
    }
}
