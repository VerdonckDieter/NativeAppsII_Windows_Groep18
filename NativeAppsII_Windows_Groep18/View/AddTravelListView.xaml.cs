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


        public AddTravelListView()
        {
            this.InitializeComponent();
            InitializeElements();
            CenterElements();
        }

        private void InitializeElements()
        {
            pageAdd.FontFamily = new FontFamily("Helvetica");

            startDateInput.MinDate = DateTimeOffset.Now;
            endDateInput.MinDate = DateTimeOffset.Now;
        }

        public void CenterElements()
        {
            foreach(var child in stackPanelAdd.Children.OfType<FrameworkElement>())
            {
                if(child is TextBox)
                {
                    child.HorizontalAlignment = HorizontalAlignment.Stretch;
                }
                else
                {
                    child.HorizontalAlignment = HorizontalAlignment.Left;
                    child.Margin = new Thickness(0,20,0,5);
                }
            }
        }
    }
}
