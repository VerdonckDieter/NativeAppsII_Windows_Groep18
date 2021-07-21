﻿using NativeAppsII_Windows_Groep18.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;
using NativeAppsII_Windows_Groep18.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View.TripView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripOverview : Page
    {
        #region Properties
        public TripViewModel TripViewModel { get; set; }
        #endregion

        #region Constructors
        public TripOverview()
        {
            InitializeComponent();
            TripViewModel = App.Current.Services.GetService<TripViewModel>();
            DataContext = TripViewModel;
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (TripViewModel.Trips.Count < 1)
            {
                TripViewModel.LoadTrips();
            }
        }

        private void NavigateToDetail(object sender, TappedRoutedEventArgs e)
        {
            if (TripGridView.SelectedItem is Trip clickedItem)
            {
                Frame.Navigate(typeof(TripDetail), clickedItem);
            }
        }
        #endregion
    }
}