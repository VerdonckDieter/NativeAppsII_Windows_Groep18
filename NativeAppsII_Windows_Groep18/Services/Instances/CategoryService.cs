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
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> DeleteCategory(int tripId, int categoryId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = await _httpClient.DeleteAsync(new Uri($"{Globals.BASE_URL}/Category/{tripId}/{categoryId}"));
            return JsonConvert.DeserializeObject<bool>(await json.Content.ReadAsStringAsync());
        }

        public async Task<Category> UpsertCategory(int tripId, Category category)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", StorageService.RetrieveToken());
            var json = JsonConvert.SerializeObject(category);
            var result = await _httpClient.PostAsync(new Uri($"{Globals.BASE_URL}/Category/{tripId}"), new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
            return JsonConvert.DeserializeObject<Category>(await result.Content.ReadAsStringAsync());
        }
    }
}
