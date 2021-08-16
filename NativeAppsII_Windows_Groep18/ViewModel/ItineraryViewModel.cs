using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Services.IServices;
using System.Collections.ObjectModel;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class ItineraryViewModel
    {
        #region Fields
        private readonly ITripService _tripService;
        #endregion
        #region Properties
        public Trip Trip { get; set; }
        public ObservableCollection<Trip> Trips { get; set; }
        #endregion

        #region Constructors
        public ItineraryViewModel(ITripService tripService)
        {
            Trips = new ObservableCollection<Trip>();
            _tripService = tripService;
        }
        #endregion

        #region Methods
        public async void LoadTrips()
        {
            Trips.Clear();
            var trips = await _tripService.GetTrips();
            if (trips.Count > 0)
            {
                trips.ForEach(trip => Trips.Add(trip));
            }
        }
        #endregion
    }
}
