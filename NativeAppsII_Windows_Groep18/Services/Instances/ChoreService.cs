using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Services.IServices;
using NativeAppsII_Windows_Groep18.Utility;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace NativeAppsII_Windows_Groep18.Services.Instances
{
    public class ChoreService : IChoreService
    {
        private readonly HttpClient _httpClient;

        public ChoreService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> DeleteChore(int tripId, int choreId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = await _httpClient.DeleteAsync(new Uri($"{Globals.BASE_URL}/Chore/{tripId}/{choreId}"));
            return JsonConvert.DeserializeObject<bool>(await json.Content.ReadAsStringAsync());
        }

        public async Task<Chore> UpsertChore(Chore chore, int tripId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = JsonConvert.SerializeObject(chore);
            var result = await _httpClient.PostAsync(new Uri($"{Globals.BASE_URL}/Chore/{tripId}"), new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
            return JsonConvert.DeserializeObject<Chore>(await result.Content.ReadAsStringAsync());
        }
    }
}
