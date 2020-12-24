using System.ComponentModel;

namespace NativeAppsII_Windows_Groep18.Model.Singleton
{
    public class ClientSingleton : INotifyPropertyChanged
    {
        private static ClientSingleton _instance;
        private ClientSingleton() { }
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
        private Client _client;
        public Client Client
        {
            get { return _client; }
            set
            {
                _client = value;
                NotifyPropertyChanged("Client");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
