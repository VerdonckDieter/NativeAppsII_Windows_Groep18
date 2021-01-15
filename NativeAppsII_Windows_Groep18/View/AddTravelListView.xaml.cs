using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTravelListView : Page
    {
        public TravelListViewModel travelListViewModel;

        private double StartLatitude;
        private double StartLongitude;
        private double EndLatitude;
        private double EndLongitude;

        public AddTravelListView()
        {
            InitializeComponent();
            travelListViewModel = new TravelListViewModel();
            InitializeElements();
            MapService.ServiceToken = "kiMTfBjS18oItbEwSQsi~V30ULXHdubcpoIgp7E9GjA~AhlM7Rp6OqMz_O06wAnydivBQG4XpUEUJKwS9nPg-y5tajWHqTi5VJ9fnOUiUQTD";
        }

        private void InitializeElements()
        {
            StartDate.MinDate = DateTimeOffset.Now;
            EndDate.MinDate = DateTimeOffset.Now;
            Name.AddHandler(TappedEvent, new TappedEventHandler(ResetErrors), true);

        }

        private async void AddTravelList(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Name.Text) || StartDate.Date == null || EndDate.Date == null)
            {
                AddTravelListError();
            }
            else
            {
                string name = Name.Text;
                DateTime startdate = StartDate.Date.Value.DateTime;
                DateTime enddate = EndDate.Date.Value.DateTime;
                await GetPosition(StartPosition.Text, EndPosition.Text);
                double startLatitude = StartLatitude;
                double startLongitude = StartLongitude;
                double endLatitude = EndLatitude;
                double endLongitude = EndLongitude;
                List<Item> items = GetItemsFromInput();
                List<Task> tasks = GetTasksFromInput();
                try
                {
                    await travelListViewModel.AddTravelList(name, startdate, enddate, startLatitude, startLongitude, endLatitude, endLongitude, items, tasks);
                }
                catch (Exception ex)
                {
                    var dialog = new ContentDialog();

                    dialog.CloseButtonText = "Close";
                    dialog.ShowAsync();
                }
            }
        }

        private List<Item> GetItemsFromInput()
        {
            List<Item> items = new List<Item>();
            foreach (var item in ItemListView.Items)
            {
                Grid grid = (Grid)item;
                var name = ((TextBox)grid.Children.ElementAt(0)).Text;
                var amount = int.Parse(((TextBox)grid.Children.ElementAt(1)).Text);
                var category = ((Category)((ComboBox)grid.Children.ElementAt(2)).SelectedItem).Name;
                var newItem = new Item() { Name = name, Amount = amount, Category = category };
                items.Add(newItem);
            }
            return items;
        }

        private List<Task> GetTasksFromInput()
        {
            List<Task> tasks = new List<Task>();
            foreach (var task in TaskListView.Items)
            {
                Grid grid = (Grid)task;
                var name = ((TextBox)grid.Children.ElementAt(0)).Text;
                var newTask = new Task() { Name = name };
                tasks.Add(newTask);
            }
            return tasks;
        }

        private void AddTravelListError()
        {
            if (String.IsNullOrEmpty(Name.Text))
            {
                Name.Text = string.Empty;
                Name.Header = "Name is required";
                Name.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (StartDate.Date == null)
            {
                StartDate.Date = null;
                StartDate.Header = "Start date is required";
                StartDate.Foreground = new SolidColorBrush(Colors.Red);
                StartDate.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (EndDate.Date == null)
            {
                EndDate.Date = null;
                EndDate.Header = "End date is required";
                EndDate.Foreground = new SolidColorBrush(Colors.Red);
                EndDate.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void ResetErrors(object sender, TappedRoutedEventArgs e)
        {
            switch (sender.GetType().Name)
            {
                case "TextBox":
                    Name.Header = "Name";
                    Name.ClearValue(TextBox.BorderBrushProperty);
                    break;
                case "CalendarDatePicker":
                    if (((CalendarDatePicker)sender).Name.Equals("StartDate"))
                    {
                        StartDate.Header = "Start date";
                        StartDate.ClearValue(CalendarDatePicker.ForegroundProperty);
                        StartDate.ClearValue(CalendarDatePicker.BorderBrushProperty);
                    }
                    else
                    {
                        EndDate.Header = "End date";
                        EndDate.ClearValue(CalendarDatePicker.ForegroundProperty);
                        EndDate.ClearValue(CalendarDatePicker.BorderBrushProperty);
                    }
                    break;
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
            ItemCategories.ItemTemplate = (DataTemplate)Resources["ComboBoxTemplate"];

            grid.Children.Add(ItemName);
            grid.Children.Add(ItemAmount);
            grid.Children.Add(ItemCategories);

            Grid.SetColumn(ItemName, 0);
            Grid.SetColumn(ItemAmount, 1);
            Grid.SetColumn(ItemCategories, 2);

            ItemListView.Items.Add(grid);
        }

        private void RemoveItemInputFields(object sender, RoutedEventArgs e)
        {
            if (ItemListView.Items.Count > 0)
            {
                ItemListView.Items.RemoveAt(ItemListView.Items.Count - 1);
            }
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

            TaskListView.Items.Add(grid);
        }

        private void RemoveTaskInputFields(object sender, RoutedEventArgs e)
        {
            if (TaskListView.Items.Count > 0)
            {
                TaskListView.Items.RemoveAt(TaskListView.Items.Count - 1);
            }
        }

        private async System.Threading.Tasks.Task GetPosition(string startPosition, string endPosition)
        {
            StartLatitude = (await GetPosition(startPosition))[0];
            StartLongitude = (await GetPosition(startPosition))[1];
            EndLatitude = (await GetPosition(endPosition))[0];
            EndLongitude = (await GetPosition(endPosition))[1];
        }

        private async System.Threading.Tasks.Task<List<double>> GetPosition(string address)
        {
            List<double> positions = new List<double>();
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(
                                    address, null, 1);

            if (result.Status == MapLocationFinderStatus.Success)
            {
                positions.Add(result.Locations[0].Point.Position.Latitude);
                positions.Add(result.Locations[0].Point.Position.Longitude);
            }
            return positions;
        }
    }
}
