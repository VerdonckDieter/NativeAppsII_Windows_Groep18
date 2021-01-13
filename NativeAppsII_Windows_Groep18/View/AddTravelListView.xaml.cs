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

        private void AddItemInputFields(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                ColumnSpacing = 8,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }
                }
            };

            TextBox ItemName = new TextBox
            {
                Header = "Name",
                PlaceholderText = "Name of the item",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            ItemName.HeaderTemplate = (DataTemplate)Resources["HeaderTemplate"];

            TextBox ItemAmount = new TextBox
            {
                Header = "Amount",
                PlaceholderText = "Amount",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            ItemAmount.HeaderTemplate = (DataTemplate)Resources["HeaderTemplate"];

            ComboBox ItemCategories = new ComboBox
            {
                Header = "Category",
                PlaceholderText = "Pick a category",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            var binding = new Binding { Source = travelListViewModel.Categories };
            ItemCategories.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            grid.Children.Add(ItemName);
            grid.Children.Add(ItemAmount);
            grid.Children.Add(ItemCategories);

            Grid.SetColumn(ItemName, 0);
            Grid.SetColumn(ItemAmount, 1);
            Grid.SetColumn(ItemCategories, 2);

            ItemStackPanel.Children.Add(grid);
        }

        private void AddTaskInputFields(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            TextBox TaskName = new TextBox
            {
                Header = "Name",
                PlaceholderText = "Name of the task",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            TaskName.HeaderTemplate = (DataTemplate)Resources["HeaderTemplate"];

            grid.Children.Add(TaskName);

            Grid.SetRow(TaskName, 0);

            TaskStackPanel.Children.Add(grid);
        }
    }
}
