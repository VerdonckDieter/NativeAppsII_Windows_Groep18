using NativeAppsII_Windows_Groep18.Model;
using Newtonsoft.Json;
using System;
using Windows.Web.Http;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class RegisterViewModel
    {
        public async System.Threading.Tasks.Task Register(string email, string firstname, string lastname, DateTime birthdate)
        {
            var registerClient = new Client() { Email = email, Firstname = firstname, Lastname = lastname, Birthdate = birthdate };
            var registerClientJson = JsonConvert.SerializeObject(registerClient);
            HttpClient client = new HttpClient();
            try
            {
                var res = await client.PostAsync(new Uri("http://localhost:5000/api/client/"), new HttpStringContent(registerClientJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            }
            catch (System.Net.Http.HttpRequestException)
            {
                throw new Exception("Connection failed");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
