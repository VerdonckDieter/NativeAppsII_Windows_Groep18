using NativeAppsII_Windows_Groep18.Model.Weather;
using NativeAppsII_Windows_Groep18.Services.IServices;
using NativeAppsII_Windows_Groep18.Utility;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace NativeAppsII_Windows_Groep18.Services.Instances
{
    public class WeatherService : IWeatherService
    {
        #region Fields
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructors
        public WeatherService()
        {
            _httpClient = new HttpClient();
        }
        #endregion

        #region Methods
        public async Task<LocalWeather> GetLocalWeather(string location)
        {
            var json = await _httpClient.GetStringAsync(new Uri($"http://api.openweathermap.org/data/2.5/weather?q={location}&appid={Globals.API_KEY}"));
            return JsonConvert.DeserializeObject<LocalWeather>(json);
        }

        public async Task<DailyForecast> GetWeatherForecast(double latitude, double longitude)
        {
            var json = await _httpClient.GetStringAsync(new Uri($"https://api.openweathermap.org/data/2.5/onecall?" +
                $"lat={latitude}&lon={longitude}&exclude=current,minutely,hourly,alerts&appid={Globals.API_KEY}&units=metric"));
            return JsonConvert.DeserializeObject<DailyForecast>(json);
        } 
        #endregion
    }
}
