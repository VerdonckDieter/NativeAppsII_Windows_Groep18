using NativeAppsII_Windows_Groep18.ViewModel;
using NativeAppsII_Windows_Groep18.Model;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Resources;
using System.Threading.Tasks;
using System.Linq;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View.TripView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripDetail : Page
    {
        #region Properties
        public TripDetailViewModel TripDetailViewModel { get; set; }
        private ResourceLoader ResourceLoader { get; set; }
        #endregion

        #region Constructors
        public TripDetail()
        {
            InitializeComponent();
            TripDetailViewModel = App.Current.Services.GetService<TripDetailViewModel>();
            DataContext = TripDetailViewModel;
            ResourceLoader = ResourceLoader.GetForCurrentView();            
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TripDetailViewModel.Trip = (Trip)e.Parameter;
        }

        private async void ItemChecked(object sender, TappedRoutedEventArgs e)
        {
            Item selectedItem = (Item)((CheckBox)sender).DataContext;
            if (selectedItem != null)
            {
                await TripDetailViewModel.UpdateItem(selectedItem);
            }
        }

        private async void ChoreChecked(object sender, TappedRoutedEventArgs e)
        {
            Chore selectedItem = (Chore)((CheckBox)sender).DataContext;
            if (selectedItem != null)
            {
                await TripDetailViewModel.UpdateChore(selectedItem);
            }
        }

        private void AddCategory(object sender, TappedRoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddCategoryName.Text))
            {
                TripDetailViewModel.AddCategory(new Category { Name = AddCategoryName.Text });
            }
            AddCategoryName.Text = string.Empty;
        }

        private void AddChore(object sender, TappedRoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddChoreName.Text))
            {
                TripDetailViewModel.AddChore(new Chore { Name = AddChoreName.Text });
            }
            AddChoreName.Text = string.Empty;
        }

        private void AddItem(object sender, TappedRoutedEventArgs e)
        {
            int categoryId = ((Category)((Button)sender).DataContext).CategoryId;
            var name = (TextBox)((Grid)((Button)sender).Parent).Children[0];
            var amount = (TextBox)((Grid)((Button)sender).Parent).Children[1];
            if (!string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(amount.Text))
            {
                int itemAmount;
                if (int.TryParse(amount.Text, out itemAmount))
                {
                    TripDetailViewModel.AddItem(new Item { CategoryId = categoryId, Name = name.Text, Amount = itemAmount, Added = false }, categoryId);
                }
            }
            name.Text = string.Empty;
            amount.Text = string.Empty;
        }

        private void ShowMenu(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((Grid)sender);
        }

        private void MenuFlyoutItemTapped(object sender, RoutedEventArgs e)
        {
            var modify = (MenuFlyoutItem)sender;
            switch (modify.Name)
            {
                case "MenuModifyCategory":
                    Modify("Category", modify);
                    break;
                case "MenuDeleteCategory":
                    Delete("Category", modify);
                    break;
                case "MenuModifyItem":
                    Modify("Item", modify);
                    break;
                case "MenuDeleteItem":
                    Delete("Item", modify);
                    break;
                case "MenuModifyChore":
                    Modify("Chore", modify);
                    break;
                case "MenuDeleteChore":
                    Delete("Chore", modify);
                    break;
                default: break;
            }
        }

        private async void Modify(string option, MenuFlyoutItem sender)
        {
            switch (option)
            {
                case "Category":
                    var modifyCategory = (Category)sender.DataContext;
                    if (modifyCategory != null)
                    {
                        await TripDetailViewModel.UpdateCategory(modifyCategory);
                    }
                    break;
                case "Item":
                    var modifyItem = (Item)sender.DataContext;
                    if (modifyItem != null)
                    {
                        await TripDetailViewModel.UpdateItem(modifyItem);
                    }
                    break;
                case "Chore":
                    var modifyChore = (Chore)sender.DataContext;
                    if (modifyChore != null)
                    {
                        await TripDetailViewModel.UpdateChore(modifyChore);
                    }
                    break;
                default: break;
            }
        }

        private async void Delete(string option, MenuFlyoutItem sender)
        {
            switch (option)
            {
                case "Category":
                    var deleteCategory = (Category)sender.DataContext;
                    if (deleteCategory != null)
                    {
                        if (await ShowDeleteContentDialog(deleteCategory.Name) == ContentDialogResult.Primary)
                        {
                            if (await TripDetailViewModel.DeleteCategory(deleteCategory.CategoryId))
                            {
                                TripDetailViewModel.Trip.Categories.Remove(deleteCategory);
                            }
                        }
                    }
                    break;
                case "Item":
                    var deleteItem = (Item)sender.DataContext;
                    if (deleteItem != null)
                    {
                        if (await ShowDeleteContentDialog(deleteItem.Name) == ContentDialogResult.Primary)
                        {
                            if (await TripDetailViewModel.DeleteItem(deleteItem.CategoryId, deleteItem.Id))
                            {
                                TripDetailViewModel.Trip.Categories.SingleOrDefault(c => c.CategoryId == deleteItem.CategoryId).Items.Remove(deleteItem);
                            }
                        }
                    }
                    break;
                case "Chore":
                    var deleteChore = (Chore)sender.DataContext;
                    if (deleteChore != null)
                    {
                        if (await ShowDeleteContentDialog(deleteChore.Name) == ContentDialogResult.Primary)
                        {
                            if (await TripDetailViewModel.DeleteChore(deleteChore.Id))
                            {
                                TripDetailViewModel.Trip.Chores.Remove(deleteChore);
                            }
                        }
                    }
                    break;
                default: break;
            }
        }

        private async Task<ContentDialogResult> ShowDeleteContentDialog(string name)
        {
            return await TripDetailViewModel.ShowContentDialog(
                            ResourceLoader.GetString("DeleteContentDialogTitle"),
                            string.Format(ResourceLoader.GetString("DeleteContentDialogContent"), name),
                            ResourceLoader.GetString("DeleteContentDialogPrimaryButton"),
                            ResourceLoader.GetString("DeleteContentDialogCloseButton"));
        }

        private void AmountBeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private async void NavigateToWeather(object sender, RoutedEventArgs e)
        {
            await TripDetailViewModel.GetWeatherForecast(14);
            Frame.Navigate(typeof(TripWeather), TripDetailViewModel);
        }
        #endregion
    }
}