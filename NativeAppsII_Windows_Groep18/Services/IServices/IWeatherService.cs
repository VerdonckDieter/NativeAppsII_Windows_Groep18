using NativeAppsII_Windows_Groep18.Model.Weather;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Services.IServices
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeatherForecast(string location);
    }
}
