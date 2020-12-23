using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTravelListView : Page
    {
        public TravelListViewModel travelListViewModel;

        public AddTravelListView()
        {
            InitializeComponent();
            travelListViewModel = new TravelListViewModel();
            InitializeElements();
        }

        private void InitializeElements()
        {
            StartDate.MinDate = DateTimeOffset.Now;
            EndDate.MinDate = DateTimeOffset.Now;
        }

        private async void AddTravelList(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            DateTime startdate = StartDate.Date.Value.DateTime;
            DateTime enddate = EndDate.Date.Value.DateTime;
            try
            {
                await travelListViewModel.AddTravelList(name, startdate, enddate);
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog();

                dialog.CloseButtonText = "Close";
                dialog.ShowAsync();
            }
        }
    }
}
