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
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherForecast> GetWeatherForecast(string location)
        {
            var json = await _httpClient.GetStringAsync(new Uri($"http://api.openweathermap.org/data/2.5/weather?q={location}&appid={Globals.API_KEY}"));
            return JsonConvert.DeserializeObject<WeatherForecast>(json);
        }
    }
}
