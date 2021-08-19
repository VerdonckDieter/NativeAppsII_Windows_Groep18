using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NativeAppsII_Windows_Groep18.Model.Weather
{
    public class DailyForecast
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }
        [JsonProperty("daily")]
        public List<Daily> Daily { get; set; }
    }

    public class Daily
    {
        [JsonProperty("dt")]
        public int Dt { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
        [JsonProperty("moonrise")]
        public int Moonrise { get; set; }
        [JsonProperty("moonset")]
        public int Moonset { get; set; }
        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }
        [JsonProperty("temp")]
        public Temperature Temperature { get; set; }
        [JsonProperty("feels_like")]
        public TemperatureFeeling TemperatureFeeling { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
        [JsonProperty("wind_deg")]
        public double WindDegree { get; set; }
        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("clouds")]
        public int Clouds { get; set; }
        [JsonProperty("pop")]
        public double Probability { get; set; }
        [JsonProperty("uvi")]
        public double UVIndex { get; set; }
        [JsonProperty("rain")]
        public double Rain { get; set; }
        [JsonProperty("snow")]
        public int Snow { get; set; }
        public string ImageUrl => "http://openweathermap.org/img/wn/" + Weather[0].Icon + "@4x.png";
    }

    public class LocalWeather
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("base")]
        public string Base { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("rain")]
        public Rain Rain { get; set; }
        [JsonProperty("snow")]
        public Snow Snow { get; set; }
        [JsonProperty("dt")]
        public int Dt { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("timezone")]
        public int Timezone { get; set; }
        [JsonProperty("id")]
        public int CityId { get; set; }
        [JsonProperty("name")]
        public string CityName { get; set; }
        [JsonProperty("cod")]
        public string Cod { get; set; }
    }
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("feels_like")]
        public double Feeling { get; set; }
        [JsonProperty("temp_min")]
        public double TemperatureMinimum { get; set; }
        [JsonProperty("temp_max")]
        public double TemperatureMaximum { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Degree { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }

    public class Rain
    {
        [JsonProperty("1h")]
        public int OneHour { get; set; }
        [JsonProperty("3h")]
        public int ThreeHour { get; set; }
    }

    public class Snow
    {
        [JsonProperty("1h")]
        public int OneHour { get; set; }
        [JsonProperty("3h")]
        public int ThreeHour { get; set; }
    }

    public class Sys
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }

    public class WeatherForecast
    {
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("cod")]
        public string Cod { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cnt")]
        public int Count { get; set; }
        [JsonProperty("list")]
        public List<WeatherForecastList> WeatherForecastList { get; set; }
    }

    public class WeatherForecastList
    {
        [JsonProperty("dt")]
        public int Dt { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
        [JsonProperty("temp")]
        public Temperature Temperature { get; set; }
        [JsonProperty("feels_like")]
        public TemperatureFeeling TemperatureFeeling { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public int Degree { get; set; }
        [JsonProperty("gust")]
        public double Gust { get; set; }
        [JsonProperty("clouds")]
        public int Clouds { get; set; }
        [JsonProperty("rain")]
        public int Rain { get; set; }
        [JsonProperty("snow")]
        public int Snow { get; set; }
        [JsonProperty("pop")]
        public double Probability { get; set; }
    }

    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("timezone")]
        public int Timezone { get; set; }
    }

    public class Temperature
    {
        [JsonProperty("day")]
        public double Day { get; set; }
        [JsonProperty("min")]
        public double Min { get; set; }
        [JsonProperty("max")]
        public double Max { get; set; }
        [JsonProperty("night")]
        public double Night { get; set; }
        [JsonProperty("eve")]
        public double Evening { get; set; }
        [JsonProperty("morn")]
        public double Morning { get; set; }
        public string DayRounded => ((int)Math.Round(Day)).ToString() + "°";
        public string NightRounded => ((int)Math.Round(Night)).ToString() + "°";
    }

    public class TemperatureFeeling
    {
        [JsonProperty("day")]
        public double Day { get; set; }
        [JsonProperty("night")]
        public double Night { get; set; }
        [JsonProperty("eve")]
        public double Evening { get; set; }
        [JsonProperty("morn")]
        public double Morning { get; set; }
    }
}
