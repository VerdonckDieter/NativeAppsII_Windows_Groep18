using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Services.IServices;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class UpdateTripViewModel
    {
        #region Fields
        private readonly ITripService _tripService;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        #endregion

        #region Constructors
        public UpdateTripViewModel(ITripService tripService)
        {
            _tripService = tripService;
        }
        #endregion

        #region Methods
        public async Task UpdateTrip() => await _tripService.UpsertTrip(Trip);
        #endregion
    }
}
