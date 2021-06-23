using Microsoft.Toolkit.Uwp;
using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Services.IServices;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Windows.System;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class TripViewModel : BindableBase
    {
        #region Fields
        private bool _isLoading;
        private readonly ITripService _tripService;
        #endregion

        #region Properties
        public ObservableCollection<Trip> Trips { get; set; }
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }
        #endregion

        #region Constructor
        public TripViewModel(ITripService tripService)
        {
            Trips = new ObservableCollection<Trip>();
            _tripService = tripService;
            IsLoading = false;
        }
        #endregion

        #region Methods
        public async void LoadTrips()
        {
            DispatcherQueue dispatcherQueue = DispatcherQueue.GetForCurrentThread();

            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
                Trips.Clear();
            });

            var trips = await _tripService.GetTrips();

            await System.Threading.Tasks.Task.Delay(2000);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                if (trips.Count > 0)
                {
                    trips.ForEach(trip => Trips.Add(trip));
                }
                IsLoading = false;
            });
        }

        public async void DeleteTrip(int id) => await _tripService.DeleteTrip(id);
        #endregion
    }
}
