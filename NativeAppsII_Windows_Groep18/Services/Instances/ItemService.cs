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
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> DeleteItem(int categoryId, int itemId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = await _httpClient.DeleteAsync(new Uri($"{Globals.BASE_URL}/Item/{categoryId}/{itemId}"));
            return JsonConvert.DeserializeObject<bool>(await json.Content.ReadAsStringAsync());
        }

        public async Task<Item> UpsertItem(Item item, int categoryId = 0)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = JsonConvert.SerializeObject(item);
            var result = await _httpClient.PostAsync(new Uri($"{Globals.BASE_URL}/Item/{categoryId}"), new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
            return JsonConvert.DeserializeObject<Item>(await result.Content.ReadAsStringAsync());
        }
    }
}
