using NativeAppsII_Windows_Groep18.Model.Weather;
using NativeAppsII_Windows_Groep18.Services.IServices;
using NativeAppsII_Windows_Groep18.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Services.Maps;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class WeatherViewModel
    {
        #region Fields
        private readonly IWeatherService _weatherService;
        #endregion

        #region Properties
        public ObservableCollection<Daily> DailyForecast { get; set; }
        public string TripLocation { get; set; }
        #endregion

        #region Constructors
        public WeatherViewModel(IWeatherService weatherService)
        {
            DailyForecast = new ObservableCollection<Daily>();
            _weatherService = weatherService;
            MapService.ServiceToken = Globals.MAP_TOKEN;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the seven day weather forecast.
        /// </summary>
        public async void GetWeatherForecast()
        {
            List<double> geocoding = await GetGeocode();
            var dailyForecast = await _weatherService.GetWeatherForecast(geocoding[0], geocoding[1]);
            dailyForecast.Daily.ForEach(d => DailyForecast.Add(d));
        }

        /// <summary>
        /// Get the latitude and longitude based on the trip's location.
        /// </summary>
        public async Task<List<double>> GetGeocode()
        {
            List<double> geocoding = new List<double>();
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(TripLocation, null, 1);
            if (result.Status == MapLocationFinderStatus.Success)
            {
                geocoding.Add(result.Locations[0].Point.Position.Latitude);
                geocoding.Add(result.Locations[0].Point.Position.Longitude);
            }
            return geocoding;
        }
        #endregion
    }
}
