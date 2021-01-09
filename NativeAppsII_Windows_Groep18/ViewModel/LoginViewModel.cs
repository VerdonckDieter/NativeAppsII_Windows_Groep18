using System;
using System.Net.Http;
using NativeAppsII_Windows_Groep18.Model;
using Newtonsoft.Json;
using NativeAppsII_Windows_Groep18.Model.Singleton;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class LoginViewModel
    {
        public Client Client { get; set; }
        private readonly ClientSingleton clientSingleton = ClientSingleton.Instance;
        public bool Succes;
        public async System.Threading.Tasks.Task Login(string email)
        {
            HttpClient client = new HttpClient();
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/client/" + email));
                if (!string.IsNullOrEmpty(json))
                {
                    var loggedInClient = JsonConvert.DeserializeObject<Client>(json);
                    Client = loggedInClient;
                    clientSingleton.Client = Client;
                    Succes = true;
                }
                else
                {
                    Succes = false;
                }

            }
            catch (HttpRequestException)
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
