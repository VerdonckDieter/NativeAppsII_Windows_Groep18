﻿using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Model.Weather;
using NativeAppsII_Windows_Groep18.Services.IServices;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class TripDetailViewModel
    {
        #region Fields
        private readonly IItemService _itemService;
        private readonly IChoreService _choreService;
        private readonly ICategoryService _categoryService;
        private readonly IContentDialogService _contentDialogService;
        #endregion

        #region Properties
        public Trip Trip { get; set; }
        public WeatherForecast WeatherForecast { get; set; }
        #endregion

        #region Constructors
        public TripDetailViewModel(IItemService itemService, IChoreService choreService, ICategoryService categoryService, IContentDialogService contentDialogService)
        {
            _itemService = itemService;
            _choreService = choreService;
            _categoryService = categoryService;
            _contentDialogService = contentDialogService;
        }
        #endregion

        #region Methods
        public async void AddCategory(Category category)
        {
            var categoryAdded = await _categoryService.UpsertCategory(category, Trip.Id);
            if (categoryAdded != null)
            {
                Trip.Categories.Add(categoryAdded);
            }
        }

        public async void AddItem(Item item, int categoryId)
        {
            var itemAdded = await _itemService.UpsertItem(item, categoryId);
            if (itemAdded != null)
            {
                Trip.Categories.SingleOrDefault(c => c.CategoryId == categoryId).Items.Add(itemAdded);
            }
        }

        public async void AddChore(Chore chore)
        {
            var choreAdded = await _choreService.UpsertChore(chore, Trip.Id);
            if (choreAdded != null)
            {
                Trip.Chores.Add(choreAdded);
            }
        }

        public async Task UpdateCategory(Category category) => await _categoryService.UpsertCategory(category);

        public async Task UpdateItem(Item item) => await _itemService.UpsertItem(item);

        public async Task UpdateChore(Chore chore) => await _choreService.UpsertChore(chore);

        public async Task<bool> DeleteCategory(int categoryId) => await _categoryService.DeleteCategory(Trip.Id, categoryId);

        public async Task<bool> DeleteItem(int categoryId, int itemId) => await _itemService.DeleteItem(categoryId, itemId);

        public async Task<bool> DeleteChore(int choreId) => await _choreService.DeleteChore(Trip.Id, choreId);

        public async Task<ContentDialogResult> ShowContentDialog(string title, string content, string primaryButtonText, string closeButtonText) =>
            await _contentDialogService.ShowContentDialog(title, content, primaryButtonText, closeButtonText);
        #endregion
    }
}