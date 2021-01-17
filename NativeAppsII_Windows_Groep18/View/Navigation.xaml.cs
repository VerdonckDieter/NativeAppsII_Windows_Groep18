using NativeAppsII_Windows_Groep18.Model.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeAppsII_Windows_Groep18.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Navigation : Page
    {
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("Home", typeof(TravelListOverview)),
            ("Add TravelList", typeof(AddTravelListView)),
            ("Account", typeof(Account)),
            ("Maps", typeof(Itinerary)),
            ("Logout", typeof(MainPage))
        };
        public Navigation()
        {
            InitializeComponent();
            InitializeElements();
            var page = _pages.FirstOrDefault(p => p.Tag.Equals("Home"));
            Type _page = page.Page;
            Content.Navigate(_page);
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            Type _page = null;
            var item = _pages.FirstOrDefault(p => p.Tag.Equals(args.InvokedItem.ToString()));
            _page = item.Page;
            switch (item.Tag)
            {
                case "Home":
                    Content.Navigate(_page);
                    break;
                case "Add TravelList":
                    Content.Navigate(_page);
                    break;
                case "Account":
                    Content.Navigate(_page);
                    break;
                case "Maps":
                    Content.Navigate(_page);
                    break;
                case "Logout":
                    Frame.Navigate(_page);
                    break;
                default:
                    break;
            }
        }

        private void InitializeElements()
        {
            var binding = new Binding { Source = ClientSingleton.Instance.Client.Email, Mode = BindingMode.OneWay };
            ClientEmail.SetBinding(NavigationViewItem.ContentProperty, binding);
        }
    }
}
