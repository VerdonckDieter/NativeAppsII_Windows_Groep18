using NativeAppsII_Windows_Groep18.DataModel;
using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.Singleton;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class TravelListViewModel
    {
        #region Properties
        public ObservableCollection<TravelList> TravelLists { get; set; } 
        #endregion

        #region Constructor
        public TravelListViewModel()
        {
            TravelLists = new ObservableCollection<TravelList>();
            LoadTravelListsFromAPI();
        }
        #endregion

        #region Methods
        private async void LoadTravelListsFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(String.Format("http://localhost:5000/api/travelLists/{0}/travelLists", ClientSingleton.Instance.Client.Id)));
            var travelLists = JsonConvert.DeserializeObject<IList<TravelList>>(json);
            foreach (var travelList in travelLists)
            {
                TravelLists.Add(travelList);
            }
            GroupBy();
        }

        public async System.Threading.Tasks.Task AddTravelList(String name, DateTime startdate, DateTime enddate)
        {
            var travelList = new TravelList() { Name = name, StartDate = startdate, EndDate = enddate };
            var travelListJson = JsonConvert.SerializeObject(travelList);

            HttpClient client = new HttpClient();
            var res = await client.PostAsync(new Uri(String.Format("http://localhost:5000/api/travelLists/{0}", ClientSingleton.Instance.Client.Id)), new HttpStringContent(travelListJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                TravelLists.Add(JsonConvert.DeserializeObject<TravelList>(res.Content.ToString()));
            }
        }
        
        public void GroupBy()
        {
            foreach(TravelList t in TravelLists)
            {
                t.ItemsGrouped = t.Items.GroupBy(i => i.Category).ToDictionary(i => i.Key, i => i.ToList());
            }
        }
        #endregion
    }
}
