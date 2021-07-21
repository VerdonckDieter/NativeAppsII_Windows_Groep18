﻿using NativeAppsII_Windows_Groep18.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Input;
using NativeAppsII_Windows_Groep18.Services.Instances;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View.TripView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTripView : Page
    {
        #region Properties
        public AddTripViewModel AddTripViewModel { get; set; }
        private ResourceLoader ResourceLoader { get; set; }
        #endregion
        public AddTripView()
        {
            InitializeComponent();
            AddTripViewModel = App.Current.Services.GetService<AddTripViewModel>();
            DataContext = AddTripViewModel;
            ResourceLoader = ResourceLoader.GetForCurrentView();
            AddTripName.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AddTripLocation.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AddTripStartDate.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            AddTripEndDate.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);
            //MapService.ServiceToken = "kiMTfBjS18oItbEwSQsi~V30ULXHdubcpoIgp7E9GjA~AhlM7Rp6OqMz_O06wAnydivBQG4XpUEUJKwS9nPg-y5tajWHqTi5VJ9fnOUiUQTD";
        }

        private async void AddTrip(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if(await AddTripViewModel.AddTrip(AddTripName.Text, AddTripLocation.Text, AddTripStartDate.Date.Value.DateTime, AddTripEndDate.Date.Value.DateTime) != null)
                {
                    ToastService.MakeToast(string.Format(ResourceLoader.GetString("AddTripCreated"), AddTripName.Text));
                }
            }
        }

        private bool Validate()
        {
            var success = true;
            if (string.IsNullOrWhiteSpace(AddTripName.Text))
            {
                AddTripName.Text = string.Empty;
                AddTripName.Header = ResourceLoader.GetString("AddTripNameEmpty");
                AddTripName.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (string.IsNullOrWhiteSpace(AddTripLocation.Text))
            {
                AddTripLocation.Text = string.Empty;
                AddTripLocation.Header = ResourceLoader.GetString("AddTripLocationEmpty");
                AddTripLocation.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (AddTripStartDate.Date == null)
            {
                AddTripStartDate.Date = null;
                AddTripStartDate.Header = ResourceLoader.GetString("AddTripStartDateEmpty");
                AddTripStartDate.Foreground = new SolidColorBrush(Colors.Red);
                AddTripStartDate.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            if (AddTripEndDate.Date == null)
            {
                AddTripEndDate.Date = null;
                AddTripEndDate.Header = ResourceLoader.GetString("AddTripEndDateEmpty");
                AddTripEndDate.Foreground = new SolidColorBrush(Colors.Red);
                AddTripEndDate.BorderBrush = new SolidColorBrush(Colors.Red);
                success = false;
            }
            return success;
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            AddTripName.Header = ResourceLoader.GetString("AddTripName/Header");
            AddTripName.ClearValue(BorderBrushProperty);

            AddTripLocation.Header = ResourceLoader.GetString("AddTripLocation/Header");
            AddTripLocation.ClearValue(BorderBrushProperty);

            AddTripStartDate.Header = ResourceLoader.GetString("AddTripStartDate/Header");
            AddTripStartDate.ClearValue(ForegroundProperty);
            AddTripStartDate.ClearValue(BorderBrushProperty);

            AddTripEndDate.Header = ResourceLoader.GetString("AddTripEndDate/Header");
            AddTripEndDate.ClearValue(ForegroundProperty);
            AddTripEndDate.ClearValue(BorderBrushProperty);
        }
    }
}