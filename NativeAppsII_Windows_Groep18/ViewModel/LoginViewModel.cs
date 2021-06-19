using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using NativeAppsII_Windows_Groep18.Services;
using Windows.Web.Http;
using Windows.Storage.Streams;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class LoginViewModel
    {
        public async Task<bool> Login(string email, string password)
        {
            HttpClient client = new HttpClient();
            var success = false;
            try
            {
                var json = JsonConvert.SerializeObject(new
                {
                    email,
                    password
                });
                var result = await client.PostAsync(new Uri($"{Globals.BASE_URL}/User/Login"),
                    new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
                if (result.IsSuccessStatusCode)
                {
                    Globals.LoggedInUser = result.Content.ToString();
                    return success = true;
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
