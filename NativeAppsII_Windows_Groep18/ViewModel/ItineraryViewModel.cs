using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Services.IServices;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class ItineraryViewModel
    {
        #region Fields
        private readonly ITripService _tripService;
        private readonly IContentDialogService _contentDialogService;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        public ObservableCollection<Trip> Trips { get; set; }
        #endregion

        #region Constructors
        public ItineraryViewModel(ITripService tripService, IContentDialogService contentDialogService)
        {
            Trips = new ObservableCollection<Trip>();
            _tripService = tripService;
            _contentDialogService = contentDialogService;
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

        public async Task<ContentDialogResult> ShowContentDialog(string title, string content, string closeButtonText) =>
            await _contentDialogService.ShowContentDialog(title, content, closeButtonText);
        #endregion
    }
}
