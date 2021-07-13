using NativeAppsII_Windows_Groep18.ViewModel;
using NativeAppsII_Windows_Groep18.Model;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;

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

        private void ItemChecked(object sender, TappedRoutedEventArgs e)
        {
            Item selectedItem = (Item)((CheckBox)sender).DataContext;
        }
        #endregion
    }
}
