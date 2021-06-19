using System;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Itinerary : Page
    {
        public Itinerary()
        {
            InitializeComponent();
        }

        //private void Click_ShowRoute(object sender, RoutedEventArgs e)
        //{
        //    TravelList travelList = (TravelList)ItineraryComboBox.SelectedItem;
        //    ShowRouteOnMap(travelList.Itinerary.StartLatitude, travelList.Itinerary.StartLongitude, travelList.Itinerary.EndLatitude, travelList.Itinerary.EndLongitude);
        //}

        //private async void ShowRouteOnMap(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        //{
        //    TravelMap.Routes.Clear();

        //    BasicGeoposition startLocation = new BasicGeoposition() { Latitude = startLatitude, Longitude = startLongitude };
        //    BasicGeoposition endLocation = new BasicGeoposition() { Latitude = endLatitude, Longitude = endLongitude };

        //    // Get the route between the points.
        //    MapRouteFinderResult routeResult =
        //          await MapRouteFinder.GetDrivingRouteAsync(
        //          new Geopoint(startLocation),
        //          new Geopoint(endLocation),
        //          MapRouteOptimization.Time,
        //          MapRouteRestrictions.None);

        //    if (routeResult.Status == MapRouteFinderStatus.Success)
        //    {
        //        // Use the route to initialize a MapRouteView.
        //        MapRouteView viewOfRoute = new MapRouteView(routeResult.Route)
        //        {
        //            RouteColor = Colors.Yellow,
        //            OutlineColor = Colors.Black
        //        };

        //        // Add the new MapRouteView to the Routes collection of the MapControl.
        //        TravelMap.Routes.Add(viewOfRoute);

        //        // Fit the MapControl to the route.
        //        await TravelMap.TrySetViewBoundsAsync(
        //              routeResult.Route.BoundingBox,
        //              null,
        //              MapAnimationKind.Bow);
        //    }
        //}
    }
}
