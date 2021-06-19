namespace NativeAppsII_Windows_Groep18.Utility
{
    public static class Globals
    {
        #region Properties
        public static string LoggedInUser { get; set; }

        public static string BASE_URL
        {
            get
            {
                return "https://localhost:5001/api";
            }
        }
        #endregion   
    }
}
