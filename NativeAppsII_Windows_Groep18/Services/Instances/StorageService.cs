using Windows.Storage;

namespace NativeAppsII_Windows_Groep18.Services.Instances
{
    public static class StorageService
    {
        #region Methods
        public static void StoreToken(string token)
        {
            ApplicationData.Current.LocalSettings.Values["token"] = token;
        }

        public static string RetrieveToken()
        {
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("token", out object token))
            {
                return token.ToString();
            }
            return default;
        }
        #endregion
    }
}
