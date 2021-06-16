using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.DTO;
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
        //#region Properties
        //public ObservableCollection<TravelList> TravelLists { get; set; }
        //public ObservableCollection<Category> Categories { get; set; }
        //#endregion

        #region Constructor
        public TravelListViewModel()
        {
            //TravelLists = new ObservableCollection<TravelList>();
            //LoadTravelListsFromAPI();
            //InitializeCategories();
        }
        #endregion

        //#region Methods
        //private async void LoadTravelListsFromAPI()
        //{
        //    HttpClient client = new HttpClient();
        //    var json = await client.GetStringAsync(new Uri(String.Format("http://localhost:5000/api/travelLists/{0}/travelLists", ClientSingleton.Instance.Client.Id)));
        //    var travelLists = JsonConvert.DeserializeObject<IList<Trip>>(json);
        //    foreach (var travelList in travelLists)
        //    {
        //        TravelLists.Add(travelList);
        //    }
        //    InitializeTravelListProperties();
        //}

        //public async System.Threading.Tasks.Task AddTravelList(String name, DateTime startdate, DateTime enddate,
        //    double startLatitude, double startLongitude, double endLatitude, double endLongitude, List<Item> items = null, List<Chore> tasks = null)
        //{
        //    var itinerary = new Itinerary() { StartLatitude = startLatitude, StartLongitude = startLongitude, EndLatitude = endLatitude, EndLongitude = endLongitude };
        //    var travelList = new TravelListDTO()
        //    {
        //        Name = name,
        //        StartDate = startdate,
        //        EndDate = enddate,
        //        Items = items,
        //        Tasks = tasks,
        //        Itinerary = itinerary
        //    };
        //    var travelListJson = JsonConvert.SerializeObject(travelList);
        //    HttpClient client = new HttpClient();
        //    try
        //    {
        //        var res = await client.PostAsync(new Uri(String.Format("http://localhost:5000/api/travelLists/{0}", ClientSingleton.Instance.Client.Id)), new HttpStringContent(travelListJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

        //        if (res.IsSuccessStatusCode)
        //        {
        //            TravelLists.Add(JsonConvert.DeserializeObject<TravelList>(res.Content.ToString()));
        //        }
        //    }
        //    catch (System.Net.Http.HttpRequestException)
        //    {
        //        throw new Exception("Connection failed");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async System.Threading.Tasks.Task UpdateTravelList(TravelList travelList)
        //{
        //    HttpClient client = new HttpClient();
        //    travelList.Items = new ObservableCollection<Item>(RetrieveItemsFromDictionary(travelList));
        //    var travelListDto = new TravelListDTO()
        //    {
        //        Id = travelList.Id,
        //        Name = travelList.Name,
        //        StartDate = travelList.StartDate,
        //        EndDate = travelList.EndDate,
        //        Items = travelList.Items.ToList()
        //    };
        //    var updateTravelListJson = JsonConvert.SerializeObject(travelListDto);
        //    try
        //    {
        //        var res = await client.PutAsync(new Uri(String.Format("http://localhost:5000/api/travelLists/{0}/travelLists/{1}", ClientSingleton.Instance.Client.Id, travelList.Id)), new HttpStringContent(updateTravelListJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
        //        if (res.IsSuccessStatusCode)
        //        {
        //        }
        //    }
        //    catch (System.Net.Http.HttpRequestException)
        //    {
        //        throw new Exception("Connection failed");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void InitializeTravelListProperties()
        //{
        //    foreach (TravelList t in TravelLists)
        //    {
        //        t.ItemsGrouped = t.Items.GroupBy(i => i.Category).ToDictionary(i => i.Key, i => i.ToList());
        //        t.UpdateProgress();
        //    }
        //}

        //public List<Item> RetrieveItemsFromDictionary(TravelList travelList)
        //{
        //    List<Item> items = new List<Item>();
        //    foreach (var i in travelList.ItemsGrouped)
        //    {
        //        items.AddRange(i.Value);
        //    }
        //    return items;
        //}

        //public void InitializeCategories()
        //{
        //    Categories = new ObservableCollection<Category>
        //    {
        //        new Category() { Name = "Opmaak" },
        //        new Category() { Name = "Technologie" },
        //        new Category() { Name = "Bad" },
        //        new Category() { Name = "Kledij" }
        //    };
        //}
        //#endregion
    }
}
