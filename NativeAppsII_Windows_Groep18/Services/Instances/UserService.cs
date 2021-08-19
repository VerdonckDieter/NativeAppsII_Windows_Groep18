using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Storage.Streams;
using NativeAppsII_Windows_Groep18.Utility;
using NativeAppsII_Windows_Groep18.Services.IServices;

namespace NativeAppsII_Windows_Groep18.Services.Instances
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructors
        public UserService()
        {
            _httpClient = new HttpClient();
        }
        #endregion

        #region Methods
        public async Task<string> Login(string email, string password)
        {
            var json = JsonConvert.SerializeObject(new
            {
                email,
                password
            });
            var result = await _httpClient.PostAsync(new Uri($"{Globals.BASE_URL}/User/Login"),
                new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                StorageService.StoreToken(await result.Content.ReadAsStringAsync());
                return "SUCCESS";
            }
            return "FAIL";
        }

        public async Task<string> Register(string email, string password, string firstname, string lastname)
        {
            var json = JsonConvert.SerializeObject(new
            {
                email,
                password,
                firstname,
                lastname
            });
            var result = await _httpClient.PostAsync(new Uri($"{Globals.BASE_URL}/User/Register"),
                new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                return "SUCCESS";
            }
            return "FAIL";
        }

        public async Task<string> CheckAvailableUsername(string email)
        {
            var result = await _httpClient.GetAsync(new Uri($"{Globals.BASE_URL}/User/" + email));
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync() == "true" ? "AVAILABLE" : "NOTAVAILABLE";
            }
            return "FAIL";
        } 
        #endregion
    }
}
