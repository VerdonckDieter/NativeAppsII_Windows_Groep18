using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.Weather;
using NativeAppsII_Windows_Groep18.Services.IServices;
using System;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class TripDetailViewModel
    {
        #region Fields
        private readonly ITripService _tripService;
        private readonly IItemService _itemService;
        private readonly IChoreService _choreService;
        private readonly IWeatherService _weatherService;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        public WeatherForecast WeatherForecast { get; set; }
        #endregion

        #region Constructors
        public TripDetailViewModel(ITripService tripService, IWeatherService weatherService, IItemService itemService, IChoreService choreService)
        {
            _tripService = tripService;
            _weatherService = weatherService;
            _itemService = itemService;
            _choreService = choreService;
        }
        #endregion

        #region Methods
        public async void DeleteTrip(int id) => await _tripService.DeleteTrip(id);

        public async void GetWeatherForecast(int days) => await _weatherService.GetWeatherForecast(Trip.Location, days);

        public async void UpdateItemAsync(Item item) => await _itemService.UpsertItem(item);

        public async void UpdateChoreAsync(Chore chore) => await _choreService.UpsertChore(chore);

        #endregion
    }
}
