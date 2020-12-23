using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.Singleton;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class NavigationViewModel
    {
        public Client Client { get; set; }
        public NavigationViewModel()
        {
            Client = ClientSingleton.Instance.Client;
        }
    }
}
