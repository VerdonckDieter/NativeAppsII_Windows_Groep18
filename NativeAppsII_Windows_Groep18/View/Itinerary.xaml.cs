using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Navigation;
using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Utility;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Itinerary : Page
    {
        #region Properties
        public ItineraryViewModel ItineraryViewModel { get; set; }
        #endregion

        #region Constructors
        public Itinerary()
        {
            InitializeComponent();
            ItineraryViewModel = App.Current.Services.GetService<ItineraryViewModel>();
            DataContext = ItineraryViewModel;
            TravelMap.MapServiceToken = Globals.MAP_TOKEN;
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ItineraryViewModel.Trips.Count < 1)
            {
                ItineraryViewModel.LoadTrips();
            }
        }

        private void ShowRoute(object sender, RoutedEventArgs e)
        {
            Trip trip = (Trip)ItineraryComboBox.SelectedItem;
            ShowRouteOnMap(trip);
        }

        private async void ShowRouteOnMap(Trip trip)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator geolocator = new Geolocator { DesiredAccuracy = PositionAccuracy.High };
                    Geoposition geoposition = await geolocator.GetGeopositionAsync();

                    BasicGeoposition startLocation = new BasicGeoposition()
                    {
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    };

                    BasicGeoposition endLocation;

                    MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(trip.Location, null, 1);
                    endLocation = result.Status == MapLocationFinderStatus.Success
                        ? new BasicGeoposition()
                        {
                            Latitude = result.Locations[0].Point.Position.Latitude,
                            Longitude = result.Locations[0].Point.Position.Longitude
                        }
                        : new BasicGeoposition()
                        {
                            Latitude = 51.0543422,
                            Longitude = 3.7174243
                        };

                    MapRouteFinderResult routeResult =
                            await MapRouteFinder.GetDrivingRouteAsync(
                            new Geopoint(startLocation),
                            new Geopoint(endLocation),
                            MapRouteOptimization.Time,
                            MapRouteRestrictions.None);

                    if (routeResult.Status == MapRouteFinderStatus.Success)
                    {
                        MapRouteView viewOfRoute = new MapRouteView(routeResult.Route)
                        {
                            RouteColor = Colors.Yellow,
                            OutlineColor = Colors.Black
                        };
                        TravelMap.Routes.Add(viewOfRoute);
                        await TravelMap.TrySetViewBoundsAsync(
                              routeResult.Route.BoundingBox,
                              null,
                              MapAnimationKind.Bow);
                    }
                    break;

                case GeolocationAccessStatus.Denied:
                    break;
                case GeolocationAccessStatus.Unspecified:
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
