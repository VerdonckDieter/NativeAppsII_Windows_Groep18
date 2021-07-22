using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.Weather;
using NativeAppsII_Windows_Groep18.Services.IServices;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class TripDetailViewModel
    {
        #region Fields
        private readonly ITripService _tripService;
        private readonly IItemService _itemService;
        private readonly IChoreService _choreService;
        private readonly ICategoryService _categoryService;
        private readonly IWeatherService _weatherService;
        private readonly IContentDialogService _contentDialogService;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        public WeatherForecast WeatherForecast { get; set; }
        #endregion

        #region Constructors
        public TripDetailViewModel(ITripService tripService, IWeatherService weatherService,
            IItemService itemService, IChoreService choreService, ICategoryService categoryService, IContentDialogService contentDialogService)
        {
            _tripService = tripService;
            _weatherService = weatherService;
            _itemService = itemService;
            _choreService = choreService;
            _categoryService = categoryService;
            _contentDialogService = contentDialogService;
        }
        #endregion

        #region Methods
        public async Task GetWeatherForecast(int days) => await _weatherService.GetWeatherForecast(Trip.Location, days);

        public async Task<Category> AddCategory(Category category) => await _categoryService.UpsertCategory(category, Trip.Id);

        public async Task<Item> AddItem(Item item, int categoryId) => await _itemService.UpsertItem(item, categoryId);

        public async Task<Chore> AddChore(Chore chore) => await _choreService.UpsertChore(chore, Trip.Id);

        public async Task UpdateCategory(Category category) => await _categoryService.UpsertCategory(category);

        public async Task UpdateItem(Item item) => await _itemService.UpsertItem(item);

        public async Task UpdateChore(Chore chore) => await _choreService.UpsertChore(chore);

        public async Task DeleteTrip(int id) => await _tripService.DeleteTrip(id);

        public async Task<bool> DeleteCategory(int categoryId) => await _categoryService.DeleteCategory(Trip.Id, categoryId);

        public async Task<bool> DeleteItem(int categoryId, int itemId) => await _itemService.DeleteItem(categoryId, itemId);

        public async Task<bool> DeleteChore(int choreId) => await _choreService.DeleteChore(Trip.Id, choreId);

        public async Task<ContentDialogResult> ShowContentDialog(string title, string content, string primaryButtonText, string closeButtonText) =>
            await _contentDialogService.ShowContentDialog(title, content, primaryButtonText, closeButtonText);
        #endregion
    }
}