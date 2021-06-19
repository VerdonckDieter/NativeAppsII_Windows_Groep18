using NativeAppsII_Windows_Groep18.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Storage.Streams;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class RegisterViewModel
    {
        public async Task<bool> Register(string email, string password, string firstname, string lastname)
        {
            HttpClient client = new HttpClient();
            var success = false;
            try
            {
                var json = JsonConvert.SerializeObject(new
                {
                    email,
                    password,
                    firstname,
                    lastname
                });
                var result = await client.PostAsync(new Uri($"{Globals.BASE_URL}/User/Register"),
                    new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
                return success = result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return success;
            }
        }

        public async Task<bool> CheckAvailableUsername(string email)
        {
            HttpClient client = new HttpClient();
            var success = false;
            try
            {
                var result = await client.GetAsync(new Uri($"{Globals.BASE_URL}/User/" + email));
                if (result.IsSuccessStatusCode)
                {
                    return success = JsonConvert.DeserializeObject<bool>(await result.Content.ReadAsStringAsync());
                }
                return success;
            }
            catch (Exception)
            {
                return success;
            }
        }
    }
}
