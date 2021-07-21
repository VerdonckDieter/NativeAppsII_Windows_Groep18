using NativeAppsII_Windows_Groep18.ViewModel;
using NativeAppsII_Windows_Groep18.Model;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;

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

        #endregion

        #region Constructors
        public TripDetail()
        {
            InitializeComponent();
            TripDetailViewModel = App.Current.Services.GetService<TripDetailViewModel>();
            DataContext = TripDetailViewModel;
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

        private async void AddCategory(object sender, TappedRoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddCategoryName.Text))
            {
                await TripDetailViewModel.AddCategory(new Category { Name = AddCategoryName.Text });
            }
            AddCategoryName.Text = string.Empty;
        }

        private async void AddChore(object sender, TappedRoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddChoreName.Text))
            {
                await TripDetailViewModel.AddChore(new Chore { Name = AddChoreName.Text });
            }
            AddChoreName.Text = string.Empty;
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
                        await TripDetailViewModel.DeleteCategory(deleteCategory.CategoryId);
                    }
                    break;
                case "Item":
                    var deleteItem = (Item)sender.DataContext;
                    if (deleteItem != null)
                    {
                        await TripDetailViewModel.DeleteItem(deleteItem.CategoryId, deleteItem.Id);
                    }
                    break;
                case "Chore":
                    var deleteChore = (Chore)sender.DataContext;
                    if (deleteChore != null)
                    {
                        await TripDetailViewModel.DeleteChore(deleteChore.Id);
                    }
                    break;
                default: break;
            }
        }
        #endregion
    }
}