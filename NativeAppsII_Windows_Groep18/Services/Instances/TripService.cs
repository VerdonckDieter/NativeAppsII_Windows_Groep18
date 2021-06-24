using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Services.IServices;
using NativeAppsII_Windows_Groep18.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace NativeAppsII_Windows_Groep18.Services.Instances
{
    public class TripService : ITripService
    {
        private readonly HttpClient _httpClient;

        public TripService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Trip>> GetTrips()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = await _httpClient.GetStringAsync(new Uri($"{Globals.BASE_URL}/Trip/GetTrips"));
            return JsonConvert.DeserializeObject<List<Trip>>(json);
        }

        public async Task<Trip> GetTrip(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = await _httpClient.GetStringAsync(new Uri($"{Globals.BASE_URL}/Trip/{id}"));
            return JsonConvert.DeserializeObject<Trip>(json);
        }

        public async Task<bool> DeleteTrip(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = await _httpClient.DeleteAsync(new Uri($"{Globals.BASE_URL}/Trip/{id}"));
            return JsonConvert.DeserializeObject<bool>(await json.Content.ReadAsStringAsync());
        }

        public async Task<Trip> UpsertTrip(Trip trip)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = JsonConvert.SerializeObject(trip);
            var result = await _httpClient.PostAsync(new Uri($"{Globals.BASE_URL}/Trip"), new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
            return JsonConvert.DeserializeObject<Trip>(await result.Content.ReadAsStringAsync());
        }
    }
}