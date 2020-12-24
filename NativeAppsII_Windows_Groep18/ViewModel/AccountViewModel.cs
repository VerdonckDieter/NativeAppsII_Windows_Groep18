using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.Singleton;
using Newtonsoft.Json;
using System;
using Windows.Web.Http;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
        }

        public async System.Threading.Tasks.Task UpdateUser(int id, string email, string firstname, string lastname, DateTime birthdate)
        {
            HttpClient client = new HttpClient();
            var updateClient = new Client() { Id = id, Email = email, Firstname = firstname, Lastname = lastname, Birthdate = birthdate };
            var updateClientJson = JsonConvert.SerializeObject(updateClient);
            try
            {
                var res = await client.PutAsync(new Uri(String.Format("http://localhost:5000/api/client/{0}", updateClient.Id)), new HttpStringContent(updateClientJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                if (res.IsSuccessStatusCode)
                {
                    ClientSingleton.Instance.Client = updateClient;
                }
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
