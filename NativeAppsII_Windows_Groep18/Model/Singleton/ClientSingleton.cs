
namespace NativeAppsII_Windows_Groep18.Model.Singleton
{
    public class ClientSingleton
    {
        private static ClientSingleton _instance;
        public Client Client { get; set; }
        private ClientSingleton() {}
        //public void SetClient(Client client) => Client = client;
        public static ClientSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClientSingleton();
                }
                return _instance;
            }
        }
    }
}
