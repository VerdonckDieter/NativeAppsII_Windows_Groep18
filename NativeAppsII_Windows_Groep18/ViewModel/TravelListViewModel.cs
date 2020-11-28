using NativeAppsII_Windows_Groep18.DataModel;
using NativeAppsII_Windows_Groep18.ViewModel.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class TravelListViewModel
    {
        #region Properties
        public AddTravelListCommand AddCommand { get; set; }

        public ObservableCollection<TravelList> TravelLists { get; set; }
        #endregion

        #region Constructor
        public TravelListViewModel()
        {
            TravelLists = new ObservableCollection<TravelList>();
            LoadTravelListsFromAPI();
            AddCommand = new AddTravelListCommand(this);
        }
        #endregion

        #region Methods
        private async void LoadTravelListsFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/travelLists/"));
            var travelLists = JsonConvert.DeserializeObject<IList<TravelList>>(json);
            foreach (var travelList in travelLists)
            {
                TravelLists.Add(travelList);
            }
        }

        public async Task AddTravelList(String name)
        {
            //Nog travelList aanmaken maar weet nog niet hoe
            var travelList = new TravelList() { Name = name, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            var travelListJson = JsonConvert.SerializeObject(travelList);

            HttpClient client = new HttpClient();
            var res = await client.PostAsync(new Uri("http://localhost:5000/api/travelLists/"), new HttpStringContent(travelListJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                TravelLists.Add(JsonConvert.DeserializeObject<TravelList>(res.Content.ToString()));
            }
        } 
        #endregion
    }
}
