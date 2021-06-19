using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TravelListOverview : Page
    {
        public TravelListViewModel TravelListViewModel;

        public TravelListOverview()
        {
            InitializeComponent();
            TravelListViewModel = new TravelListViewModel();
        }

        //private async void SaveTravelList(object sender, RoutedEventArgs e)
        //{
        //    var travelList = (TravelList)MasterDetailTravelListOverview.SelectedItem;
        //    try
        //    {
        //        await TravelListViewModel.UpdateTravelList(travelList);
        //        travelList.UpdateProgress();
        //    }
        //    catch (Exception ex)
        //    {
        //        var dialog = new ContentDialog
        //        {
        //            Title = ex.Message,
        //            CloseButtonText = "Close"
        //        };
        //        await dialog.ShowAsync();
        //    }
        //}
    }
}
